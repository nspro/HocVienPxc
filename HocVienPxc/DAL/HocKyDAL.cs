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
    public class HocKyDAL : BaseDAL
    {
        private HocKy HocKyIDataReader(IDataReader Reader)
        {
            HocKy obj = new HocKy();
            obj.MaHocKy = (Reader["MaHocKy"] is DBNull) ? int.MinValue : (int)Reader["MaHocKy"];
            obj.TenHocKy = (Reader["TenHocKy"] is DBNull) ? string.Empty : (string)Reader["TenHocKy"];
            return obj;
        }
        public int ThemHocKy(HocKy obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into HocKy value('" + obj.TenHocKy + "') ", conn);
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
        public int SuaHocKy(HocKy obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update HocKy set TenHocKy = '"+obj.TenHocKy+"' where MaHocKy = '"+obj.MaHocKy+"' ", conn);
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
        public int XoaHocKy(int MaHocKy)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from HocKy where MaHocKy = '"+MaHocKy+"' ", conn);
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
        public ObservableCollection<HocKy> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from HocKy", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<HocKy> lst = new ObservableCollection<HocKy>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(HocKyIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<HocKy> HienThiHocKy(int MaHocKy)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from HocKy where MaHocKy = '"+ MaHocKy + "' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<HocKy> lst = new ObservableCollection<HocKy>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(HocKyIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}