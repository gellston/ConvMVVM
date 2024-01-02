using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RelayCommandExample
{
    public class Starter
    {

        #region Static Function
        [STAThread]
        public static void Main(string[] args)
        {


            var _ = new App().Run();


        }
        #endregion
    }
}
