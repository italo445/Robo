using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoboCartaoOtimo.db
{
    class AppSettings
    {
        public string ReadSettings(string connectionString)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath($@"{AppDomain.CurrentDomain.BaseDirectory}")
                .AddJsonFile("appsettings.json")
                .Build();

            var conn = configuration.GetConnectionString(connectionString);


            return conn;

        }
    }
}
