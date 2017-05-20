using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class UngSinh
    {
        int _maUngSinh;
        string _tenThanh;
        string _hoVaTenLot;
        string _tenUngSinh;
        int _maTinhTrang;
        int _maLop;
        DateTime _ngaySinh;
        string _noiSinh;
        string _nguyenQuan;
        string _hoKhauThuongTru;
        string _soCMND;
        DateTime _ngayCapCMND;
        string _noiCapCMND;
        DateTime _ngayRuaToi;
        string _giaoXuRuaToi;
        DateTime _ngayThemSuc;
        string _giaoXuThemSuc;
        string _giaoXu;
        string _giaoPhan;
        string _dienThoaiGiaoXu;
        string _dienThoaiCaNhan;
        string _caTinh;
        string _lichSuOnGoi;
        string _yThucDoiTu;
        string _hocTapNangKhieu;
        string _nhungDiemCoGangThayDoi;
        string _nhanDinhOnGoi;
        string _sucKhoe;
        string _nhanDinhDiem;
        string _anhDaiDien;
        public int MaUngSinh
        {
            get { return _maUngSinh; }
            set { _maUngSinh = value; }
        }
        public string TenThanh
        {
            get { return _tenThanh; }
            set { _tenThanh = value; }
        }
        public string HoVaTenLot
        {
            get { return _hoVaTenLot; }
            set { _hoVaTenLot = value; }
        }
        public string TenUngSinh
        {
            get { return _tenUngSinh; }
            set { _tenUngSinh = value; }
        }
        public int MaTinhTrang
        {
            get { return _maTinhTrang; }
            set { _maTinhTrang = value; }
        }
        public int MaLop
        {
            get { return _maLop; }
            set { _maLop = value; }
        }
        public DateTime NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }
        public string NoiSinh
        {
            get { return _noiSinh; }
            set { _noiSinh = value; }
        }
        public string NguyenQuan
        {
            get { return _nguyenQuan; }
            set { _nguyenQuan = value; }
        }
        public string HoKhauThuongTru
        {
            get { return _hoKhauThuongTru; }
            set { _hoKhauThuongTru = value; }
        }
        public string SoCMND
        {
            get { return _soCMND; }
            set { _soCMND = value; }
        }
        public DateTime NgayCapCMND
        {
            get { return _ngayCapCMND; }
            set { _ngayCapCMND = value; }
        }
        public string NoiCapCMND
        {
            get { return _noiCapCMND; }
            set { _noiCapCMND = value; }
        }
        public DateTime NgayRuaToi
        {
            get { return _ngayRuaToi; }
            set { _ngayRuaToi = value; }
        }
        public string GiaoXuRuaToi
        {
            get { return _giaoXuRuaToi; }
            set { _giaoXuRuaToi = value; }
        }
        public DateTime NgayThemSuc
        {
            get { return _ngayThemSuc; }
            set { _ngayThemSuc = value; }
        }
        public string GiaoXuThemSuc
        {
            get { return _giaoXuThemSuc; }
            set { _giaoXuThemSuc = value; }
        }
        public string GiaoXu
        {
            get { return _giaoXu; }
            set { _giaoXu = value; }
        }
        public string GiaoPhan
        {
            get { return _giaoPhan; }
            set { _giaoPhan = value; }
        }
        public string DienThoaiGiaoXu
        {
            get { return _dienThoaiGiaoXu; }
            set { _dienThoaiGiaoXu = value; }
        }
        public string DienThoaiCaNhan
        {
            get { return _dienThoaiCaNhan; }
            set { _dienThoaiCaNhan = value; }
        }
        public string CaTinh
        {
            get { return _caTinh; }
            set { _caTinh = value; }
        }
        public string LichSuOnGoi
        {
            get { return _lichSuOnGoi; }
            set { _lichSuOnGoi = value; }
        }
        public string YThucDoiTu
        {
            get { return _yThucDoiTu; }
            set { _yThucDoiTu = value; }
        }
        public string HocTapNangKhieu
        {
            get { return _hocTapNangKhieu; }
            set { _hocTapNangKhieu = value; }
        }
        public string NhungDiemCoGangThayDoi
        {
            get { return _nhungDiemCoGangThayDoi; }
            set { _nhungDiemCoGangThayDoi = value; }
        }
        public string NhanDinhOnGoi
        {
            get { return _nhanDinhOnGoi; }
            set { _nhanDinhOnGoi = value; }
        }
        public string SucKhoe
        {
            get { return _sucKhoe; }
            set { _sucKhoe = value; }
        }
        public string NhanDinhDiem
        {
            get { return _nhanDinhDiem; }
            set { _nhanDinhDiem = value; }
        }
        public string AnhDaiDien
        {
            get { return _anhDaiDien; }
            set { _anhDaiDien = value; }
        }
        public static ObservableCollection<UngSinh> HienThiTatCa()
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.HienThiTatCa();
        }
        public static ObservableCollection<UngSinh> HienThiUngSinh(int MaUngSinh)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.HienThiUngSinh(MaUngSinh);
        }
        public int ThemTaiKhoan(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.ThemTaiKhoan(obj);
        }
        public int SuaUngSinh(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.SuaUngSinh(obj);
        }
        public int XoaUngSinh(int MaUngSinh)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.XoaUngSinh(MaUngSinh);
        }
        public int CapNhatLichSuOnGoi(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatLichSuOnGoi(obj);
        }
        public int CapNhatCaTinh(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatCaTinh(obj);
        }
        public int CapNhatYThucDoiTu(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatYThucDoiTu(obj);
        }
        public int CapNhatHocTapNangKhieu(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatHocTapNangKhieu(obj);
        }
        public int CapNhatNhungDiemCoGangThayDoi(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatNhungDiemCoGangThayDoi(obj);
        }
        public int CapNhatNhanDinhOnGoi(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatNhanDinhOnGoi(obj);
        }
        public int CapNhatSucKhoe(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatSucKhoe(obj);
        }
        public int CapNhatNhanDinhDiem(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatNhanDinhDiem(obj);
        }
        public int CapNhatAnhDaiDien(UngSinh obj)
        {
            UngSinhDAL db = new UngSinhDAL();
            return db.CapNhatAnhDaiDien(obj);
        }
    }
    
}
