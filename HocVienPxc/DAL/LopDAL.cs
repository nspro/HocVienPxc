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
    public class LopDAL : BaseDAL
    {
        private Lop LopIDataReader(IDataReader Reader)
        {
            Lop obj = new Lop();
            obj.MaLop = (Reader["MaLop"] is DBNull) ? int.MinValue : (int)Reader["MaLop"];
            obj.TenLop = (Reader["TenLop"] is DBNull) ? string.Empty : (string)Reader["TenLop"];
            obj.NamBatDau = (Reader["NamBatDau"] is DBNull) ? string.Empty : (string)Reader["NamBatDau"];
            obj.MaGiaiDoan = (Reader["MaGiaiDoan"] is DBNull) ? int.MinValue : (int)Reader["MaGiaiDoan"];
            obj.MaHocKy = (Reader["MaHocKy"] is DBNull) ? int.MinValue : (int)Reader["MaHocKy"];
            return obj;
        }
        public int ThemLop(Lop obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into Lop values('" + obj.MaLop + "','" + obj.TenLop + "','" + obj.NamBatDau + "','" + obj.MaGiaiDoan + "','" + obj.MaHocKy + "')", conn);
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
        public int SuaLop(Lop obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update Lop set TenLop = '" + obj.TenLop + "', NamBatDau = '" + obj.NamBatDau + "', MaGiaiDoan = '" + obj.MaGiaiDoan + "', MaHocKy = '" + obj.MaHocKy + "' where MaLop='" + obj.MaLop + "' ", conn);
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
        public int XoaLop(int MaLop)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from MaLop = '"+MaLop+"' ", conn);
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
        public ObservableCollection<Lop> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from Lop", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<Lop> lst = new ObservableCollection<Lop>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(LopIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<Lop> HienThiLop(int MaLop)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from Lop where MaLop = '"+MaLop+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<Lop> lst = new ObservableCollection<Lop>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(LopIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
