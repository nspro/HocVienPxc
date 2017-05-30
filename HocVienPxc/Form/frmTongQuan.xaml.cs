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

namespace HocVienPxc.Form
{
    /// <summary>
    /// Interaction logic for frmTongQuan.xaml
    /// </summary>
    public partial class frmTongQuan : Window
    {
        public frmTongQuan()
        {
            InitializeComponent();
        }

        ////Đăng xuất
        private void stp_Menu_DangXuat_MouseMove(object sender, MouseEventArgs e)
        {
            stp_Menu_DangXuat.Background = Brushes.DimGray;
        }

        private void stp_Menu_DangXuat_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            stp_Menu_DangXuat.Background = Brushes.DarkSlateGray;
        }

        private void stp_Menu_DangXuat_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            stp_Menu_DangXuat.Background = Brushes.Transparent;
        }

        private void stp_Menu_DangXuat_MouseLeave(object sender, MouseEventArgs e)
        {
            stp_Menu_DangXuat.Background = Brushes.Transparent;
        }
    }
}
