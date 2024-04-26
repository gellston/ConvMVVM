using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger
{
    public interface IMessageHandler
    {
        public Type MessageType();
        public Type ReceiverType();

        public void Callback(object message);

        public bool IsAlive();

        public bool Comapre(object _receiver);
    }
}
