using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFTest
{
    internal class Starter
    {

        [STAThread]
        static void Main(string[] args)
        {



            var _ = new App().Run();
        }
    }
}
