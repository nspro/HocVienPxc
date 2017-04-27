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
    public class BangDiemTongQuatDAL:BaseDAL
    {
        private BangDiemTongQuat BangDiemTongQuatIDataReader(IDataReader Reader)
        {
            BangDiemTongQuat obj = new BangDiemTongQuat();
            obj.IdBangDiemTongQuat = (Reader["IdBangDiemTongQuat"] is DBNull) ? int.MinValue : (int)Reader["IdBangDiemTongQuat"];
            obj.MaUngSinh = (Reader["MaUngSinh"] is DBNull) ? int.MinValue : (int)Reader["MaUngSinh"];
            obj.MaGiaiDoan = (Reader["MaGiaiDoan"] is DBNull) ? int.MinValue : (int)Reader["MaGiaiDoan"];
            obj.MaHocKy = (Reader["MaHocKy"] is DBNull) ? int.MinValue : (int)Reader["MaHocKy"];
            obj.MaMonHoc = (Reader["MaMonHoc"] is DBNull) ? int.MinValue : (int)Reader["MaMonHoc"];
            obj.MaLop = (Reader["MaLop"] is DBNull) ? int.MinValue : (int)Reader["MaLop"];
            obj.DiemTrungBinh = (Reader["DiemTrungBinh"] is DBNull) ? double.MinValue : (double)Reader["DiemTrungBinh"];
            return obj;
        }
        public int ThemBangDiemTongQuat(BangDiemTongQuat obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into BangDiemTongQuat value('" + obj.MaUngSinh + "','" + obj.MaGiaiDoan + "','" + obj.MaHocKy + "','" + obj.MaMonHoc + "','" + obj.MaLop + "','" + obj.DiemTrungBinh + "') ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int SuaBangDiemTongQuat(BangDiemTongQuat obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update BangDiemTongQuat set MaUngSinh = '"+obj.MaUngSinh+"', MaGiaiDoan = '"+obj.MaGiaiDoan+"', MaHocKy = '"+obj.MaHocKy+"', MaMonHoc = '"+obj.MaMonHoc+"', MaLop = '"+obj.MaLop+"', DiemTrungBinh = '"+obj.DiemTrungBinh+"' where IdBangDiemTongQuat = '"+obj.IdBangDiemTongQuat+"' ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int CapNhatDiemTrungBinh(int IdBangDiemTongQuat, double DiemTrungBinh)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update BangDiemTongQuat set DiemTrungBinh = '"+DiemTrungBinh+"' where IdBangDiemTongQuat = '"+IdBangDiemTongQuat+"' ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int XoaBangDiemTongQuat(int IdBangDiemTongQuat)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    BangDiemChiTietDAL db = new BangDiemChiTietDAL();
                    db.XoaBangDiemChiTiet(IdBangDiemTongQuat);
                    SqlCommand myCommand = new SqlCommand("Delete * from BangDiemTongQuat where IdBangDiemTongQuat = '"+IdBangDiemTongQuat+"' ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public ObservableCollection<BangDiemTongQuat> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from BangDiemTongQuat", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<BangDiemTongQuat> lst = new ObservableCollection<BangDiemTongQuat>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(BangDiemTongQuatIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<BangDiemTongQuat> HienThiTheoMaUngSinh(int MaUngSinh)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from BangDiemTongQuat where MaUngSinh = '" + MaUngSinh + "' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<BangDiemTongQuat> lst = new ObservableCollection<BangDiemTongQuat>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(BangDiemTongQuatIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<BangDiemTongQuat> HienThiTheoMaGiaiDoan(int MaGiaiDoan)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from BangDiemTongQuat where MaGiaiDoan = '" + MaGiaiDoan + "' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<BangDiemTongQuat> lst = new ObservableCollection<BangDiemTongQuat>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(BangDiemTongQuatIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
