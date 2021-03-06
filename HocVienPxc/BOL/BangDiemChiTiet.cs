﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class BangDiemChiTiet
    {
        int _idBangDiemChiTiet;
        int _idBangDiemTongQuat;
        int _maDauDiem;
        string _tenDauDiem;
        double _trongSo;
        double _diem;
        public int IdBangDiemChiTiet
        {
            get { return _idBangDiemChiTiet; }
            set { _idBangDiemChiTiet = value; }
        }
        public int IdBangDiemTongQuat
        {
            get { return _idBangDiemTongQuat; }
            set { _idBangDiemTongQuat = value; }
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
        public double TrongSo
        {
            get { return _trongSo; }
            set { _trongSo = value; }
        }
        public double Diem
        {
            get { return _diem; }
            set { _diem = value; }
        }
        public static double TinhDiemTrungBinh(int IdBangDiemTongQuat)
        {
            BangDiemChiTietDAL db = new BangDiemChiTietDAL();
            return db.TinhDiemTrungBinh(IdBangDiemTongQuat);
        }
    }
}
