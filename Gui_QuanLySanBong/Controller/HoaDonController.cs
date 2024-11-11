using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;


namespace GUI_QuanLySanBong.Controller
{
    class HoaDonController
    {
        HoaDonModel hDMod = new HoaDonModel();
        public bool KetQuaTruyVan { get; set; }
        public string ThongBaoTruyVan { get; set; }
        public DataTable HienThiDuLieu()
        {
            return hDMod.HienThiDuLieu();
        }
        public DataTable HienThiDuLieuDoanhThu()
        {
            return hDMod.HienThiDuLieuDoanhThu();
        }
        public bool ThemDuLieuHoaDon(string makh, string masan, DateTime ngaylaphd,double tongphutda, float dongia, float thanhtien)
        {
            return hDMod.ThemHoaDon(makh,masan,ngaylaphd,tongphutda,dongia,thanhtien);
        }
        public bool ThemHoaDon(string masan, string makh, DateTime thoiGianBatDau, double tongphutda, int donGia, int thanhTien)
        {
            KetQuaTruyVan = hDMod.ThemHD(masan, makh, thoiGianBatDau,tongphutda, donGia, thanhTien);
            ThongBaoTruyVan = hDMod.ThongBaoTruyVan;
            return KetQuaTruyVan;
        }
        public DataTable HienThiDuLieuTheoNam(string nam)
        {
            return hDMod.HienThiThongKeNam(nam);
        }
        public DataTable HienThiDuLieuTheoThang(string thang,string nam)
        {
            return hDMod.HienThiThongKeThang(thang,nam);
        }
        public bool KiemTraDuLieuHD(string maHD)
        {
            return hDMod.kiemTraTonTai(maHD);
        }
        public bool XoaDuLieuHD(string maHD)
        {
            return hDMod.XoaHD(maHD);
        }
        public bool LuuDuLieuHD(string maHD)
        {
            return hDMod.LuuHD(maHD);
        }
        public bool SuaDuLieuHD(string maHD, string makh, string masan, string date, string tongphutda, string dongia, string tongtien)
        {
            return hDMod.SuaHD(maHD, makh, masan, date, tongphutda, dongia, tongtien);
        }
        public DataTable HienThiDuLieuCboxKH()
        {
            return hDMod.LoadMaKHCombobox();
        }
    }
}
