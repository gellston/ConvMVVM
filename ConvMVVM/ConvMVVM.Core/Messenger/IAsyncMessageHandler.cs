using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger
{
    public interface IAsyncMessageHandler
    {
        public Type MessageType();
        public Type ReceiverType();

        public Task Callback(object message);

        public bool IsAlive();
    }
}
