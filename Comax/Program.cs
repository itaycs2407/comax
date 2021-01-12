using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comax
{
    static class Program
    {
       
        static void Main()
        {
            Controller ctr = new Controller();
            ctr.start();
            //Application.Run(new Form1());
        }
    }
}
