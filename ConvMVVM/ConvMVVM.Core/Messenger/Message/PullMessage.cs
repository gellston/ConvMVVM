using System;
using System.Collections.Generic;
using System.Text;

namespace ConvMVVM.Core.Messenger.Message
{
    public class PullMessage<TMessage, TResult> where TResult : class
                                                where TMessage : class
    {
        #region Constructor
        public PullMessage() { 
        
        
        }
        #endregion

        #region Property
        public string Name { get; set; } = "";
        public TMessage Message { get; set; }
        public TResult Result { get; set; }
        #endregion

        #region Functions
        public void Response(TResult result)
        {
            this.Result = result;
        }
        #endregion
    }
}
