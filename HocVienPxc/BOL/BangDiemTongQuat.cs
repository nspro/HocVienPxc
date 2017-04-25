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
        float _diemTrungBinh;
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
        public float DiemTrungBinh
        {
            get { return _diemTrungBinh; }
            set { _diemTrungBinh = value; }
        }
    }
}
