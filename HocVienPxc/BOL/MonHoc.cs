using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class MonHoc
    {
        int _maMonHoc;
        string _tenMonHoc;
        int _maGiaiDoan;
        string _thongTinMonHoc;
        public int MaMonHoc
        {
            get { return _maMonHoc; }
            set { _maMonHoc = value; }
        }
        public string TenMonHoc
        {
            get { return _tenMonHoc; }
            set { _tenMonHoc = value; }
        }
        public int MaGiaiDoan
        {
            get { return _maGiaiDoan; }
            set { _maGiaiDoan = value; }
        }
        public string ThongTinMonHoc
        {
            get { return _thongTinMonHoc; }
            set { _thongTinMonHoc = value; }
        }
        public int ThemMonHoc(MonHoc obj)
        {
            MonHocDAL db = new MonHocDAL();
            return db.ThemMonHoc(obj);
        }
        public int SuaMonHoc(MonHoc obj)
        {
            MonHocDAL db = new MonHocDAL();
            return db.SuaMonHoc(obj);
        }
        public int XoaMonHoc(int MaMonHoc)
        {
            MonHocDAL db = new MonHocDAL();
            return db.XoaMonHoc(MaMonHoc);
        }
        public static ObservableCollection<MonHoc> HienThiTatCa()
        {
            MonHocDAL db = new MonHocDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<MonHoc> HienThiMonHoc(int MaMonHoc)
        {
            MonHocDAL db = new MonHocDAL();
            return db.HienThiMonHoc(MaMonHoc);
        }
    }
}
