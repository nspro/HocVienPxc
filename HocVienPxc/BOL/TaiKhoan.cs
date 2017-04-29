using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using HocVienPxc.DAL;

namespace HocVienPxc.BOL
{
    public class TaiKhoan
    {
        string _email;
        string _password;
        int _maQuyenHan;
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public int MaQuyenHan
        {
            get { return _maQuyenHan; }
            set { _maQuyenHan = value; }
        }
        
    }
}
