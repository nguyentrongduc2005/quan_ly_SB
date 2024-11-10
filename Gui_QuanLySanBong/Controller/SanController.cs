using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;

namespace GUI_QuanLySanBong.Controller
{
    class SanController
    {
        SanModel sanMod = new SanModel();
        public DataTable HienThiDuLieuSan()
        {
            return sanMod.HienThiDuLieuSan();
        }
        public DataTable HienThiDuLieuCbox()
        {
            return sanMod.LoadLoaiSanCombobox();
        }
        public bool ThemDuLieuSan(string masan, string loaisan, string tensan)
        {
            return sanMod.ThemSan(masan, loaisan, tensan);
        }
        public bool KiemTraDuLieuSan(string maSan)
        {
            return sanMod.kiemTraTonTaiMaSan(maSan);
        }
        public bool XoaDuLieuSan(string maSan)
        {
            return sanMod.XoaSan(maSan);
        }
        public bool SuaDuLieuSan(string masan, string loaisan, string tensan)
        {
            return sanMod.SuaSan(masan, loaisan, tensan);
        }
        public DataTable HienThiDuLieuTimKiem(string maSan)
        {
            return sanMod.HienThiDuLieuTimKiem(maSan);
        }
    }
}
