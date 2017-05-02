using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
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
using HocVienPxc.Func;
using System.IO;

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
            //ThongTinUngSinh();

            //Load font
           LoadFontAndSize();
        }
        //public void ThongTinUngSinh()
        //{
        //    ObservableCollection<UngSinh> lst = UngSinh.HienThiUngSinh(10);
        //    //txtHoTen.Text = lst[0].TenThanh;
        //}

        private void LoadFontAndSize()
        {
            cmbFontFamily.ItemsSource = Fonts.SystemFontFamilies.OrderBy(f => f.Source);
            cmb_CaTinh_FontSize.ItemsSource = new List<double>() { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 26, 28, 36, 48, 72 };
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
            cmbFontFamily.SelectedItem = temp;
            temp = rtb_CaTinh_Editor.Selection.GetPropertyValue(Inline.FontSizeProperty);
            cmb_CaTinh_FontSize.Text = temp.ToString();
        }

        private void cmbFontFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbFontFamily.SelectedItem != null)
                rtb_CaTinh_Editor.Selection.ApplyPropertyValue(Inline.FontFamilyProperty, cmbFontFamily.SelectedItem);
        }

        private void rtb_CaTinh_Editor_TextChanged(object sender, TextChangedEventArgs e)
        {
            rtb_CaTinh_Editor.Selection.ApplyPropertyValue(Inline.FontSizeProperty, cmb_CaTinh_FontSize.Text);
        }


        //END CA TINH
    }
}
