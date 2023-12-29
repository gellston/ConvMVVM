
ConvMVVM
=======================
MrD is a free image labeling and training tool developed in C# WPF based on Visual Studio 2022 <br/>
The current version supports labeling classification datasets and training, auto labeling.



Development Environment
=======================
 - **Visual Studio 2022**
 - **Microsoft .NET 7**


Tutorial
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

//ioc container creation
var container = collection.CreateContainer();
var aModel1 = container.GetService<AModel>();
var bModel1 = container.GetService<IBModel>();

```

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
