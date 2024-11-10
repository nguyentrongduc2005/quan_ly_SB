using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;

namespace GUI_QuanLySanBong.Controller
{
    class KhachHangController
    {
        KhachHangModel kHMod = new KhachHangModel();
        public DataTable HienThiDuLieu()
        {
            return kHMod.HienThiDuLieu();
        }
        public DataTable HienThiDuLieuTimKiem(string maKH)
        {
            return kHMod.HienThiDuLieuTimKiem(maKH);
        }
        public bool ThemDuLieuKH(string makh, string tenkh, string diachi, string sdt)
        {
            return kHMod.ThemKH(makh, tenkh, diachi, sdt);
        }
        public bool KiemTraDuLieuKH(string makh)
        {
            return kHMod.kiemTraTonTai(makh);
        }
        public bool XoaDuLieuKH(string makh)
        {
            return kHMod.XoaKH(makh);
        }
        public bool SuaDuLieuKH(string makh, string tenkh, string diachi, string sdt)
        {
            return kHMod.SuaKH(makh, tenkh, diachi, sdt);
        }
        //public List<KhachHangModel> HienThiDuLieuKH(string makh, string tenkh, string diachi, string sdt)
        //{
        //    return kHMod.HienThiDuLieu(makh, tenkh, diachi, sdt);
        //}
    }
}
