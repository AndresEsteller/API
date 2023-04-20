using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public static class Sql
    {
        private const string cadena = "Data Source=.; Initial Catalog=DBPersona; Integrated Security=true;";
        public static SqlConnection connection = new SqlConnection(cadena);
    }
}
