using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KetNoi
{
    class ConnectionDB
    {
        public SqlConnection getConnect(string tenMay, string tenCsdl)
        {
            return new SqlConnection("Data Source=" + tenMay + ";Initial Catalog=" + tenCsdl + ";Integrated Security=True");
        }
    }
}
