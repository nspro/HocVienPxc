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
using System.IO;
using HocVienPxc.BOL;
using Microsoft.Win32;

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
            HienThiHocKy();
            HienThiTinhTrang();
        }

        private void LoadFirstState()
        {
            text_TenThanh.Focus();
            btn_ThemUngSinh.IsEnabled = false;
        }
        OpenFileDialog op = new OpenFileDialog();
        private void TaiHinhDaiDien()
        {
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                img_Avatar.Source = new BitmapImage(new Uri(op.FileName));
            }
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
            cmb_GiaiDoan.DataContext = objGiaiDoan;
            ObservableCollection<GiaiDoan> obj = GiaiDoan.HienThiGiaiDoan(4);
            cmb_GiaiDoan.SelectedValue = obj[0].MaGiaiDoan;
        }
        private void HienThiLopTheoGiaiDoan(int MaGiaiDoan)
        {
            ObservableCollection<Lop> objLop = Lop.HienThiLopTheoGiaiDoan(MaGiaiDoan);
            cmb_Lop.DataContext = objLop;   
        }
        private void HienThiHocKy()
        {
            ObservableCollection<HocKy> objHocKy = HocKy.HienThiTatCa();
            cmb_Hocky.DataContext = objHocKy;
        }
        private void HienThiTinhTrang()
        {
            ObservableCollection<TinhTrang> objTinhTrang = TinhTrang.HienThiTatCa();
            cmb_TinhTrang.DataContext = objTinhTrang;
        }
        private void cmb_GiaiDoan_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //MessageBox.Show((cmb_GiaiDoan.SelectedItem as GiaiDoan).MaGiaiDoan.ToString());
            if ((cmb_GiaiDoan.SelectedItem as GiaiDoan).MaGiaiDoan.ToString() != "")
            {
                HienThiLopTheoGiaiDoan(int.Parse((cmb_GiaiDoan.SelectedItem as GiaiDoan).MaGiaiDoan.ToString()));
            }
        }

        private void cmb_Lop_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cmb_GiaiDoan_DropDownClosed(object sender, EventArgs e)
        {

        }

        private void btn_ThemUngSinh_Click(object sender, RoutedEventArgs e)
        {
            UngSinh obj = new UngSinh();
            obj.TenThanh = text_TenThanh.Text;
            obj.HoVaTenLot = text_HoVaTenLot.Text;
            obj.TenUngSinh = text_TenUngSinh.Text;
            obj.MaTinhTrang = int.Parse(cmb_TinhTrang.SelectedValue.ToString());
            obj.MaLop = int.Parse(cmb_Lop.SelectedValue.ToString());
            obj.NgaySinh = DateTime.Parse(text_NgaySinh.Text);
            obj.NoiSinh = text_NoiSinh.Text;
            obj.NguyenQuan = text_NguyenQuan.Text;
            obj.HoKhauThuongTru = text_HoKhauThuongTru.Text;
            obj.SoCMND = text_SoCMND.Text;
            obj.NgayCapCMND = DateTime.Parse(text_NgayCapCMND.Text);
            obj.NoiCapCMND = text_NoICapCMND.Text;
            obj.NgayRuaToi = DateTime.Parse(text_NgayRuaToi.Text);
            obj.GiaoXuRuaToi = text_GiaoXuRuaToi.Text;
            obj.NgayThemSuc = DateTime.Parse(text_NgayThemSuc.Text);
            obj.GiaoXuThemSuc = text_GiaoXuThemSuc.Text;
            obj.GiaoXu = text_GiaoXu.Text;
            obj.GiaoPhan = text_GiaoPhan.Text;
            obj.DienThoaiGiaoXu = text_DienThoaiGiaoXu.Text;
            obj.DienThoaiCaNhan = text_DienThoaiCaNhan.Text;
            ObservableCollection<UngSinh> objUngSinh = UngSinh.ThemUngSinh(obj);
            UploadAnhDaiDien(objUngSinh[0].MaUngSinh);
        }
        public void UploadAnhDaiDien(int MaUngSinh)
        {
            if (!Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + MaUngSinh.ToString()))
                Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + MaUngSinh.ToString());
            System.IO.File.Copy(op.FileName, System.AppDomain.CurrentDomain.BaseDirectory + "\\data\\" + MaUngSinh.ToString()+"\\"+"Avatar-"+MaUngSinh.ToString()+".jpg", true);
        }
    }
}
