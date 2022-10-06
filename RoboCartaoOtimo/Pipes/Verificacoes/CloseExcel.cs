using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Verificacoes
{
    public class CloseExcel : IPipe
    {

        public object Run(dynamic input)
        {
            DateTime now = DateTime.Now;
            var process = Process.GetProcesses();

            input.date = now;
            foreach (Process item in process)
            {
                if (item.ProcessName.ToUpper().Contains("EXCEL"))
                {
                    item.Kill();
                }
            }


       
            return input;
        }
    }
}
