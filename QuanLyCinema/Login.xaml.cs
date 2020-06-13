using BUS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QuanLyCinema
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnDangNhap_Click(object sender, RoutedEventArgs e)
        {
            string tk = txtTaiKhoan.Text;
            string mk = txtMatKhau.Password;
            if (tk == "")
            {
                MessageBox.Show("Vui lòng nhập Tài khoản");
            }
            else
            {
                if (mk == "")
                {
                    MessageBox.Show("Vui lòng nhập Mật khẩu");
                }
                else
                {
                    try
                    {
                        var validLogin = DangNhapNhanVienBUS.Login(tk, mk);
                        if (validLogin == true)
                        {
                          
                            //frmWait_for_GiaoDien welcome = new frmWait_for_GiaoDien();
                            //welcome.ShowDialog();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            // thêm sự kiện logout khi bấm nút logout bên frmGiaoDien,
                            // nếu không có thì khi bấm nút LogOut , frmLogin sẽ k xuất hiện
                            //frmGiaoDien.FormClosed += LogOut;
                            // Ẩn frmLogin khi đăng nhập thành công
                            // hàm Close sẽ đóng luôn frm -> đóng luôn chương trình
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tài khoản/Mật khẩu bạn đã nhập không chính xác! Vui lòng kiểm tra lại.",
                                "Lỗi đăng nhập");
                            
                            txtMatkhau.Password = "";
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Lỗi kết nối");
                    }
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

