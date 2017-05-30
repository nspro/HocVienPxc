using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class Lop
    {
        int _maLop;
        string _tenLop;
        DateTime _namBatDau;
        int _maGiaiDoan;
        int _maHocKy;
        public int MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        public int MaGiaiDoan
        {
            get { return _maGiaiDoan; }
            set { _maGiaiDoan = value; }
        }
        public int MaHocKy
        {
            get { return _maHocKy; }
            set { _maHocKy = value; }
        }
        public string TenLop
        {
            get { return _tenLop; }
            set { _tenLop = value; }
        }
        public DateTime NamBatDau
        {
            get { return _namBatDau; }
            set { _namBatDau = value; }
        }
        public int ThemLop(Lop obj)
        {
            LopDAL db = new LopDAL();
            return db.ThemLop(obj);
        }
        public int SuaLop(Lop obj)
        {
            LopDAL db = new LopDAL();
            return db.SuaLop(obj);
        }
        public int XoaLop(int MaLop)
        {
            LopDAL db = new LopDAL();
            return db.XoaLop(MaLop);
        }
        public static ObservableCollection<Lop> HienThiTatCa()
        {
            LopDAL db = new LopDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<Lop> HienThiLop(int MaLop)
        {
            LopDAL db = new LopDAL();
            return db.HienThiLop(MaLop);
        }
        public static ObservableCollection<Lop> HienThiLopTheoGiaiDoan(int MaGiaiDoan)
        {
            LopDAL db = new LopDAL();
            return db.HienThiLopTheoGiaiDoan(MaGiaiDoan);
        }
    }
}
