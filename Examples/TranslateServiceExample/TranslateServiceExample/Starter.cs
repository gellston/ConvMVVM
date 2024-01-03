using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TranslateServiceExample
{
    public class Starter
    {

        [STAThread]
        public static void Main(string[] args)
        {
            var _ = new App().Run();
        }
    }
}
