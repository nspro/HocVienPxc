using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Collections.ObjectModel;
using HocVienPxc.BOL;
using System.Security.Cryptography;

namespace HocVienPxc.DAL
{
    public class TaiKhoanDAL:BaseDAL
    {
        public TaiKhoan TaiKhoanIDataReader(IDataReader Reader)
        {
            TaiKhoan obj = new TaiKhoan();
            obj.Email = (Reader["Email"] is DBNull) ? string.Empty : (string)Reader["Email"];
            obj.Password = (Reader["Password"] is DBNull) ? string.Empty : (string)Reader["Password"];
            obj.MaQuyenHan = (Reader["MaQuyenHan"] is DBNull) ? int.MinValue : (int)Reader["MaQuyenHan"];
            return obj;
        }
        public static string MaHoaMD5(string text)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(text));

            StringBuilder sbHash = new StringBuilder();

            foreach (byte b in bHash)
            {

                sbHash.Append(String.Format("{0:x2}", b));

            }
            return sbHash.ToString();
        }
        public int ThemTaiKhoan(TaiKhoan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into TaiKhoan values('" + obj.Email + "','" + MaHoaMD5(obj.Password) + "','" + obj.MaQuyenHan + "') ", conn);
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
               
            }
        }
        public int SuaTaiKhoan(TaiKhoan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update TaiKhoan set Password = '"+obj.Password+"', MaQuyenHan = '"+obj.MaQuyenHan+"' where Email = '"+obj.Email+"' ", conn);
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
        public int XoaTaiKhoan(string Email)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from TaiKhoan where Email = '"+Email+"' ", conn);
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
        public ObservableCollection<TaiKhoan> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from TaiKhoan", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<TaiKhoan> lst = new ObservableCollection<TaiKhoan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(TaiKhoanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<TaiKhoan> HienThiTaiKhoan(string Email)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from TaiKhoan where Email = '"+Email+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<TaiKhoan> lst = new ObservableCollection<TaiKhoan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(TaiKhoanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<TaiKhoan> KiemTraDangNhap(string Email, string Password)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from TaiKhoan where Email = '" + Email + "' and Password = '"+MaHoaMD5(Password)+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<TaiKhoan> lst = new ObservableCollection<TaiKhoan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(TaiKhoanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
