using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Diag = System.Diagnostics;

namespace ProjectArcaneGrasp
{
    public class Debug
    {
        
        public static void Log(string message)
        {        
            Diag.Debug.WriteLine(message);
        }
    }
}
