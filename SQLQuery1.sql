CREATE TABLE KhachHang
(
    Ma_KhachHang VARCHAR(100) PRIMARY KEY,
    Ten_KhachHang NVARCHAR(100) NOT NULL DEFAULT N'Chưa nhập!',
    DiaChi_KhachHang NVARCHAR(150) NOT NULL DEFAULT N'Chưa nhập!',
    Sdt_KhachHang VARCHAR(100)  NOT NULL DEFAULT 0123456789,
)
GO

--Loại Sân
CREATE TABLE LoaiSan
(
    Loai_San VARCHAR(100) PRIMARY KEY,
    Ten_Loai NVARCHAR(100) NOT NULL,
    GiaLoai_San FLOAT,
)
--Sân
CREATE TABLE San
(
    Ma_San VARCHAR(100) PRIMARY KEY,
    Loai_San VARCHAR(100) NOT NULL,
    Ten_San NVARCHAR(100) NOT NULL,
    FOREIGN KEY(Loai_San) REFERENCES dbo.LoaiSan(Loai_San)
)
--Thuê Sân bóng
CREATE TABLE ThueSan
(
    [Ma_ThueSan] INT IDENTITY PRIMARY KEY,
    Ma_San VARCHAR(100),
    Ma_KhachHang VARCHAR(100),
    [ThoiGianBatDau] [datetime] NULL,
    [ThoiGianKetThuc] [datetime] NULL,
    [LoaiThue] [nvarchar](50) NULL,
    [DonGia] [FLOAT] NULL,
    [ThanhTien] [nchar](10) NULL,
    FOREIGN KEY(Ma_San) REFERENCES dbo.San(Ma_San),
    FOREIGN KEY(Ma_KhachHang) REFERENCES dbo.KhachHang(Ma_KhachHang),
)
--Hóa đơn
CREATE TABLE HoaDon
(
    Ma_HD INT IDENTITY PRIMARY KEY,
    Ma_KhachHang VARCHAR(100),
    Ma_San VARCHAR(100) NOT NULL,
    NgayLap_HD [date] NOT NULL,
    TongPhut_Da INT NOT NULL,
    DonGia [FLOAT] NULL,
    TongTien_HD FLOAT NULL,
    FOREIGN KEY(Ma_KhachHang) REFERENCES dbo.KhachHang(Ma_KhachHang)
)
GO
--Account
CREATE TABLE Account
(
    UserName VARCHAR(100) PRIMARY KEY,
    DisplayName NVARCHAR(100) NOT NULL,
    PassWord VARCHAR(1000) NOT NULL,
    Quyen NVARCHAR(100) NOT NULL,
)
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
--------------------
SET DATEFORMAT DMY
GO
INSERT Account(UserName, DisplayName, PassWord, Quyen) VALUES
('UTH', N'Admin', '123',N'Admin'),
('Qlinh', N'Nguyễn Quang Linh', '123',N'User')
GO
INSERT LoaiSan(Loai_San,Ten_Loai,GiaLoai_San) VALUES
('Loai1',N'Sân 6 người',20000),
('Loai2',N'Sân 10 người',40000),
('Loai3',N'Sân 14 người',80000);
GO


INSERT San(Ma_San,Loai_San,Ten_San) VALUES
('SAN1','Loai1',N'Sân 1'),
('SAN2','Loai2',N'Sân 2'),
('SAN3','Loai3',N'Sân 3'),
('SAN4','Loai1',N'Sân 4'),
('SAN5','Loai2',N'Sân 5'),
('SAN6','Loai3',N'Sân 6');
GO
-------------------------------
CREATE PROCEDURE spDSKH
(
@Ma_KhachHang VARCHAR(100)
)
AS 
BEGIN
SELECT KhachHang.*,HoaDon.NgayLap_HD,HoaDon.TongTien_HD
FROM KhachHang INNER JOIN HoaDon ON KhachHang.Ma_KhachHang=HoaDon.Ma_KhachHang
WHERE KhachHang.Ma_KhachHang=@Ma_KhachHang
END
-------------------------------
