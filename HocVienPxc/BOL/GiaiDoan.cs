using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HocVienPxc.DAL;
using System.Collections.ObjectModel;

namespace HocVienPxc.BOL
{
    public class GiaiDoan
    {
        int _maGiaiDoan;
        string _tenGiaiDoan;
        int _soHocKy;
        public int MaGiaiDoan
        {
            get { return _maGiaiDoan; }
            set { _maGiaiDoan = value; }
        }
        public string TenGiaiDoan
        {
            get { return _tenGiaiDoan; }
            set { _tenGiaiDoan = value; }
        }
        public int SoHocKy
        {
            get { return _soHocKy; }
            set { _soHocKy = value; }
        }
        public int ThemGiaiDoan(GiaiDoan obj)
        {
            GiaiDoanDAL db = new GiaiDoanDAL();
            return db.ThemGiaiDoan(obj);
        }
        public int SuaGiaiDoan(GiaiDoan obj)
        {
            GiaiDoanDAL db = new GiaiDoanDAL();
            return db.SuaGiaiDoan(obj);
        }
        public int XoaGiaiDoan(int MaGiaiDoan)
        {
            GiaiDoanDAL db = new GiaiDoanDAL();
            return db.XoaGiaiDoan(MaGiaiDoan);
        }
        public static ObservableCollection<GiaiDoan> HienThiTatCa()
        {
            GiaiDoanDAL db = new GiaiDoanDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<GiaiDoan> HienThiGiaiDoan(int MaGiaiDoan)
        {
            GiaiDoanDAL db = new GiaiDoanDAL();
            return db.HienThiGiaiDoan(MaGiaiDoan);
        }
    }
}
