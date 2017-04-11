using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using HocVienPxc.BOL;
using System.Collections.ObjectModel;

namespace HocVienPxc.DAL
{
    public class TrongSoDAL:BaseDAL
    {
        public TrongSo TrongSoIDataReader(IDataReader Reader)
        {
            TrongSo obj = new TrongSo();
            obj.MaDauDiem = (Reader["MaDauDiem"] is DBNull) ? int.MinValue : (int)Reader["MaDauDiem"];
            obj.MaMonHoc = (Reader["MaMonHoc"] is DBNull) ? int.MinValue : (int)Reader["MaMonHoc"];
            obj.TenDauDiem = (Reader["TenDauDiem"] is DBNull) ? string.Empty : (string)Reader["TenDauDiem"];
            obj.GiaTriTrongSo = (Reader["TrongSo"] is DBNull) ? float.MinValue : (float)Reader["TrongSo"];
            return obj;
        }
        public int ThemTrongSo(TrongSo obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try
                {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Insert into TrongSo values('" + obj.MaMonHoc + "', '" + obj.MaDauDiem + "',N'" + obj.TenDauDiem + "','" + obj.GiaTriTrongSo + "')");
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    return 1;
                }
                catch
                {
                    return 0;
                }
            }
        }
        public int SuaTrongSo(TrongSo obj)
        {
            using (SqlConnection conn = getConnect())
            {
                try {
                    conn.Open();
                    SqlCommand myCommand = new SqlCommand("Update TrongSo set TenDauDiem = '" + obj.TenDauDiem + "', TrongSo = '" + obj.GiaTriTrongSo + "' where MaMonHoc = '" + obj.MaMonHoc + "' and MaDauDiem = '" + obj.MaDauDiem + "' ");
                    myCommand.CommandType = CommandType.Text;
                    myCommand.ExecuteNonQuery();
                    conn.Close();
                    return 1;
                }
                catch { return 0; }
            }
        }
    }
}
