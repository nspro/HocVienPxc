using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using HocVienPxc.BOL;

namespace HocVienPxc.DAL
{
    public class UngSinhDAL:BaseDAL
    {
        public UngSinh UngSinhIDataReader(IDataReader Reader)
        {
            UngSinh obj = new UngSinh();
            obj.MaUngSinh = (Reader["MaUngSinh"] is DBNull) ? int.MinValue : (int)Reader["MaUngSinh"];
            obj.TenThanh = (Reader["TenThanh"] is DBNull) ? string.Empty : (string)Reader["TenThanh"];
            obj.HoVaTenLot = (Reader["HoVaTenLot"] is DBNull) ? string.Empty : (string)Reader["HoVaTenLot"];
            obj.TenUngSing = (Reader["TenUngSinh"] is DBNull) ? string.Empty : (string)Reader["TenUngSinh"];
            obj.MaTinhTrang = (Reader["MaTinhTrang"] is DBNull) ? int.MinValue : (int)Reader["MaTinhTrang"];
            obj.MaLop = (Reader["MaLop"] is DBNull) ? int.MinValue : (int)Reader["MaLop"];
            obj.NgaySinh = (Reader["NgaySinh"] is DBNull) ? DateTime.MinValue : (DateTime)Reader["NgaySinh"];
            obj.NoiSinh = (Reader["NoiSinh"] is DBNull) ? string.Empty : (string)Reader["NoiSinh"];
            obj.NguyenQuan = (Reader["NguyenQuan"] is DBNull) ? string.Empty : (string)Reader["NguyenQuan"];
            obj.HoKhauThuongTru = (Reader["HoKhauThuongTru"] is DBNull) ? string.Empty : (string)Reader["HoKhauThuongTru"];
            obj.SoCMND = (Reader["SoCMND"] is DBNull) ? string.Empty : (string)Reader["SoCMND"];
            obj.NgayCapCMND = (Reader["NgayCapCMND"] is DBNull) ? DateTime.MinValue : (DateTime)Reader["NgayCapCMND"];
            obj.NoiCapCMND = (Reader["NoiCapCMND"] is DBNull) ? string.Empty : (string)Reader["NoiCapCMND"];
            obj.NgayRuaToi = (Reader["NgayRuaToi"] is DBNull) ? DateTime.MinValue : (DateTime)Reader["NgayRuaToi"];
            obj.GiaoXuRuaToi = (Reader["GiaoXuRuaToi"] is DBNull) ? string.Empty : (string)Reader["GiaoXuRuaToi"];
            obj.NgayThemSuc = (Reader["NgayThemSuc"] is DBNull) ? DateTime.MinValue : (DateTime)Reader["NgayThemSuc"];
            obj.GiaoXuThemSuc = (Reader["GiaoXuThemSuc"] is DBNull) ? string.Empty : (string)Reader["GiaoXuThemSuc"];
            obj.GiaoXu = (Reader["GiaoXu"] is DBNull) ? string.Empty : (string)Reader["GiaoXu"];
            obj.GiaoPhan = (Reader["GiaoPhan"] is DBNull) ? string.Empty : (string)Reader["GiaoPhan"];
            obj.DienThoaiGiaoXu = (Reader["DienThoaiGiaoXu"] is DBNull) ? string.Empty : (string)Reader["DienThoaiGiaoXu"];
            obj.DienThoaiCaNhan = (Reader["DienThoaiCaNhan"] is DBNull) ? string.Empty : (string)Reader["DienThoaiCaNhan"];
            obj.CaTinh = (Reader["CaTinh"] is DBNull) ? string.Empty : (string)Reader["CaTinh"];
            obj.LichSuOnGoi = (Reader["LichSuOnGoi"] is DBNull) ? string.Empty : (string)Reader["LichSuOnGoi"];
            obj.YThucDoiTu = (Reader["YThucDoiTu"] is DBNull) ? string.Empty : (string)Reader["YThucDoiTu"];
            obj.HocTapNangKhieu = (Reader["HocTapNangKhieu"] is DBNull) ? string.Empty : (string)Reader["HocTapNangKhieu"];
            obj.NhungDiemCoGangThayDoi = (Reader["NhungDiemCoGangThayDoi"] is DBNull) ? string.Empty : (string)Reader["NhungDiemCoGangThayDoi"];
            obj.NhanDinhOnGoi = (Reader["NhanDinhOnGoi"] is DBNull) ? string.Empty : (string)Reader["NhanDinhOnGoi"];
            obj.NhanDinhDiem = (Reader["NhanDinhDiem"] is DBNull) ? string.Empty : (string)Reader["NhanDinhDiem"];

            return obj;
        }
        public int ThemTaiKhoan(UngSinh obj)
        {
            try
            {
                using (SqlConnection conn = getConnect())
                {

                    conn.Open();
                    string q = "Insert into UngSinh values (N'" + obj.TenThanh + "',N'" + obj.HoVaTenLot + "',N'" + obj.TenUngSing + "',N'" + obj.MaTinhTrang + "',N'" + obj.MaLop + "',N'" + obj.NgaySinh + "',N'" + obj.NoiSinh + "',N'" + obj.NguyenQuan + "',N'" + obj.HoKhauThuongTru + "',N'" + obj.SoCMND + "',N'" + obj.NgayCapCMND + "',N'" + obj.NoiCapCMND + "',N'" + obj.NgayRuaToi + "',N'" + obj.GiaoXuRuaToi + "',N'" + obj.NgayThemSuc + "',N'" + obj.GiaoXuThemSuc + "',N'" + obj.GiaoXu + "',N'" + obj.GiaoPhan + "',N'" + obj.DienThoaiGiaoXu + "',N'" + obj.DienThoaiCaNhan + "',N'" + obj.CaTinh + "',N'" + obj.LichSuOnGoi + "',N'" + obj.YThucDoiTu + "',N'" + obj.HocTapNangKhieu + "',N'" + obj.NhungDiemCoGangThayDoi + "',N'" + obj.NhanDinhOnGoi + "',N'" + obj.SucKhoe + "',N'" + obj.NhanDinhDiem + "') ";
                    SqlCommand myCommand = new SqlCommand(q, conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int SuaUngSinh(UngSinh obj)
        {
            try
            {
                using (SqlConnection conn = getConnect())
                {

                    conn.Open();
                    string q = "Update UngSinh set TenThanh = N'" + obj.TenThanh + "', HoVaTenLot = N'" + obj.HoVaTenLot + "',TenUngSing = N'" + obj.TenUngSing + "',MaTinhTrang =N'" + obj.MaTinhTrang + "',MaLop = N'" + obj.MaLop + "',NgaySinh=N'" + obj.NgaySinh + "',NoiSinh=N'" + obj.NoiSinh + "',NguyenQuan=N'" + obj.NguyenQuan + "',HoKhauThuongTru=N'" + obj.HoKhauThuongTru + "',SoCMND=N'" + obj.SoCMND + "',NgayCapCMND=N'" + obj.NgayCapCMND + "',NoiCapCMND=N'" + obj.NoiCapCMND + "',NgayRuaToi=N'" + obj.NgayRuaToi + "',GiaoXuRuaToi=N'" + obj.GiaoXuRuaToi + "',NgayThemSuc=N'" + obj.NgayThemSuc + "',GiaoXuThemSuc=N'" + obj.GiaoXuThemSuc + "',GiaoXu=N'" + obj.GiaoXu + "',GiaoPhan=N'" + obj.GiaoPhan + "',DienThoaiGiaoXu=N'" + obj.DienThoaiGiaoXu + "',DienThoaiCaNhan=N'" + obj.DienThoaiCaNhan + "',CaTinh=N'" + obj.CaTinh + "',LichSuOnGoi=N'" + obj.LichSuOnGoi + "',YThucDoiTu=N'" + obj.YThucDoiTu + "',HocTapNangKhieu=N'" + obj.HocTapNangKhieu + "',NhungDiemCoGangThayDoi=N'" + obj.NhungDiemCoGangThayDoi + "',NhanDinhOnGoi=N'" + obj.NhanDinhOnGoi + "',SucKhoe=N'" + obj.SucKhoe + "',NhanDinhDiem=N'" + obj.NhanDinhDiem + "' where MaUngSinh = '"+obj.MaUngSinh+"' ";
                    SqlCommand myCommand = new SqlCommand(q, conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public int XoaUngSinh(int MaUngSinh)
        {
            try
            {
                using (SqlConnection conn = getConnect())
                {

                    conn.Open();
                    string q = "Delete * from UngSinh where MaUngSinh = '"+MaUngSinh+"' ";
                    SqlCommand myCommand = new SqlCommand(q, conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public ObservableCollection<UngSinh> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from UngSinh",conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<UngSinh> lst = new ObservableCollection<UngSinh>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if(Reader.HasRows)
                {
                    while(Reader.Read())
                    {
                        lst.Add(UngSinhIDataReader(Reader));
                    }Reader.Close();
                }conn.Close();
                return lst;
            }
        }
        public ObservableCollection<UngSinh> ThongTinUngSinh(int MaUngSinh)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from UngSinh where MaUngSinh = '" + MaUngSinh + "' ",conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<UngSinh> lst = new ObservableCollection<BOL.UngSinh>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(UngSinhIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
