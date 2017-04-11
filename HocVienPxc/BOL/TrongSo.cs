using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class TrongSo
    {
        int _maMonHoc;
        int _maDauDiem;
        string _tenDauDiem;
        float _giaTriTrongSo;

        public int MaMonHoc
        {
            get { return _maMonHoc; }
            set { _maMonHoc = value; }
        }
        public int MaDauDiem
        {
            get { return _maDauDiem; }
            set { _maDauDiem = value; }
        }
        public string TenDauDiem
        {
            get { return _tenDauDiem; }
            set { _tenDauDiem = value; }
        }
        public float GiaTriTrongSo
        {
            get { return _giaTriTrongSo; }
            set { _giaTriTrongSo = value; }
        }
    }
}
