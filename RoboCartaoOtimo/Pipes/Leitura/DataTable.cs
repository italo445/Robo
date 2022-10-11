using PipeliningLibrary;
using System.Linq;
using System;
using System.IO;
using Aspose.Cells;
using ClosedXML.Excel;
using System.Data;
using System.Diagnostics;
using System.Text;

namespace RoboCartaoOtimo.Pipes.Leitura
{
    class DataTable : IPipe
    {

        public object Run(dynamic input)
        {




            //EXTRACAO STATUS CARTAO
            FileStream fstream = new FileStream(@"C:\Users\Downloads\ExtracaoStatusCartao.xls", FileMode.Open);
            Workbook workbook = new Workbook(fstream);
            Worksheet worksheet = workbook.Worksheets[0];
            var totalLinhas = worksheet.Cells.Rows.Count;
            System.Data.DataTable dataStatusTable = worksheet.Cells.ExportDataTable(3, 0, totalLinhas - 4, 7, false);




            //foreach (DataRow dataRow in dataStatusTable.Rows)
            //{

            //    foreach (var item in dataRow.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}




            //EXTRACAO SALDO CARTAO
            FileStream fs = new FileStream(@"C:\Users\Downloads\ExtracaoSaldoCartao.xls", FileMode.Open);
            Workbook work = new Workbook(fs);
            Worksheet wt = work.Worksheets[0];
            var tot = wt.Cells.Rows.Count;
            System.Data.DataTable DataSaldoTable = wt.Cells.ExportDataTable(3, 0, tot - 4, 5, new ExportTableOptions()
            {CheckMixedValueType = false, ExportColumnName = false, ExportAsString = true }
            );


            //foreach (DataRow dw in DataSaldoTable.Rows)
            //{

            //    foreach (var item in dw.ItemArray)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}

            System.Data.DataTable table = new System.Data.DataTable();


            table.Columns.Add("DATAEXTRACAO");
            table.Columns.Add("FORNECEDOR");
            table.Columns.Add("MATRICULA");
            table.Columns.Add("SALDO");
            table.Columns.Add("NOME");
            table.Columns.Add("CARTAO");
            table.Columns.Add("MES");
            table.Columns.Add("CIDADE");
            table.Columns.Add("STATUSCARTAO");




            var result = from rowLeft in dataStatusTable.AsEnumerable()
                         join rowRight in DataSaldoTable.AsEnumerable() on rowLeft.ItemArray[0] equals rowRight.ItemArray[0] into gj
                         from rowRight in gj.DefaultIfEmpty()
                         select new
                         {
                             dataExtracao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                             fornecedor = "Otimo",
                             matricula = rowLeft.ItemArray[0],
                             saldo = rowRight == null ? string.Empty : rowRight.ItemArray[4] == null ? "" : rowRight.ItemArray[4],
                             nome = rowLeft.ItemArray[1],
                             cartao = rowLeft.ItemArray[3],
                             mes = DateTime.Now.ToString("MM"),
                             cidade = "BH",
                             statusCartao = rowLeft.ItemArray[6]
                         };


            foreach (var item in result)
            {
                table.Rows.Add(item.dataExtracao, item.fornecedor, item.matricula, item.saldo, item.nome, item.cartao, item.mes, item.cidade, item.statusCartao);
            }




            StringBuilder builder = new StringBuilder();
            string query = null;
            
            query = @$"INSERT INTO Fiskal_RPA.RH.Saldo 
                              (DATAEXTRACAO, FORNECEDOR, MATRICULA, SALDO, NOME, CARTAO, MES, CIDADE, STATUSCARTAO) 
                              VALUES ";


           
            
            var resto = table.Rows.Count % 999;
            var inteiro = Math.Floor((double)table.Rows.Count/999);
            int contador=1;
            int contador2 = 0;
            
            
            foreach (DataRow row in table.Rows)
            {
                 if (inteiro > 0 && contador2 < inteiro)
                {
                    if (contador == 999)
                    {
                        var saldo = String.IsNullOrEmpty(row.ItemArray[3].ToString()) || row.ItemArray[3].ToString() == "" || row.ItemArray[3].ToString() == "Não Atualizado" ? "0" : row.ItemArray[3].ToString();
                        builder.Append($"(convert(datetime,'{row.ItemArray[0]}'), '{row.ItemArray[1]}', '{row.ItemArray[2]}', {saldo}, '{row.ItemArray[4]}', '{row.ItemArray[5]}', '{row.ItemArray[6]}', '{row.ItemArray[7]}', '{row.ItemArray[8]}')\n");
                        db.ConexaoFiskal conexaoFiskal = new db.ConexaoFiskal();
                        conexaoFiskal.ExecuteQuerySemRetorno(query + " " + builder.ToString());
                        builder.Clear();
                        contador = 1;
                        contador2++;
                    }
                    else
                    {
                        var saldo = String.IsNullOrEmpty(row.ItemArray[3].ToString()) || row.ItemArray[3].ToString() == "" || row.ItemArray[3].ToString() == "Não Atualizado" ? "0" : row.ItemArray[3].ToString();
                        builder.Append($"(convert(datetime,'{row.ItemArray[0]}'), '{row.ItemArray[1]}', '{row.ItemArray[2]}', {saldo}, '{row.ItemArray[4]}', '{row.ItemArray[5]}', '{row.ItemArray[6]}', '{row.ItemArray[7]}', '{row.ItemArray[8]}'),\n");
                        contador++;
                    }
                }
                else
                {
                    if (contador == resto)
                    {
                        var saldo = String.IsNullOrEmpty(row.ItemArray[3].ToString()) || row.ItemArray[3].ToString() == "" || row.ItemArray[3].ToString() == "Não Atualizado" ? "0" : row.ItemArray[3].ToString();
                        builder.Append($"(convert(datetime,'{row.ItemArray[0]}'), '{row.ItemArray[1]}', '{row.ItemArray[2]}', {saldo}, '{row.ItemArray[4]}', '{row.ItemArray[5]}', '{row.ItemArray[6]}', '{row.ItemArray[7]}', '{row.ItemArray[8]}')\n");
                        db.ConexaoFiskal conexaoFiskal = new db.ConexaoFiskal();
                        conexaoFiskal.ExecuteQuerySemRetorno(query + " " + builder.ToString());
                        builder.Clear();
                        contador = 1;
                    }
                    else
                    {
                        var saldo = String.IsNullOrEmpty(row.ItemArray[3].ToString()) || row.ItemArray[3].ToString() == "" || row.ItemArray[3].ToString() == "Não Atualizado" ? "0" : row.ItemArray[3].ToString();
                        builder.Append($"(convert(datetime,'{row.ItemArray[0]}'), '{row.ItemArray[1]}', '{row.ItemArray[2]}', {saldo}, '{row.ItemArray[4]}', '{row.ItemArray[5]}', '{row.ItemArray[6]}', '{row.ItemArray[7]}', '{row.ItemArray[8]}'),\n");
                        contador++;
                    }
                }
            }


           

            return input;
        }


    }
}
