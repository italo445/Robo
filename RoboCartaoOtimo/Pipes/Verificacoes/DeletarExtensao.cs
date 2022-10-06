using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Verificacoes
{
    class DeletarExtensao : IPipe
    {
        public object Run(dynamic input)
       {

            
            //??LEMBRAR DE ALTERAR CAMINHO??
            string[] arquivos = Directory.GetFiles(@"C:\Users\aec.uipath3\Downloads", "*.xls");
       
            foreach (var arq in arquivos)
            {
                Console.WriteLine(arq);
                File.Delete(arq);
                
            }

           

            

            return input;
        }

    }
}
