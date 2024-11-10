using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;

namespace GUI_QuanLySanBong.Controller
{
    class AccountController
    {
        AccountModel aCMod = new AccountModel();
        public DataTable HienThiDuLieu()
        {
            return aCMod.HienThiDuLieu();
        }
        public bool ThemDuLieuAccount(string username, string display, string password, string quyen)
        {
            return aCMod.ThemAccount(username, display, password, quyen);
        }
        public bool KiemTraDuLieuAccount(string username)
        {
            return aCMod.kiemTraTonTai(username);
        }
        public bool XoaDuLieuAccount(string username)
        {
            return aCMod.XoaAccount(username);
        }
        public bool SuaDuLieuAccount(string username, string display, string password, string quyen)
        {
            return aCMod.SuaAccount(username, display, password, quyen);
        }
        public DataTable HienThiDuLieuTimKiem(string maAcc)
        {
            return aCMod.HienThiDuLieuTimKiem(maAcc);
        }
    }
}
