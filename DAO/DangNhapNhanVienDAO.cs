using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class SQLConnectionData
    {
        public static SqlConnection HamKetNoi()
        {
            SqlConnection connection = new SqlConnection("Data Source=(localdb)\\ProjectsV13;Initial Catalog=DOAN;Integrated Security=True");

            return connection;
        }
    }
    public class DangNhapNhanVienDAO
    {
        public static bool Login(string user, string pass)
        {
            using (var connection = SQLConnectionData.HamKetNoi() )
            {
                connection.Open();

                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT NV.HOTEN,NV.CHUCVU,NV.SDT,DN.TAIKHOAN,DN.MATKHAU FROM DANGNHAP_NHANVIEN DN INNER JOIN NHANVIEN NV ON DN.MANV=NV.MANV" +
                        " WHERE DN.TAIKHOAN=@user AND DN.MATKHAU=@pass";
                    // command.CommandText = "SELECT * FROM NGUOIDUNG WHERE TAIKHOAN=@user AND MATKHAU=@pass";
                    command.Parameters.AddWithValue("@user", user);
                    command.Parameters.AddWithValue("@pass", pass);
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows == true)
                    {
                        while (reader.Read())

                        {
                            //// UserLoginCache.MaNV = reader.GetString(0);
                            //DangNhapNhanVienDTO = reader.GetString(0);
                            //UserLoginCache.ChucVu = reader.GetString(1);
                            //UserLoginCache.SDT = reader.GetString(2);
                        }
                        return true;
                    }
                    else
                        return false;
                }
            }
        }
    }
}
