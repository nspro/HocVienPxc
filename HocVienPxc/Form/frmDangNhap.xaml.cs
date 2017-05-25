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

        private void txt_Email_GotFocus(object sender, RoutedEventArgs e)
        {
           if(txt_Email.Text=="Địa chỉ Email")
            {
                txt_Email.Text = "";
                txt_Email.Opacity = 100;
            }
        }

        private void txt_Email_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Email.Text == null)
            {
                txt_Email.Text = "Địa chỉ email";
                txt_Email.Opacity = 50;
            }
        }

        private void pb_Pass_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Password.Visibility = Visibility.Hidden;
        }

        private void pb_Pass_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Password.Text == null)
            {
                txt_Password.Visibility = Visibility.Visible;
            }
        }
    }
}
