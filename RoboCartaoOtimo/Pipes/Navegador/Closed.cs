using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Navegador
{
    public class Closed : IPipe
    {

        public object Run(dynamic input)
        {
            var process = Process.GetProcesses();
            foreach (Process item in process)
            {
                if (item.ProcessName.ToUpper().Contains("CHROME") || item.ProcessName.Contains("MSEDGE") || item.ProcessName.Contains("IEXPLORE"))
                {
                    item.Kill();
                }
            }
            return input;
        }

    }
}
