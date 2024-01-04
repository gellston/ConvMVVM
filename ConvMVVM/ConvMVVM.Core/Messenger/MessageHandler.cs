using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger
{
    public class MessageHandler<TReceiver, TMessage> : IMessageHandler where TReceiver : class
    {
        #region Private Property
        private readonly Action<TReceiver, TMessage> handler;
        private WeakReference<TReceiver> receiver;
        #endregion

        #region Constructor
        public MessageHandler(Action<TReceiver, TMessage> handler, TReceiver _receiver) { 
            this.handler = handler;
            receiver = new WeakReference<TReceiver>(_receiver);
        }
        #endregion

        #region Functions
        public void Callback(object message)
        {
            if(this.handler!=null)
            {
                TReceiver receiver;
                if(this.receiver.TryGetTarget(out receiver))
                {
                    this.handler(receiver, (TMessage)message);
                }
            }
        }

        public object MessageType()
        {
            return typeof(TMessage);
        }

        public object ReceiverType()
        {
            return typeof(TReceiver);
        }
        #endregion
    }
}
