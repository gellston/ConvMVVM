
<center> 
<img src="https://github.com/gellston/ConvMVVM/blob/development/Icon/convergence.png?raw=true" width=200 /> </center> 

ConvMVVM 
=======================
ConvMVVM (Convergence MVVM) is free MVVM library for WPF inspired by Community Toolkit library and Prism frameworks.




Development Environment
=======================
 - **Visual Studio 2022**
 - **Microsoft .NET 7**


IOC Container
=======================

```csharp
var collection = ConvMVVM.Core.DI.ServiceCollection.Create();
//it suport constructor injection 
collection.RegisterCache<AModel>();
collection.RegisterCache<IBModel, BModel>();

//it support lambda creation 
collection.RegisterCache<CModel>((container) =>{
    var aModel = container.GetService<AModel>();
    var bModel = container.GetService<IBModel>();
    var model = CModel(aModel, bModel);
    return model;
})

collection.RegisterCache<DModel>(new DModel());

//ioc container creation
var container = collection.CreateContainer();
var aModel1 = container.GetService<AModel>();
var bModel1 = container.GetService<IBModel>();
var dModel = container.GetService<DModel>();
```

> it support constructor injection and lambda creation routine


Property 
=======================
```csharp

partial class AViewModel : NotifyObject
{
    public AViewModel() { 
    }

    //it support code generator
    [Property]
    private string _Test1 = "";

    private string _Test2 = "";
    public string Test2
    {
        get => _Test2;
        set => Property(ref _Test2, value);
    }
}
```
> it support property changed notification and source generator for property


RelayCommand
=======================
```csharp
partial class MainWindowViewModel : NotifyObject
{
    public MainWindowViewModel() { 
    }

    [RelayCommand]
    private void Test()
    {
        System.Diagnostics.Debug.WriteLine("no delay!!");
    }
    
    [AsyncRelayCommand]
    private async Task AsyncTest()
    {
        await Task.Delay(10000);
        System.Diagnostics.Debug.WriteLine("delay!!");
    }

}
```
> it support RelayCommand and AsyncRelayCommand also support source generator for them


ViewModelLocator
=======================
```xml
<Window x:Class="RelayCommandExample.View.MainWindowView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:RelayCommandExample"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800"
        xmlns:convMVVM="https://github.com/gellston/ConvMVVM"
        convMVVM:ViewModelLocator.AutoWireViewModel="True"> 
        //Auto Wire ViewModel//
</Window>
```


EventToCommand
=======================
```xml
<Window x:Class="EventToCommandExample.View.MainWindowView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:EventToCommandExample"
        xmlns:behavior="http://schemas.microsoft.com/xaml/behaviors"
        xmlns:convMVVM="https://github.com/gellston/ConvMVVM"
        convMVVM:ViewModelLocator.AutoWireViewModel="True"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <behavior:Interaction.Behaviors>
        <convMVVM:EventToCommand EventName="Loaded" 
                                 Command="{Binding Loaded1Command}"></convMVVM:EventToCommand>
        <convMVVM:EventToCommand EventName="Loaded" 
                                 Command="{Binding Loaded2Command}"
                                 CommandParameter="2"></convMVVM:EventToCommand>
    </behavior:Interaction.Behaviors>
</Window>
```
RegionManager
=======================
```xml
<Window x:Class="RegionManagerExample.View.MainWindowView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:RegionManagerExample"
        xmlns:convMVVM="https://github.com/gellston/ConvMVVM"
        convMVVM:ViewModelLocator.AutoWireViewModel="True"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <DockPanel>
        <Button Height="40"
                Content="Navigate"
                Command="{Binding TestCommand}"
                DockPanel.Dock="Bottom"></Button>
        <ContentControl convMVVM:RegionManager.RegionName="MainContent"></ContentControl>
    </DockPanel>
</Window>

```
> it support to place view with specific key name

TranslateService
=======================
```xml
<Window x:Class="TranslateServiceExample.View.MainWindowView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:TranslateServiceExample"
        xmlns:convMVVM="https://github.com/gellston/ConvMVVM"
        convMVVM:ViewModelLocator.AutoWireViewModel="True"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <DockPanel>
        <Button DockPanel.Dock="Bottom" Height="40" Content="{convMVVM:TranslateExtensions Language}"
                Command="{Binding TestCommand}"></Button>
        <TextBlock Text="{convMVVM:TranslateExtensions TestContent}"
                   HorizontalAlignment="Center"
                   VerticalAlignment="Center"></TextBlock>
    </DockPanel>
</Window>
```
```csharp
namespace TranslateServiceExample
{
    public class App : ConvMVVMApp
    {
        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {

            serviceCollection.RegisterCache<MainWindowViewModel>();

        }

        protected override void ConfigureServiceLocator()
        {
           
            ServiceLocator.ResourceContainer.ChangeResourceManager(TranslateServiceExample.Properties.Resources.ResourceManager);
            ServiceLocator.ResourceContainer.ChangeCulture("kr");
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }

    }
}


```
> it support to change key string by culture information in resource file

AutoViewTemplateSelector
=======================
```xml
﻿<Window x:Class="AutoViewTemplateSelector.View.MainWindowView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:AutoViewTemplateSelector"
        xmlns:convMVVM="https://github.com/gellston/ConvMVVM"
        convMVVM:ViewModelLocator.AutoWireViewModel="True"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="*"></RowDefinition>
            <RowDefinition Height="50"></RowDefinition>
        </Grid.RowDefinitions>
        <ContentControl Grid.Row="0"
                        Content="{Binding AViewModel}">
            <ContentControl.ContentTemplateSelector>
                <convMVVM:AutoViewTemplateSelector></convMVVM:AutoViewTemplateSelector>
            </ContentControl.ContentTemplateSelector>
        </ContentControl>

        <ListBox Grid.Row="1"
                 ItemsSource="{Binding ViewModelCollection}"
                 HorizontalContentAlignment="Stretch"
                 VerticalContentAlignment="Stretch">
            <ListBox.ItemTemplateSelector>
                <convMVVM:AutoViewTemplateSelector></convMVVM:AutoViewTemplateSelector>
            </ListBox.ItemTemplateSelector>
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}">
                    <Setter Property="Height" Value="40"></Setter>
                </Style>
            </ListBox.ItemContainerStyle>
        </ListBox>

        <ContentControl Grid.Row="2"
                        Content="{Binding DViewModel}">
            <ContentControl.ContentTemplateSelector>
                <convMVVM:AutoViewTemplateSelector Fallback="FallbackView"></convMVVM:AutoViewTemplateSelector>
            </ContentControl.ContentTemplateSelector>
        </ContentControl>

        <Button Grid.Row="3"
                Content="View Change"
                Command="{Binding UpdateCommand}"></Button>
    </Grid>
</Window>
```
> it support to place view by view model name automatically



Module
=======================
```csharp
namespace AModule
{
    public class Module : IModule
    {
        public void OnInitialized(IServiceContainer container)
        {

            var regionManager = container.GetService<IRegionManager>();
            regionManager.NavigateCache("MainContent", "AView");
        }

        public void OnInitResource(IServiceContainer container)
        {
        }

        public void OnInitServiceLocator()
        {
            ServiceLocator.RegionManager.RegisterCacheView<AView>();
        }

        public void RegisterService(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<AViewModel>();
        }
    }
}
```
```csharp
namespace ModuleExample
{
    internal class App : ConvMVVMApp
    {

        protected override void ConfigureModule(ModuleCollection modules)
        {
            modules.AddModule<AModule.Module>();
        }

        protected override void ConfigureServiceCollection(IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterCache<MainWindowViewModel>();
        }

        protected override Window CreateWindow(IServiceContainer serviceProvider)
        {
            return new MainWindowView();
        }
    }
}
```
> it support to make module separately and use in main application


Messenger
=======================
```csharp
namespace MessengerExample.ViewModel
{
    partial class AViewModel : NotifyObject
    {

        #region Constructor
        public AViewModel() { 
        
        
        }
        #endregion


        #region Command
        [RelayCommand]
        private void Test()
        {


            WeakReferenceMessenger.Default.Send("There is no cow level");
        }
        #endregion
    }
}
```

```csharp
namespace MessengerExample.ViewModel
{
    partial class BViewModel : NotifyObject
    {
        #region Constructor
        public BViewModel() { 
        
        
        }
        #endregion


        #region Public Property

        [Property]
        private string _Test = "";
        #endregion


        #region Event Handler
        public override void OnActive()
        {
            WeakReferenceMessenger.Default.Register<BViewModel, string>(this, (receiver, message) =>
            {
                this.Test = message;
            });
        }
        #endregion
    }
}
```
> it support to send message between viewmodels

License
=======================

```
The MIT License (MIT)

Copyright (c) 2022-present ConvMVVM Development Team

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
```
<div style="text-align: right; margin-right:30px;"> 

[TOP](#convmvvm) 



</div>
