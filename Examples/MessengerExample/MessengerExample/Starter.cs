using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerExample
{
    public class Starter
    {
        #region Static Functions
        [STAThread]
        static void Main(string[] args)
        {
            var _ = new App().Run();
        }
        #endregion
    }
}
