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
    public class GiaiDoanDAL:BaseDAL
    {
        private GiaiDoan GiaiDoanIDataReader(IDataReader Reader)
        {
            GiaiDoan obj = new GiaiDoan();
            obj.MaGiaiDoan = (Reader["MaGiaiDoan"] is DBNull) ? int.MinValue : (int)Reader["MaGiaiDoan"];
            obj.TenGiaiDoan = (Reader["TenGiaiDoan"] is DBNull) ? string.Empty : (string)Reader["TenGiaiDoan"];
            obj.SoHocKy = (Reader["SoHocKy"] is DBNull) ? int.MinValue : (int)Reader["SoHocKy"];
            return obj;
        }
        public int ThemGiaiDoan(GiaiDoan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into GiaiDoan values(N'" + obj.TenGiaiDoan + "','" + obj.SoHocKy + "')", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteReader();
                    conn.Close();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int SuaGiaiDoan(GiaiDoan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update GiaiDoan set TenGiaiDoan = '" + obj.TenGiaiDoan + "', SoHocKy = '" + obj.SoHocKy + "' where MaGiaiDoan = '" + obj.MaGiaiDoan + "' ", conn);
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
        public int XoaGiaiDoan(int MaGiaiDoan)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from GiaiDoan where MaGiaiDoan = '" + MaGiaiDoan + "' ", conn);
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
        public ObservableCollection<GiaiDoan> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from GiaiDoan", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<GiaiDoan> lst = new ObservableCollection<GiaiDoan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(GiaiDoanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<GiaiDoan> HienThiGiaiDoan(int MaGiaiDoan)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from GiaiDoan where MaGiaiDoan = '"+MaGiaiDoan+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<GiaiDoan> lst = new ObservableCollection<GiaiDoan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(GiaiDoanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
