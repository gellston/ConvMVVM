using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Service.DialogService
{
    public interface IView
    {

        object Source { get; }
        object DataContext { get; }
        bool IsAlive { get; }

        object GetOwner();

    }
}
