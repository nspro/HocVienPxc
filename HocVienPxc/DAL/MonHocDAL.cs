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
    public class MonHocDAL : BaseDAL
    {
        private MonHoc MonHocIDataReader(IDataReader Reader)
        {
            MonHoc obj = new MonHoc();
            obj.MaMonHoc = (Reader["MaMonHoc"] is DBNull) ? int.MinValue : (int)Reader["MaMonHoc"];
            obj.TenMonHoc = (Reader["TenMonHoc"] is DBNull) ? string.Empty : (string)Reader["TenMonHoc"];
            obj.MaGiaiDoan = (Reader["MaGiaiDoan"] is DBNull) ? int.MinValue : (int)Reader["MaGiaiDoan"];
            obj.ThongTinMonHoc = (Reader["ThongTinMonHoc"] is DBNull) ? string.Empty : (string)Reader["ThongTinMonHoc"];
            return obj;
        }
        public int ThemMonHoc(MonHoc obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into MonHoc values('" + obj.TenMonHoc + "','" + obj.MaGiaiDoan + "','" + obj.ThongTinMonHoc + "') ", conn);
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
        public int SuaMonHoc(MonHoc obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update MonHoc set TenMonHoc = '" + obj.TenMonHoc + "', MaGiaiDoan = '" + obj.MaGiaiDoan + "', ThongTinMonHoc = '" + obj.ThongTinMonHoc + "' where MaMonHoc = '" + obj.MaMonHoc + "' ", conn);
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
        public int XoaMonHoc(int MaMonHoc)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from MonHoc where MaMonHoc = '" + MaMonHoc + "' ", conn);
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
        public ObservableCollection<MonHoc> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from MonHoc", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<MonHoc> lst = new ObservableCollection<MonHoc>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(MonHocIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<MonHoc> HienThiMonHoc(int MaMonHoc)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from MonHoc where MaMonHoc = '" + MaMonHoc + "' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<MonHoc> lst = new ObservableCollection<MonHoc>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(MonHocIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
