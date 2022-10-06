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
    class ConexaoFiskal : Conexaodb
    {
        
        SqlConnection conn = new SqlConnection();
        AppSettings appSettings = new AppSettings();
        
        public ConexaoFiskal()
        {
            
            conn.ConnectionString = appSettings.ReadSettings("Fiskal");
        }
    }
}
