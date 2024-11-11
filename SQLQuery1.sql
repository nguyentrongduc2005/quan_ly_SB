CREATE TABLE DoanhThu
(
    Ma_KhachHang VARCHAR(100),
    Ma_San VARCHAR(100) NOT NULL,
    NgayLap_HD [date] NOT NULL,
    TongPhut_Da INT NOT NULL,
    DonGia [FLOAT] NULL,
    TongTien_HD FLOAT NULL,
    FOREIGN KEY(Ma_KhachHang) REFERENCES dbo.KhachHang(Ma_KhachHang)
)