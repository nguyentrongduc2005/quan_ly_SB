using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GUI_QuanLySanBong.Model;
using System.Data;

namespace GUI_QuanLySanBong.Controller
{
    class ThueSanController
    {
        ThueSan sanMod = new ThueSan();
        public DataTable HienThiDuLieu()
        {
            return sanMod.HienThiDuLieu();
        }
        public DataTable HienThiDuLieuCbox()
        {
            return sanMod.LoadMaSanCombobox();
        }
        public DataTable HienThiDuLieuCboxKH()
        {
            return sanMod.LoadMaKHCombobox();
        }
        public bool KiemTraDuLieuSAN1()
        {
            return sanMod.kiemTraSan1();
        }
        public bool ThemDuLieuThueSan(string masan, string makh, string ngaythuesan, string gioBD, string gioKT)
        {
            return sanMod.ThemThueSan(masan, makh, ngaythuesan, gioBD, gioKT);
        }
        public bool KiemTraDuLieuThueSan(string maThuesan)
        {
            return sanMod.kiemTraTonTai(maThuesan);
        }
        public bool KetQuaTruyVan { get; set; }
        public string ThongBaoTruyVan { get; set; }
        public DataTable CheckSuDung(string Ma_San, DateTime thoiGianBatDau)
        {
            KetQuaTruyVan = sanMod.KetQuaTruyVan;
            ThongBaoTruyVan = sanMod.ThongBaoTruyVan;
            return sanMod.CheckSuDung(Ma_San, thoiGianBatDau);
        }
        public bool ThueSanTrucTiep(string masan, string makh, string loaithue, int dongia)
        {
            KetQuaTruyVan = sanMod.ThueSanTrucTiep(masan,makh, loaithue, dongia);
            ThongBaoTruyVan = sanMod.ThongBaoTruyVan;
            return KetQuaTruyVan;
        }
        public bool DatSan(string masan, string makh, DateTime thoiGianBatDau, DateTime thoiGianKetThuc, string loaiThue, int donGia, int thanhTien)
        {
            KetQuaTruyVan = sanMod.DatSan(masan,makh, thoiGianBatDau, thoiGianKetThuc, loaiThue, donGia, thanhTien);
            ThongBaoTruyVan = sanMod.ThongBaoTruyVan;
            return KetQuaTruyVan;
        }
        public bool TraSan(int Ma_ThueSan, DateTime thoiGianKetThuc, int donGia, int thanhTien)
        {
            KetQuaTruyVan = sanMod.TraSan(Ma_ThueSan, thoiGianKetThuc, donGia, thanhTien);
            ThongBaoTruyVan = sanMod.ThongBaoTruyVan;
            return KetQuaTruyVan;
        }
        public bool Xoa(int Ma_ThueSan)
        {
            KetQuaTruyVan = sanMod.Xoa(Ma_ThueSan);
            ThongBaoTruyVan = sanMod.ThongBaoTruyVan;
            return KetQuaTruyVan;
        }
    }
}
