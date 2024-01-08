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
        private Dictionary<Type, List<IAsyncMessageHandler>> asyncReceivers = new Dictionary<Type, List<IAsyncMessageHandler>>();
        #endregion

        #region Public Functions
        public void Register<TReceiver, TMessage>(TReceiver receiver, Action<TReceiver, TMessage> callback) where TReceiver : class
        {
            var handler = new MessageHandler<TReceiver, TMessage>(callback, receiver);
            if(this.receivers.ContainsKey(typeof(TReceiver)) == false)
            {
                this.receivers[typeof(TReceiver)] = new List<IMessageHandler>();
            }
            this.receivers[typeof(TReceiver)].Add(handler);
        }

        public void Send<TMessage>(TMessage message)
        {
            List<IMessageHandler> messageHandlers = new List<IMessageHandler>();

            foreach(var receiver in this.receivers)
            {
                foreach(var handler in receiver.Value)
                {
                    if(handler.MessageType() == typeof(TMessage))
                    {
                        messageHandlers.Add(handler);
                    }
                }
            }
            foreach(var handler in messageHandlers)
                handler.Callback(message);
        }

        public void Send<TMessage, TReceiver>(TMessage message) where TReceiver : class
        {
            if(this.receivers.ContainsKey(typeof(TReceiver)) == false)
            {
                throw new InvalidOperationException("There is no proper receiver type");
            }

            var handlers = this.receivers[typeof(TReceiver)];

            foreach(var handler in handlers)
            {
                handler.Callback(message);
            }

            this.receivers[typeof(TReceiver)].RemoveAll((handler) =>
            {
                return handler.IsAlive();
            });
        }



        //Async
        public void AsyncRegister<TReceiver, TMessage>(TReceiver receiver, Func<TReceiver, TMessage, Task> callback) where TReceiver : class
        {
            var handler = new AsyncMessageHandler<TReceiver, TMessage>(callback, receiver);
            if (this.asyncReceivers.ContainsKey(typeof(TReceiver)) == false)
            {
                this.asyncReceivers[typeof(TReceiver)] = new List<IAsyncMessageHandler>();
            }
            this.asyncReceivers[typeof(TReceiver)].Add(handler);
        }

        public async Task AsyncSend<TMessage>(TMessage message)
        {
            List<IAsyncMessageHandler> messageHandlers = new List<IAsyncMessageHandler>();

            foreach (var receiver in this.asyncReceivers)
            {
                foreach (var handler in receiver.Value)
                {
                    if (handler.MessageType() == typeof(TMessage))
                    {
                        messageHandlers.Add(handler);
                    }
                }
            }
            foreach (var handler in messageHandlers)
                await handler.Callback(message);
        }

        public async Task AsyncSend<TMessage, TReceiver>(TMessage message) where TReceiver : Type
        {
            if (this.asyncReceivers.ContainsKey(typeof(TReceiver)) == false)
            {
                throw new InvalidOperationException("There is no proper receiver type");
            }

            var handlers = this.asyncReceivers[typeof(TReceiver)];

            foreach (var handler in handlers)
            {
                await handler.Callback(message);
            }

            this.asyncReceivers[typeof(TReceiver)].RemoveAll((handler) =>
            {
                return handler.IsAlive();
            });
        }

        #endregion



    }
}
