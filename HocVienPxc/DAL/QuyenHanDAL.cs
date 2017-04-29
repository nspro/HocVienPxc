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
    public class QuyenHanDAL:BaseDAL
    {
        public QuyenHan QuyenHanIDataReader(IDataReader Reader)
        {
            QuyenHan obj = new QuyenHan();
            obj.MaQuyenHan = (Reader["MaQuyenHan"] is DBNull) ? int.MinValue : (int)Reader["MaQuyenHan"];
            obj.TenQuyenHan = (Reader["TenQuyenHan"] is DBNull) ? string.Empty : (string)Reader["TenQuyenHan"];
            return obj;
        }
        public int ThemQuyenHan(QuyenHan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into QuyenHan value('" + obj.TenQuyenHan + "') ", conn);
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
        public int SuaQuyenHan(QuyenHan obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update QuyenHan set TenQuyenHan = '" + obj.TenQuyenHan + "' where MaQuyenHan = '" + obj.MaQuyenHan + "' ", conn);
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
        public int XoaQuyenHan(int MaQuyenHan)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Delete * from QuyenHan where MaQuyenHan = '" + MaQuyenHan + "' ", conn);
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
        public ObservableCollection<QuyenHan> HienThiTatCa()
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from QuyenHan", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<QuyenHan> lst = new ObservableCollection<QuyenHan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(QuyenHanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
        public ObservableCollection<QuyenHan> HienThiQuyenHan(int MaQuyenHan)
        {
            using (SqlConnection conn = getConnect())
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand("Select * from QuyenHan where MaQuyenHan='"+MaQuyenHan+"' ", conn);
                myCommand.CommandType = CommandType.Text;
                ObservableCollection<QuyenHan> lst = new ObservableCollection<QuyenHan>();
                SqlDataReader Reader = myCommand.ExecuteReader();
                if (Reader.HasRows)
                {
                    while (Reader.Read())
                    {
                        lst.Add(QuyenHanIDataReader(Reader));
                    }
                    Reader.Close();
                }
                conn.Close();
                return lst;
            }
        }
    }
}
