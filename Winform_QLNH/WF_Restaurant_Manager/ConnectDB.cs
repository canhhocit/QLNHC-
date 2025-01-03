using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace WF_Restaurant_Manager
{
    internal class ConnectDB
    {
        private static string connection = "Data Source=LAPTOP-JU0PE9R8\\SQLEXPRESS;Initial Catalog=CSDL_QLNH;Persist Security Info=True;User ID=sa;Password=123;";
        //trả về một đối tượng SqlConnection
        //Khi một phần khác của ứng dụng cần kết nối với cơ sở dữ liệu, họ chỉ cần gọi:
        ///SqlConnection connection = ConnectDB.GetSqlConnection();

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connection);
        }
    }
}
