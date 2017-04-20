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
        public GiaiDoan GiaiDoanIDataReader(IDataReader Reader)
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
                    SqlCommand myCommand = new SqlCommand("Insert into GiaiDoan values('" + obj.MaGiaiDoan + "',N'" + obj.TenGiaiDoan + "','" + obj.SoHocKy + "')", conn);
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
                return 1;
            }
        }
    }
}
