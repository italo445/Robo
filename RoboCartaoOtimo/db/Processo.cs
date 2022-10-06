using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.db
{
    class Processo
    {
        //ERRO SITE INDISPONIVEL = 1
        //ERRO DADOS JA INSERIDOS = 2
        //ERRO    





        public void Indisponivel()
        {
           
               
               var query = $@"INSERT INTO [Fiskal_RPA].[RH].[ProcessamentoCartaoOtimo](
                           NOMEPROCESSO, DATAINIEXECUCAO, DATAFIMEXECUCAO , STATUSEXECUCAO, CODEXECUCAO,ULTIMAEXECUCAO
                           )VALUES(
						   'SITEINDISPONIVEL',GETDATE(),GETDATE(),'ERRO','1','2022/03/03'
						   )";
            Conexaodb db = new Conexaodb();
            db.ExecuteQuerySemRetorno(query);
        }

        public void dadosJaInseridos()
        {
            
            var query = $@"INSERT INTO [Fiskal_RPA].[RH].[ProcessamentoCartaoOtimo](
                           NOMEPROCESSO, DATAINIEXECUCAO, DATAFIMEXECUCAO , STATUSEXECUCAO, CODEXECUCAO,ULTIMAEXECUCAO
                           )VALUES(
						   'DADOSJAINSERIDOS',GETDATE(),GETDATE(),'ERRO','2','2022/03/03'
						   )";
            Conexaodb db = new Conexaodb();
            db.ExecuteQuerySemRetorno(query);
            
        }







    }
}
