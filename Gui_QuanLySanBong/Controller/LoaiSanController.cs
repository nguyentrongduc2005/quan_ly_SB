using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;

namespace GUI_QuanLySanBong.Controller
{
    class LoaiSanController
    {
        LoaiSanModel loaiSanMod = new LoaiSanModel();
        public DataTable HienThiDuLieuLoaiSan()
        {
            return loaiSanMod.HienThiDuLieuLoaiSan();
        }
        public DataTable HienThiDuLieuCbox()
        {
            return loaiSanMod.LoadLoaiSanCombobox();
        }
        public bool ThemDuLieuLoaiSan(string loaisan, string tenloaisan, string gialoaisan)
        {
            return loaiSanMod.ThemLoaiSan(loaisan, tenloaisan, gialoaisan);
        }
        public bool KiemTraDuLieuLoaiSan(string loaiSan)
        {
            return loaiSanMod.kiemTraTonTaiLoaiSan(loaiSan);
        }
        public bool XoaDuLieuLoaiSan(string loaiSan)
        {
            return loaiSanMod.XoaLoaiSan(loaiSan);
        }
        public bool SuaDuLieuLoaiSan(string loaisan, string tenloaisan, string gialoaisan)
        {
            return loaiSanMod.SuaLoaiSan(loaisan, tenloaisan, gialoaisan);
        }
        public bool KiemTraDuLieuLoaiSan_SAN(string loaisan)
        {
            return loaiSanMod.kiemTraTonTaiLoaiSan_San(loaisan);
        }
    }
}
