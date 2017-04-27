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
    public class BangDiemChiTietDAL:BaseDAL
    {
        private BangDiemChiTiet BangDiemChiTietIDataReader(IDataReader Reader)
        {
            BangDiemChiTiet obj = new BangDiemChiTiet();
            obj.IdBangDiemChiTiet = (Reader["IdBangDiemChiTiet"] is DBNull) ? int.MinValue : (int)Reader["IdBangDiemChiTiet"];
            obj.IdBangDiemTongQuat = (Reader["IdBangDiemTongQuat"] is DBNull) ? int.MinValue : (int)Reader["IdBangDiemTongQuat"];
            obj.MaDauDiem = (Reader["MaDauDiem"] is DBNull) ? int.MinValue : (int)Reader["MaDauDiem"];
            obj.TenDauDiem = (Reader["TenDauDiem"] is DBNull) ? string.Empty : (string)Reader["TenDauDiem"];
            obj.TrongSo = (Reader["TrongSo"] is DBNull) ? double.MinValue : (double)Reader["TrongSo"];
            obj.Diem = (Reader["Diem"] is DBNull) ? double.MinValue : (double)Reader["Diem"];
            return obj;
        }
        public int ThemBangDiemChiTiet(BangDiemChiTiet obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into BangDiemChiTiet value('" + obj.IdBangDiemChiTiet + "','" + obj.IdBangDiemTongQuat + "','" + obj.MaDauDiem + "',N'" + obj.TenDauDiem + "','" + obj.TrongSo + "','" + obj.Diem + "') ", conn);
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
        public int SuaBangDiemChiTiet(BangDiemChiTiet obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update BangDiemChiTiet set Diem = '" + obj.Diem + "' where IdBangDiemChiTiet = '"+obj.IdBangDiemChiTiet+"' and IdBangDiemTongQuat = '"+obj.IdBangDiemTongQuat+"' ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    BangDiemTongQuatDAL db = new BangDiemTongQuatDAL();
                    db.CapNhatDiemTrungBinh(obj.IdBangDiemTongQuat, TinhDiemTrungBinh(obj.IdBangDiemTongQuat));
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int XoaBangDiemChiTiet(int IdBangDiemTongQuat)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from BangDiemChiTiet where IdBangDiemTongQuat = '"+IdBangDiemTongQuat+"' ", conn);
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
        public double TinhDiemTrungBinh(int IdBangDiemTongQuat)
        {
            double ketqua = 0;
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from BangDiemChiTiet where IdBangDiemTongQuat = '" + IdBangDiemTongQuat + "' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<BangDiemChiTiet> lst = new ObservableCollection<BangDiemChiTiet>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(BangDiemChiTietIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                if (lst.Count > 0)
                {
                    double diem = 0;
                    for (int i=0; i<lst.Count;i++)
                    {
                        diem += (lst[i].TrongSo * lst[i].Diem)/100;
                    }
                    ketqua = diem;
                }
            }
            return ketqua;
        }
    }
}
