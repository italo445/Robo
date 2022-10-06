using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipelines
{
    public class Pipeline : PipelineGroup
    {
        public Pipeline() : base()
        {
            Pipeline("FecharNavegador")
                 .Pipe<RoboCartaoOtimo.Pipes.Navegador.Closed>()
                  ;
            Pipeline("AbrirNavegador")
                .Pipe<RoboCartaoOtimo.Pipes.Navegador.Launch>()
                .Pipe<RoboCartaoOtimo.Pipes.Navegador.AbrirPagina>()
                ;
            Pipeline("VerificaInsercao")
                .Pipe<RoboCartaoOtimo.Pipes.Verificacoes.VerificaInsercao>()
                ;
            Pipeline("DeletarExtensao")
                .Pipe<RoboCartaoOtimo.Pipes.Verificacoes.DeletarExtensao>()
                ;
            Pipeline("CloseExcel")
             .Pipe<RoboCartaoOtimo.Pipes.Verificacoes.CloseExcel>()
             ;
            Pipeline("DataTable")
              .Pipe<RoboCartaoOtimo.Pipes.Leitura.DataTable>()
              ;




        }

    }
}
