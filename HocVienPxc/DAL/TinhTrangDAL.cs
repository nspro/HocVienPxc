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
    public class TinhTrangDAL:BaseDAL
    {
        public TinhTrang TinhTrangIDataReader(IDataReader Reader)
        {
            TinhTrang obj = new TinhTrang();
            obj.MaTinhTrang = (Reader["MaTinhTrang"] is DBNull) ? int.MinValue : (int)Reader["MaTinhTrang"];
            obj.TenTinhTrang = (Reader["TenTinhTrang"] is DBNull) ? string.Empty : (string)Reader["TenTinhTrang"];
            return obj;
        }
        public int ThemTinhTrang(TinhTrang obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into TinhTrang values(N'" + obj.TenTinhTrang + "')", conn);
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
        public int SuaTinhTrang(TinhTrang obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update TinhTrang set TenTinhTrang = '"+obj.TenTinhTrang+"' where MaTinhTrang = '"+obj.MaTinhTrang+"' ", conn);
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
        public int XoaTinhTrang(int MaTinhTrang)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from TinhTrang where MaTinhTrang = '"+MaTinhTrang+"' ", conn);
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
        public ObservableCollection<TinhTrang> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from TinhTrang", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<TinhTrang> lst = new ObservableCollection<TinhTrang>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(TinhTrangIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<TinhTrang> HienThiTinhTrang(int MaTinhTrang)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from TinhTrang where MaTinhTrang = '"+MaTinhTrang+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<TinhTrang> lst = new ObservableCollection<TinhTrang>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(TinhTrangIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
