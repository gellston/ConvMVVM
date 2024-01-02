using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTest
{
    public class Starter
    {

        [STAThread]
        public static void Main(string[] args)
        {
            var app = new App();
            var _ = app.Run();
        }
    }
}
