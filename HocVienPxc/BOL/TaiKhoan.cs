using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class TaiKhoan
    {
        string _email;
        string _password;
        int _maQuyenHan;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int MaQuyenHan
        {
            get { return _maQuyenHan; }
            set { _maQuyenHan = value; }
        }
        public int ThemTaiKhoan(TaiKhoan obj)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.ThemTaiKhoan(obj);
        }
        public int SuaTaiKhoan(TaiKhoan obj)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.SuaTaiKhoan(obj);
        }
        public int XoaTaiKhoan(string Email)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.XoaTaiKhoan(Email);
        }
        public static ObservableCollection<TaiKhoan> HienThiTatCa()
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<TaiKhoan> HienThiTaiKhoan(string Email)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.HienThiTaiKhoan(Email);
        }
        public static ObservableCollection<TaiKhoan> KiemTraDangNhap(string Email, string Password)
        {
            TaiKhoanDAL db = new TaiKhoanDAL();
            return db.KiemTraDangNhap(Email, Password);
        }
    }
}
