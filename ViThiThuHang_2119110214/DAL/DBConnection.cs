using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ViThiThuHang_2119110214.DAL
{
    public class DBConnection
    {
        public DBConnection() { }
        public SqlConnection CreateConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = @"Data Source=DESKTOP-VKINOHI\SQLEXPRESS;Initial Catalog=HR2 ;Integrated Security=True";
            return conn;
        }
    }
}
