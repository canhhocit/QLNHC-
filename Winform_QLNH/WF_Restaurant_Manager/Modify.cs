using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace WF_Restaurant_Manager
{
    class Modify
    {
        public Modify()
        {
        }

        SqlCommand sqlcmd; // Dùng để thực hiện câu lệnh SQL (INSERT, UPDATE, DELETE)
        SqlDataReader dataReader; // Dùng để đọc dữ liệu từ bảng (SELECT)

        public List<TaiKhoan> taikhoan(string query)
        {
            List<TaiKhoan> TK = new List<TaiKhoan>();

            // Sử dụng using để đảm bảo tài nguyên được giải phóng
            using (SqlConnection sqlConnection = ConnectDB.GetSqlConnection())
            {
                try
                {
                    sqlConnection.Open(); // Mở kết nối
                    sqlcmd = new SqlCommand(query, sqlConnection); // Tạo lệnh SQL
                    dataReader = sqlcmd.ExecuteReader(); // Thực hiện đọc dữ liệu

                    while (dataReader.Read())
                    {
                        // Đọc dữ liệu từ mỗi dòng trả về
                        TK.Add(new TaiKhoan(
                            dataReader.GetString(0), // UserName
                            dataReader.GetString(1), // DisplayName
                            dataReader.GetString(2), // PassWord
                            dataReader.GetString(3)  // Email
                        ));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Lỗi truy vấn SQL: " + ex.Message);
                }
                finally
                {
                    // Đảm bảo đóng kết nối và giải phóng tài nguyên
                    if (dataReader != null)
                        dataReader.Close();
                    if (sqlConnection.State == System.Data.ConnectionState.Open)
                        sqlConnection.Close();
                }
            }

            return TK; // Trả về danh sách tài khoản
        }
    }
}
