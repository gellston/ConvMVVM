using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger
{
    public class WeakReferenceMessenger
    {
        #region Static Property
        public static WeakReferenceMessenger Default { get; } = new WeakReferenceMessenger();
        #endregion

        #region Private Property
        private Dictionary<Type, List<IMessageHandler>> receivers = new Dictionary<Type, List<IMessageHandler>>();
        #endregion

        #region Public Functions
        public void Register<TReceiver, TMessage>(TReceiver receiver, Action<TReceiver, TMessage> callback) where TReceiver : class
        {
            var handler = new MessageHandler<TReceiver, TMessage>(callback, receiver);
            if(receivers.ContainsKey(typeof(TReceiver)) == false)
            {
                receivers[typeof(TReceiver)] = new List<IMessageHandler>();
            }
            receivers[typeof(TMessage)].Add(handler);
        }

        
        #endregion
    }
}
