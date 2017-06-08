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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using HocVienPxc.BOL;

namespace HocVienPxc.Form
{
    /// <summary>
    /// Interaction logic for frmLogin.xaml
    /// </summary>
    public partial class frmLogin : Page
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btn_DangNhap_Click(object sender, RoutedEventArgs e)
        {
            if (txt_Email.Text != "" && txt_Password.Password.ToString() != "")
            {
                ObservableCollection<TaiKhoan> obj = TaiKhoan.KiemTraDangNhap(txt_Email.Text, txt_Password.Password.ToString());
                if (obj.Count == 1)
                {
                    MessageBox.Show("Đăng nhập thành công!");
                }
            }
        }
    }
}
