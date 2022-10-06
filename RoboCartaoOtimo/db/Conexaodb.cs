using RoboCartaoOtimo.db;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RoboCartaoOtimo.db
{
    class Conexaodb
    {
        SqlConnection conn = new SqlConnection();
        AppSettings appSettings = new AppSettings();
        public Conexaodb()
        {
            conn.ConnectionString = appSettings.ReadSettings("Fiskal");
        }

        public SqlConnection ConectaComOBanco()
        {
            if (conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }

            return conn;
        }

        public void DesconectaComOBanco()
        {
            if (conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
        public void ExecuteQuerySemRetorno(string query)
        {
            //try
            //{
                ConectaComOBanco();
                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction("Consulta");
                cmd.Connection = conn;
                cmd.Transaction = transaction;                
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                transaction.Commit();
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Erro " + ex.Message);
            //}
        }

        public DataSet Select(string query)
        {
            DataSet ds = new DataSet();
            //try
            //{
                ConectaComOBanco();
                SqlCommand cmd = conn.CreateCommand();
                SqlTransaction transaction;
                transaction = conn.BeginTransaction("Consulta");
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                cmd.CommandText = query;
                cmd.ExecuteNonQuery();

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = cmd;
                da.Fill(ds);
                transaction.Commit();
            //}
            //catch (Exception ex)
            //{
            //    //MessageBox.Show("Erro " + ex.Message);
            //    Console.WriteLine(ex.Message);
            //}
            return ds;
        }
    }
}
