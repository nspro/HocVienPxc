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
using System.Collections.ObjectModel;
using HocVienPxc.BOL;

namespace HocVienPxc.Form
{
    /// <summary>
    /// Interaction logic for frmUngSinh.xaml
    /// </summary>
    public partial class frmUngSinh : Window
    {
        public frmUngSinh()
        {
            InitializeComponent();
            ThongTinUngSinh();
        }
        public void ThongTinUngSinh()
        {
            ObservableCollection<UngSinh> lst = UngSinh.HienThiUngSinh(10);
            txt_Stick_HoTen.Text = lst[0].TenThanh;
            
        }
    }
}
