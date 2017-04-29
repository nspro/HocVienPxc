using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class QuyenHan
    {
        int _maQuyenHan;
        string _tenQuyenHan;
        public int MaQuyenHan
        {
            get { return _maQuyenHan; }
            set { _maQuyenHan = value; }
        }
        public string TenQuyenHan
        {
            get { return _tenQuyenHan; }
            set { _tenQuyenHan = value; }
        }
        public int ThemQuyenHan(QuyenHan obj)
        {
            QuyenHanDAL db = new QuyenHanDAL();
            return db.ThemQuyenHan(obj);
        }
        public int SuaQuyenHan(QuyenHan obj)
        {
            QuyenHanDAL db = new QuyenHanDAL();
            return db.SuaQuyenHan(obj);
        }
        public int XoaQuyenHan(int MaQuyenHan)
        {
            QuyenHanDAL db = new QuyenHanDAL();
            return db.XoaQuyenHan(MaQuyenHan);
        }
        public static ObservableCollection<QuyenHan> HienThiTatCa()
        {
            QuyenHanDAL db = new QuyenHanDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<QuyenHan> HienThiQuyenHan(int MaQuyenHan)
        {
            QuyenHanDAL db = new QuyenHanDAL();
            return db.HienThiQuyenHan(MaQuyenHan);
        }
    }
}
