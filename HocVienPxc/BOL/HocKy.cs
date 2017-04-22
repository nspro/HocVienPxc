using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class HocKy
    {
        int _maHocKy;
        string _tenHocKy;
        public int MaHocKy
        {
            get { return _maHocKy; }
            set { _maHocKy = value; }
        }
        public string TenHocKy
        {
            get { return _tenHocKy; }
            set { _tenHocKy = value; }
        }
        public int ThemHocKy(HocKy obj)
        {
            HocKyDAL db = new HocKyDAL();
            return db.ThemHocKy(obj);
        }
        public int SuaHocKy(HocKy obj)
        {
            HocKyDAL db = new HocKyDAL();
            return db.SuaHocKy(obj);
        }
        public int XoaHocKy(int MaHocKy)
        {
            HocKyDAL db = new HocKyDAL();
            return db.XoaHocKy(MaHocKy);
        }
        public static ObservableCollection<HocKy> HienThiTatCa()
        {
            HocKyDAL db = new HocKyDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<HocKy> HienThiLop(int MaHocKy)
        {
            HocKyDAL db = new HocKyDAL();
            return db.HienThiHocKy(MaHocKy);
        }
    }
}
