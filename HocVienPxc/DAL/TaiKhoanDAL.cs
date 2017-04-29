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
    public class TaiKhoanDAL:BaseDAL
    {
        public TaiKhoan TaiKhoanIDataReader(IDataReader Reader)
        {
            TaiKhoan obj = new TaiKhoan();
            obj.Email = (Reader["Email"] is DBNull) ? string.Empty : (string)Reader["Email"];
            obj.Password = (Reader["Password"] is DBNull) ? string.Empty : (string)Reader["Password"];
            obj.MaQuyenHan = (Reader["MaQuyenHan"] is DBNull) ? int.MinValue : (int)Reader["Password"];
            return obj;
        }
    }
}
