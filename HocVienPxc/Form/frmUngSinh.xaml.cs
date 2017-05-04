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

            //load font
            LoadFontAndSize();
            
        }

        private void LoadFontAndSize()
        {
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
        }


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
            rtb_NhanDinhOnGoi_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_NhanDinhOnGoi_FontSize.Text);
            btn_NhanDinhOnGoi_Luu.IsEnabled = true;
        }
        //END NHẬN ĐỊNH ƠN GỌI
    }
}
