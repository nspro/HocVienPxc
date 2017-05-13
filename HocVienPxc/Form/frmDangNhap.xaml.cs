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
using HocVienPxc.BOL;

namespace HocVienPxc.Form
{
    /// <summary>
    /// Interaction logic for frmDangNhap.xaml
    /// </summary>
    public partial class frmDangNhap : Window
    {
        public frmDangNhap()
        {
           // InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            //TaiKhoan obj = new TaiKhoan();
            //obj.Email = "ad.nspro@gmail.com";
            //obj.Password = "123";
            //obj.MaQuyenHan = 1;
            //obj.ThemTaiKhoan(obj);

            if (TaiKhoan.KiemTraDangNhap(txt_Email.Text, txt_Password.Text) != null)
            {
                MessageBox.Show("Dang nhap thanh cong");
            }
            else
            {
                MessageBox.Show("Dang Nhap That Bai");
            }

        }
    }
}
