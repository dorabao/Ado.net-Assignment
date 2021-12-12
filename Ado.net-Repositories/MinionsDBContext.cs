using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace Ado.net_Repositories
{
    internal class MinionsDBContext
    {
        public string GetConnectionString()
        {
            ConfigurationBuilder builder = new ConfigurationBuilder();
            return builder.AddJsonFile("appSettings.json").Build().GetConnectionString("MinionsDB");
        }
    }
}
