using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HocVienPxc.DAL;
using System.Collections.ObjectModel;

namespace HocVienPxc.BOL
{
    public class TinhTrang
    {
        int _maTinhTrang;
        string _tenTinhTrang;

        public int MaTinhTrang
        {
            get { return _maTinhTrang; }
            set { _maTinhTrang = value; }
        }
        public string TenTinhTrang
        {
            get { return _tenTinhTrang; }
            set { _tenTinhTrang = value; }
        }
        public int ThemTinhTrang(TinhTrang obj)
        {
            TinhTrangDAL db = new TinhTrangDAL();
            return db.ThemTinhTrang(obj);
        }
        public int SuaTinhTrang(TinhTrang obj)
        {
            TinhTrangDAL db = new TinhTrangDAL();
            return db.SuaTinhTrang(obj);
        }
        public int XoaTinhTrang(int MaTinhTrang)
        {
            TinhTrangDAL db = new TinhTrangDAL();
            return db.XoaTinhTrang(MaTinhTrang);
        }
        public static ObservableCollection<TinhTrang> HienThiTatCa()
        {
            TinhTrangDAL db = new TinhTrangDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<TinhTrang> HienThiTinhTrang(int MaTinhTrang)
        {
            TinhTrangDAL db = new TinhTrangDAL();
            return db.HienThiTinhTrang(MaTinhTrang);
        }
    }
}
