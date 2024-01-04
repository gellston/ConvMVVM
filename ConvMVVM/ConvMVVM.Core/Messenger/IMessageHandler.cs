using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger
{
    public interface IMessageHandler
    {
        public object MessageType();
        public object ReceiverType();

        public void Callback(object message);
    }
}
