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
using HocVienPxc.Form;

namespace HocVienPxc.Form
{
    /// <summary>
    /// Interaction logic for frmMain.xaml
    /// </summary>
    public partial class frmMain : Window
    {
        public frmMain()
        {
            InitializeComponent();
            ShowDangNhap();

        }
        private void ShowDangNhap()
        {
            fDangNhap.Content = new frmLogin();
        }
        private void frmUngSinh()
        {

        }
    }
}
