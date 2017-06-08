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
    /// Interaction logic for frmThemLop.xaml
    /// </summary>
    public partial class frmThemLop : Window
    {
        public frmThemLop()
        {
            InitializeComponent();
            loadGiaiDoan();
            loadHocKy();
        }

        private void btn_Them_Click(object sender, RoutedEventArgs e)
        {
            Lop obj = new Lop();
            obj.MaGiaiDoan = int.Parse(cb_MaGiaiDoan.SelectedValue.ToString());
            obj.MaHocKy = int.Parse(cb_MaHocKy.SelectedValue.ToString());
            obj.TenLop = txt_TenLop.Text;
            obj.ThemLop(obj);
            MessageBox.Show("Thêm lớp thành công!");
            this.Close();
        }
        private void loadGiaiDoan()
        {
            ObservableCollection<GiaiDoan> obj = GiaiDoan.HienThiTatCa();
            cb_MaGiaiDoan.DataContext = obj;
        }
        private void loadHocKy()
        {
            ObservableCollection<HocKy> obj = HocKy.HienThiTatCa();
            cb_MaHocKy.DataContext = obj;
        }
    }
}
