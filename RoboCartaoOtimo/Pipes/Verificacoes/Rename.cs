using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Navegador
{
    class Rename : IPipe
    {

        public object Run(dynamic input)
        {
            
            


            if (input.cont==1) {
                string[] arquivos = Directory.GetFiles(@"C:\Users\Downloads", "*.xls");
                string newFile = @"C:\Users\aec.uipath3\Downloads\ExtracaoSaldoCartao.xls";
                string teste = "";
                foreach (var arq in arquivos)
                {
                    Console.WriteLine(arq);
                    teste = arq;

                }

                File.Copy(teste, newFile);

                input.cont++;

            }


            else
            {
                string[] arquivos = Directory.GetFiles(@"C:\Users\Downloads", "*.xls");
                string newFile = @"C:\Users\aec.uipath3\Downloads\ExtracaoStatusCartao.xls";
                string teste = "";

                foreach (var arq in arquivos)
                {
                    Console.WriteLine(arq);
                    teste = arq;

                }

                File.Copy(teste, newFile);

                
            }



            return input;
        }



    }
}
