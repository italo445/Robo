using RoboCartaoOtimo.db;
using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Verificacoes
{
    public class VerificaInsercao : IPipe
    {
        public object Run(dynamic input)
        {
            Processo processo = new Processo();
            Conexaodb db = new Conexaodb();
            String result =
                @" select count(MATRICULA)  FROM [Fiskal_RPA].[RH].[Saldo]
                   WHERE FORNECEDOR = 'OTIMO'
                   ";
           
            DataSet resultado =    db.Select(result);

            

            var verifica = resultado.Tables[0].Rows[0][0].ToString();
           

            if (String.IsNullOrEmpty(verifica))
            {
                Console.WriteLine("continue");
                

            }
            else
            {
                processo.dadosJaInseridos();
                throw new ArgumentException("Dados ja inseridos");
                  
                       
            }

            return input;

        }

    }

    
}
