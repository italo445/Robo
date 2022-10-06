using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.Pipes.Leitura
{
    public class Left : IPipe
    {

        public object Run(dynamic input)
        {
            //DataTable left = input.left;
            //DataTable right = input.right;
            
            //var result = from a in left.
            //             join b in right.AsEnumerable() on a.ItemArray[0] equals b.ItemArray[1] into gj
            //             from b in gj.DefaultIfEmpty()
            //             select new
            //             {
            //                 cpf = a.ItemArray[0],
            //                 nome = a.ItemArray[1],
            //                 cidade = a.ItemArray[2],
            //                 dataAdmissao = a.ItemArray[3],

            //                 execucao = b == null ? string.Empty : b.ItemArray[4] == null ? "" : b.ItemArray[4],

            //                 id = b == null ? string.Empty : b.ItemArray[0] == null ? "" : b.ItemArray[0]
            //             };

            return input;
        }
    }
}
