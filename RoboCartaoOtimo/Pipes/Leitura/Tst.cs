using PipeliningLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System.IO;
using Aspose.Cells;
using ClosedXML.Excel;
using System.Threading;
using System.Data;

namespace RoboCartaoOtimo.Pipes.Leitura
{
    class Tst :IPipe
    {

        public object Run(dynamic input)
        {


            //tabela status cartao
            Workbook wb = new Workbook(@"C:\Users\Downloads\ExtracaoStatusCartao.xls");
            wb.Save(@"C:\Users\fiska\Downloads\ExtracaoStatusCartao.xlsx", SaveFormat.Xlsx);
            var xls = new XLWorkbook(@"C:\Users\fiska\Downloads\ExtracaoStatusCartao.xlsx");
            var planilha = xls.Worksheets.First(w => w.Name == "Sheet1");
            var totalLinhas = planilha.Rows().Count();

    

            //tabela saldo cartao
            Workbook wk = new Workbook(@"C:\Users\Downloads\ExtracaoSaldoCartao.xls");
            wk.Save(@"C:\Users\fiska\Downloads\ExtracaoSaldoCartao.xlsx", SaveFormat.Xlsx);
            var xls2 = new XLWorkbook(@"C:\Users\fiska\Downloads\ExtracaoSaldoCartao.xlsx");
            var planilha2 = xls2.Worksheets.First(k => k.Name == "Sheet1");
            var totalLinhas2 = planilha2.Rows().Count();


            string[] valor = new string[totalLinhas2];
            string[] id = new string[totalLinhas2];




            //for (int i = 2; i <= totalLinhas2; i++)
            //{
            //    id[i] = planilha2.Cell($"A{i}").Value.ToString();
            //    valor[i]= planilha2.Cell($"E{i}").Value.ToString();




            //}






            for (int i = 2; i <= totalLinhas - 1; i++)
            {

                var a = planilha.Cell($"A{i}").Value.ToString();
                var b = planilha.Cell($"B{i}").Value.ToString();
                var c = planilha.Cell($"C{i}").Value.ToString();
                var d = planilha.Cell($"D{i}").Value.ToString();
                var e = planilha.Cell($"E{i}").Value.ToString();
                var f = planilha.Cell($"F{i}").Value.ToString();
                var g = planilha.Cell($"G{i}").Value.ToString();


               

            }



            //for (int i=0; i<5; i++)
            //{

            //    for (int j=0; j<5; j++)
            //    {


            //        Console.WriteLine($"{i} - {j}"); ;


            //    }
            //}






            return input;
        }
    }
}
