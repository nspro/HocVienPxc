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
    /// Interaction logic for frmThemUngSinh.xaml
    /// </summary>
    public partial class frmThemUngSinh : Window
    {
        public frmThemUngSinh()
        {
            InitializeComponent();
            LoadFirstState();
            HienThiGiaiDoan();
        }

        private void LoadFirstState()
        {
            text_TenThanh.Focus();
            btn_ThemUngSinh.IsEnabled = false;
        }

        private void TaiHinhDaiDien()
        {
            txt_Stick_TenThanh.Text = "Đang cập nhật";
        }


        //EVENT
        private void text_TenThanh_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txt_Stick_TenThanh.Text = text_TenThanh.Text.ToUpper();
        }

        private void text_HoVaTenLot_SelectionChanged(object sender, RoutedEventArgs e)
        {
            txt_Stick_HoTen.Text = text_HoVaTenLot.Text.ToUpper() + " " +  text_TenUngSinh.Text.ToUpper();
        }

        private void text_TenThanh_TextChanged(object sender, TextChangedEventArgs e)
        {
            btn_ThemUngSinh.IsEnabled = true;
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            img_Add_Avatar.Visibility = Visibility.Visible;
        }

        private void Canvas_MouseLeave(object sender, MouseEventArgs e)
        {
            img_Add_Avatar.Visibility = Visibility.Hidden;
        }

        private void img_Add_Avatar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            TaiHinhDaiDien();
        }

        private void HienThiGiaiDoan()
        {
            ObservableCollection<GiaiDoan> objGiaiDoan = GiaiDoan.HienThiTatCa();
            cmb_GiaiDoan.ItemsSource = objGiaiDoan;
            cmb_GiaiDoan.SelectedValue = GiaiDoan;
        }
        private void cmb_GiaiDoan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((cmb_GiaiDoan.SelectedItem as GiaiDoan).MaGiaiDoan.ToString());
        }
    }
}
