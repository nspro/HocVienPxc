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
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Windows.Markup;

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

            //load font
            LoadFontAndSize();
            ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
            HienThiThongTinChiTiet(obj);
            HienThiLichSuOnGoi(obj);
            HienThiCaTinh(obj);
            HienThiYThucDoiTu(obj);
            HienThiHocTapNangKhieu(obj);
            HienThiNhungDiemCoGangThayDoi(obj);
            HienThiNhanDinhOnGoi(obj);
            HienThiSucKhoe(obj);
            HienThiNhanDinhDiem(obj);
        }

        private void LoadFontAndSize()
        {
            cmb_LichSuOnGoi_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_LichSuOnGoi_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_CaTinh_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_CaTinh_FontSize.ItemsSource = new List<double>() {14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_YThucDoiTu_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_YThucDoiTu_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_HocTapNangKhieu_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_HocTapNangKhieu_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_CanThayDoi_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_CanThayDoi_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_NhanDinhOnGoi_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_NhanDinhOnGoi_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_SucKhoe_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_SucKhoe_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };

            cmb_NhanDinhDiem_FontList.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_NhanDinhDiem_FontSize.ItemsSource = new List<double>() { 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
        }

        //START LỊCH SỬ ƠN GỌI
        private void rtb_LichSuOnGoi_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_LichSuOnGoi_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_LichSuOnGoi_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_LichSuOnGoi_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_LichSuOnGoi_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_LichSuOnGoi_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_LichSuOnGoi_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_LichSuOnGoi_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_LichSuOnGoi_FontList.SelectedItem = temp;
            temp = rtb_LichSuOnGoi_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_LichSuOnGoi_FontSize.Text = temp.ToString();
        }

        private void cmb_LichSuOnGoi_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_LichSuOnGoi_FontList.SelectedItem != null)
                rtb_LichSuOnGoi_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_LichSuOnGoi_FontList.SelectedItem);
        }

        private void cmb_LichSuOnGoi_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_LichSuOnGoi_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_LichSuOnGoi_FontSize.Text);
            btn_LichSuOnGoi_Luu.IsEnabled = true;
        }
        private void btn_HanhTrinhOnGoi_Mo_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Rich Text Format (*.rtf)|*.rtf|All files (*.*)|*.*";
            if (dlg.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(dlg.FileName, FileMode.Open);
                TextRange range = new TextRange(rtb_LichSuOnGoi_Editor.Document.ContentStart, rtb_LichSuOnGoi_Editor.Document.ContentEnd);
                range.Load(fileStream, DataFormats.Rtf);
            }
        }

        //END LỊCH SỬ ƠN GỌI


        //START CA TINH
        private void rtb_CaTinh_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_CaTinh_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_CaTinh_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_CaTinh_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_CaTinh_FontList.SelectedItem = temp;
            temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_CaTinh_FontSize.Text = temp.ToString();
        }

        private void cmb_CaTinh_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_CaTinh_FontList.SelectedItem != null)
                rtb_CaTinh_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_CaTinh_FontList.SelectedItem);
        }

        private void cmb_CaTinh_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_CaTinh_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_CaTinh_FontSize.Text);
            btn_CaTinh_Luu.IsEnabled = true;
        }

        //END CA TINH

        //START Y THUC DOI TU
        private void rtb_YThucDoiTu_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_YThucDoiTu_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_YThucDoiTu_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_YThucDoiTu_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_YThucDoiTu_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_YThucDoiTu_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_YThucDoiTu_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_YThucDoiTu_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_YThucDoiTu_FontList.SelectedItem = temp;
            temp = rtb_YThucDoiTu_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_YThucDoiTu_FontSize.Text = temp.ToString();
        }

        private void cmb_YThucDoiTu_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_YThucDoiTu_FontList.SelectedItem != null)
                rtb_YThucDoiTu_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_YThucDoiTu_FontList.SelectedItem);
        }

        private void cmb_YThucDoiTu_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_YThucDoiTu_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_YThucDoiTu_FontSize.Text);
            btn_YThucDoiTu_Luu.IsEnabled = true;
        }
        //END Y THUC DOI TU

        //START HOC TAP NANG KHIEU
        private void rtb_HocTapNangKhieu_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_HocTapNangKhieu_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_HocTapNangKhieu_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_HocTapNangKhieu_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_HocTapNangKhieu_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_HocTapNangKhieu_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_HocTapNangKhieu_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_HocTapNangKhieu_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_HocTapNangKhieu_FontList.SelectedItem = temp;
            temp = rtb_HocTapNangKhieu_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_HocTapNangKhieu_FontSize.Text = temp.ToString();
        }

        private void cmb_HocTapNangKhieu_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_HocTapNangKhieu_FontList.SelectedItem != null)
                rtb_HocTapNangKhieu_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_HocTapNangKhieu_FontList.SelectedItem);
        }

        private void cmb_HocTapNangKhieu_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_HocTapNangKhieu_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_HocTapNangKhieu_FontSize.Text);
            btn_HocTapNangKhieu_Luu.IsEnabled = true;
        }
        //END HOC TAP NANG KHIEU

        //START CAN THAY DOI
        private void rtb_CanThayDoi_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_CanThayDoi_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_CanThayDoi_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_CanThayDoi_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_CanThayDoi_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_CanThayDoi_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_CanThayDoi_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_CanThayDoi_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_CanThayDoi_FontList.SelectedItem = temp;
            temp = rtb_CanThayDoi_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_CanThayDoi_FontSize.Text = temp.ToString();
        }

        private void cmb_CanThayDoi_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_CanThayDoi_FontList.SelectedItem != null)
                rtb_CanThayDoi_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_CanThayDoi_FontList.SelectedItem);
        }

        private void cmb_CanThayDoi_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_CanThayDoi_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_CanThayDoi_FontSize.Text);
            btn_CanThayDoi_Luu.IsEnabled = true;
        }
        //END CAN THAY DOI

        //START NHẬN ĐỊNH ƠN GỌI
        private void rtb_NhanDinhOnGoi_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_NhanDinhOnGoi_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_NhanDinhOnGoi_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_NhanDinhOnGoi_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_NhanDinhOnGoi_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_NhanDinhOnGoi_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_NhanDinhOnGoi_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_NhanDinhOnGoi_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_NhanDinhOnGoi_FontList.SelectedItem = temp;
            temp = rtb_NhanDinhOnGoi_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_NhanDinhOnGoi_FontSize.Text = temp.ToString();
        }

        private void cmb_NhanDinhOnGoi_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_NhanDinhOnGoi_FontList.SelectedItem != null)
                rtb_NhanDinhOnGoi_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_NhanDinhOnGoi_FontList.SelectedItem);
        }

        private void cmb_NhanDinhOnGoi_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                rtb_NhanDinhOnGoi_Editor.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, cmb_NhanDinhOnGoi_FontSize.Text);

            }
            catch (Exception)
            {

                throw;
            }
            btn_NhanDinhOnGoi_Luu.IsEnabled = true;
        }
        //END NHẬN ĐỊNH ƠN GỌI

        //START SỨC KHỎE
        private void rtb_SucKhoe_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_SucKhoe_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_SucKhoe_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_SucKhoe_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_SucKhoe_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_SucKhoe_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_SucKhoe_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_SucKhoe_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_SucKhoe_FontList.SelectedItem = temp;
            temp = rtb_SucKhoe_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_SucKhoe_FontSize.Text = temp.ToString();
        }

        private void cmb_SucKhoe_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_SucKhoe_FontList.SelectedItem != null)
                rtb_SucKhoe_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_SucKhoe_FontList.SelectedItem);
        }

        private void cmb_SucKhoe_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_SucKhoe_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_SucKhoe_FontSize.Text);
            btn_SucKhoe_Luu.IsEnabled = true;
        }
        //END SỨC KHỎE


        //START ĐIỂM
        private void rtb_NhanDinhDiem_Editor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = rtb_NhanDinhDiem_Editor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btn_NhanDinhDiem_Bold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = rtb_NhanDinhDiem_Editor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btn_NhanDinhDiem_Italic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = rtb_NhanDinhDiem_Editor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btn_NhanDinhDiem_Undeline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));

            temp = rtb_NhanDinhDiem_Editor.Selection.GetPropertyValue(Inline.FontFamilyProperty);
            cmb_NhanDinhDiem_FontList.SelectedItem = temp;
            temp = rtb_NhanDinhDiem_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_NhanDinhDiem_FontSize.Text = temp.ToString();
        }

        private void cmb_NhanDinhDiem_FontList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmb_NhanDinhDiem_FontList.SelectedItem != null)
                rtb_NhanDinhDiem_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmb_NhanDinhDiem_FontList.SelectedItem);
        }

        private void cmb_NhanDinhDiem_TextChanged(object sender, RoutedEventArgs e)
        {
            rtb_NhanDinhDiem_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_NhanDinhDiem_FontSize.Text);
            btn_NhanDinhDiem_Luu.IsEnabled = true;
        }

    
        //END ĐIỂM


        public void HienThiThongTinChiTiet(ObservableCollection<UngSinh> obj)
        {
            txt_Stick_TenThanh.Text = obj[0].TenThanh;
            txt_Stick_HoTen.Text = obj[0].HoVaTenLot + " " + obj[0].TenUngSinh;
            txt_Stick_NgaySinh.Text = obj[0].NgaySinh.ToShortDateString();
            txt_Stick_GiaoXu.Text = obj[0].GiaoXu;
            txt_Stick_GiaoPhan.Text = obj[0].GiaoPhan;

            //Show Ten Lop
            ObservableCollection<Lop> objLop = Lop.HienThiLop(obj[0].MaLop);
            txt_Stick_Lop.Text = objLop[0].TenLop;
            //End Show Ten Lop

            //Show Ten TinhTrang
            ObservableCollection<TinhTrang> objTinhTrang = TinhTrang.HienThiTinhTrang(obj[0].MaTinhTrang);
            txt_Stick_TinhTrang.Text = objTinhTrang[0].TenTinhTrang;
            //End Show Ten TinhTrang

            //Show Ten HocKy
            txt_Stick_HocKy.Text = "Chua sua";
            //End Show Ten HocKy

            text_TenThanh.Text = obj[0].TenThanh;
            text_HoVaTenLot.Text = obj[0].HoVaTenLot;
            text_TenUngSinh.Text = obj[0].TenUngSinh;
            text_NgaySinh.Text = obj[0].NgaySinh.ToShortDateString();
            text_NoiSinh.Text = obj[0].NoiSinh;
            text_NguyenQuan.Text = obj[0].NguyenQuan;
            text_HoKhauThuongTru.Text = obj[0].HoKhauThuongTru;
            text_SoCMND.Text = obj[0].SoCMND;
            text_NgayCapCMND.Text = obj[0].NgayCapCMND.ToShortDateString();
            text_NoiCapCMND.Text = obj[0].NoiCapCMND;
            text_NgayRuaToi.Text = obj[0].NgayRuaToi.ToShortDateString();
            text_GiaoXuRuaToi.Text = obj[0].GiaoXuRuaToi;
            text_NgayThemSuc.Text = obj[0].NgayThemSuc.ToShortDateString();
            text_GiaoXuThemSuc.Text = obj[0].GiaoXuThemSuc;
            text_GiaoXu.Text = obj[0].GiaoXu;
            text_GiaoPhan.Text = obj[0].GiaoPhan;
            text_DienThoaiGiaoXu.Text = obj[0].DienThoaiGiaoXu;
            text_DienThoaiCaNhan.Text = obj[0].DienThoaiCaNhan;
        }

        private static string GetRTF(RichTextBox rt)
        {
            TextRange range = new TextRange(rt.Document.ContentStart, rt.Document.ContentEnd);
            MemoryStream stream = new MemoryStream();
            range.Save(stream, DataFormats.Xaml);
            string xamlText = Encoding.UTF8.GetString(stream.ToArray());
            return xamlText;
        }

        private static FlowDocument SetRTF(string xamlString)
        {
            if (xamlString != "")
            {
                StringReader stringReader = new StringReader(xamlString);
                XmlReader xmlReader = XmlReader.Create(stringReader);
                Section sec = XamlReader.Load(xmlReader) as Section;
                FlowDocument doc = new FlowDocument();
                while (sec.Blocks.Count > 0)
                    doc.Blocks.Add(sec.Blocks.FirstBlock);
                return doc;
            }
            else { return null; }
        }

        public void HienThiLichSuOnGoi(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objLichSu = UngSinh.HienThiUngSinh(11);
            try { rtb_LichSuOnGoi_Editor.Document = SetRTF(obj[0].LichSuOnGoi); }
            catch { }
                     
        }

        private void btn_LichSuOnGoi_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string LichSuOnGoi = GetRTF(rtb_LichSuOnGoi_Editor);
                UngSinh objLichSu = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objLichSu.MaUngSinh = obj[0].MaUngSinh;
                objLichSu.LichSuOnGoi = LichSuOnGoi;
                objLichSu.CapNhatLichSuOnGoi(objLichSu);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
            
        }

        public void HienThiCaTinh(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objCaTinh = UngSinh.HienThiUngSinh(11);
            try { rtb_CaTinh_Editor.Document = SetRTF(obj[0].CaTinh); }
            catch { }
        }
        private void btn_CaTinh_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string CaTinh = GetRTF(rtb_CaTinh_Editor);
                UngSinh objCaTinh = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objCaTinh.MaUngSinh = obj[0].MaUngSinh;
                objCaTinh.CaTinh = CaTinh;
                objCaTinh.CapNhatCaTinh(objCaTinh);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiYThucDoiTu(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objYThucDoiTu = UngSinh.HienThiUngSinh(11);
            try { rtb_YThucDoiTu_Editor.Document = SetRTF(obj[0].YThucDoiTu); }
            catch { }
        }

        private void btn_YThucDoiTu_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string YThucDoiTu = GetRTF(rtb_YThucDoiTu_Editor);
                UngSinh objYThucDoiTu = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objYThucDoiTu.MaUngSinh = obj[0].MaUngSinh;
                objYThucDoiTu.YThucDoiTu = YThucDoiTu;
                objYThucDoiTu.CapNhatYThucDoiTu(objYThucDoiTu);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiHocTapNangKhieu(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objHocTapNangKhieu = UngSinh.HienThiUngSinh(11);
            try { rtb_HocTapNangKhieu_Editor.Document = SetRTF(obj[0].HocTapNangKhieu); }
            catch { }
        }

        private void btn_HocTapNangKhieu_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string HocTapNangKhieu = GetRTF(rtb_HocTapNangKhieu_Editor);
                UngSinh objHocTapNangKhieu = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objHocTapNangKhieu.MaUngSinh = obj[0].MaUngSinh;
                objHocTapNangKhieu.HocTapNangKhieu = HocTapNangKhieu;
                objHocTapNangKhieu.CapNhatHocTapNangKhieu(objHocTapNangKhieu);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiNhungDiemCoGangThayDoi(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objNhungDiemCoGangThayDoi = UngSinh.HienThiUngSinh(11);
            try { rtb_CanThayDoi_Editor.Document = SetRTF(obj[0].NhungDiemCoGangThayDoi); }
            catch { }
        }

        private void btn_CanThayDoi_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NhungDiemCoGangThayDoi = GetRTF(rtb_CanThayDoi_Editor);
                UngSinh objNhungDiemCoGangThayDoi = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objNhungDiemCoGangThayDoi.MaUngSinh = obj[0].MaUngSinh;
                objNhungDiemCoGangThayDoi.NhungDiemCoGangThayDoi = NhungDiemCoGangThayDoi;
                objNhungDiemCoGangThayDoi.CapNhatNhungDiemCoGangThayDoi(objNhungDiemCoGangThayDoi);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiNhanDinhOnGoi(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objNhanDinhOnGoi = UngSinh.HienThiUngSinh(11);
            try { rtb_NhanDinhOnGoi_Editor.Document = SetRTF(obj[0].NhanDinhOnGoi); }
            catch { }
        }

        private void btn_NhanDinhOnGoi_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NhanDinhOnGoi = GetRTF(rtb_NhanDinhOnGoi_Editor);
                UngSinh objNhanDinhOnGoi = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objNhanDinhOnGoi.MaUngSinh = obj[0].MaUngSinh;
                objNhanDinhOnGoi.NhanDinhOnGoi = NhanDinhOnGoi;
                objNhanDinhOnGoi.CapNhatNhanDinhOnGoi(objNhanDinhOnGoi);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiSucKhoe(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objSucKhoe = UngSinh.HienThiUngSinh(11);
            try { rtb_SucKhoe_Editor.Document = SetRTF(obj[0].SucKhoe); }
            catch { }
        }

        private void btn_SucKhoe_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string SucKhoe = GetRTF(rtb_SucKhoe_Editor);
                UngSinh objSucKhoe = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objSucKhoe.MaUngSinh = obj[0].MaUngSinh;
                objSucKhoe.SucKhoe = SucKhoe;
                objSucKhoe.CapNhatSucKhoe(objSucKhoe);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
        public void HienThiNhanDinhDiem(ObservableCollection<UngSinh> obj)
        {
            ObservableCollection<UngSinh> objNhanDinhDiem = UngSinh.HienThiUngSinh(11);
            try { rtb_NhanDinhDiem_Editor.Document = SetRTF(obj[0].NhanDinhDiem); }
            catch { }
        }

        private void btn_NhanDinhDiem_Luu_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string NhanDinhDiem = GetRTF(rtb_NhanDinhDiem_Editor);
                UngSinh objNhanDinhDiem = new UngSinh();
                ObservableCollection<UngSinh> obj = UngSinh.HienThiUngSinh(11);
                objNhanDinhDiem.MaUngSinh = obj[0].MaUngSinh;
                objNhanDinhDiem.NhanDinhDiem = NhanDinhDiem;
                objNhanDinhDiem.CapNhatNhanDinhDiem(objNhanDinhDiem);
                MessageBox.Show("Đã cập nhật dữ liệu.");
            }
            catch
            {
                MessageBox.Show("Cập nhật không thành công.");
            }
        }
    }
}
