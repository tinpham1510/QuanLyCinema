using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DangNhapNhanVienBUS
    {
        public static bool Login(string taikhoan,string matkhau)
        {
            return DangNhapNhanVienDAO.Login(taikhoan,matkhau);
        }
    }
}
