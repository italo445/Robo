using System;
using System.Diagnostics;
using System.Dynamic;
namespace RoboCartaoOtimo
{
    class Program
    {
        public static string excecao = "";
        static void Main(string[] args)
        {
            
            var input = new ExpandoObject();
            Pipelines.Pipeline pipeline = new Pipelines.Pipeline();
            int contErro = 0;
            db.Processo process = new db.Processo();



            try
            {
                pipeline["CloseExcel"].Run(input);
                pipeline["VerificaInsercao"].Run(input);
                pipeline["FecharNavegador"].Run(input);
                pipeline["DeletarExtensao"].Run(input);
                pipeline["AbrirNavegador"].Run(input);
                pipeline["DataTable"].Run(input);


            }
            catch (Exception ex)
            {
                excecao = ex.Message;
                switch(excecao){
                    case var indisponivel when indisponivel.Contains("Elemento login nao disponivel"):
                        process.Indisponivel();
                        break;
                    case var dadosJaInseridos when dadosJaInseridos.Contains("Dados ja inseridos"):
                        process.dadosJaInseridos();
                        break;
                }




            }




        }
        
    }
}
