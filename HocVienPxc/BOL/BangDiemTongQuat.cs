using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HocVienPxc.DAL;
using System.Collections.ObjectModel;

namespace HocVienPxc.BOL
{
    public class BangDiemTongQuat
    {
        int _idBangDiemTongQuat;
        int _maUngSinh;
        int _maGiaiDoan;
        int _maHocKy;
        int _maMonHoc;
        int _maLop;
        double _diemTrungBinh;
        public int IdBangDiemTongQuat
        {
            get { return _idBangDiemTongQuat; }
            set { _idBangDiemTongQuat = value; }
        }
        public int MaUngSinh
        {
            get { return _maUngSinh; }
            set { _maUngSinh = value; }
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
        public int MaMonHoc
        {
            get { return _maMonHoc; }
            set { _maMonHoc = value; }
        }
        public int MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        public double DiemTrungBinh
        {
            get { return _diemTrungBinh; }
            set { _diemTrungBinh = value; }
        }
        public int ThemBangDiemTongQuat(BangDiemTongQuat obj)
        {
            BangDiemTongQuatDAL db = new BangDiemTongQuatDAL();
            return db.ThemBangDiemTongQuat(obj);
        }
        public int SuaBangDiemTongQuat(BangDiemTongQuat obj)
        {
            BangDiemTongQuatDAL db = new BangDiemTongQuatDAL();
            return db.SuaBangDiemTongQuat(obj);
        }
        public int XoaBangDiemTongQuat(int IdBangDiemTongQuat)
        {
            BangDiemTongQuatDAL db = new BangDiemTongQuatDAL();
            return db.XoaBangDiemTongQuat(IdBangDiemTongQuat);
        }
    }
}
