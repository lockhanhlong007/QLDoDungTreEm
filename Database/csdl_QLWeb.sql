USE [master]
GO
/****** Object:  Database [QLDODUNGTREEM]    Script Date: 11/27/2019 10:42:41 AM ******/
CREATE DATABASE [QLDODUNGTREEM]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QLDODUNGTREEM', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLDODUNGTREEM.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QLDODUNGTREEM_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\QLDODUNGTREEM_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [QLDODUNGTREEM] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QLDODUNGTREEM].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QLDODUNGTREEM] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET ARITHABORT OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QLDODUNGTREEM] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QLDODUNGTREEM] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET  ENABLE_BROKER 
GO
ALTER DATABASE [QLDODUNGTREEM] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QLDODUNGTREEM] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET RECOVERY FULL 
GO
ALTER DATABASE [QLDODUNGTREEM] SET  MULTI_USER 
GO
ALTER DATABASE [QLDODUNGTREEM] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QLDODUNGTREEM] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QLDODUNGTREEM] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QLDODUNGTREEM] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QLDODUNGTREEM] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'QLDODUNGTREEM', N'ON'
GO
ALTER DATABASE [QLDODUNGTREEM] SET QUERY_STORE = OFF
GO
USE [QLDODUNGTREEM]
GO
/****** Object:  Table [dbo].[CTDonHang]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CTDonHang](
	[MaDH] [int] NOT NULL,
	[MaSP] [nchar](20) NOT NULL,
	[SoLuong] [int] NULL,
	[DonGia] [decimal](24, 0) NULL,
 CONSTRAINT [PK_CTDonHang] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC,
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DanhMuc]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMuc](
	[MaDM] [int] IDENTITY(1,1) NOT NULL,
	[TenDM] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Uni_TenDM] UNIQUE NONCLUSTERED 
(
	[TenDM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DonHang]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DonHang](
	[MaDH] [int] IDENTITY(1,1) NOT NULL,
	[MaKH] [int] NULL,
	[NgayGiao] [date] NULL,
	[NgayDat] [date] NOT NULL,
	[DaThanhToan] [bit] NOT NULL,
	[TinhTrangGiaoHang] [bit] NOT NULL,
 CONSTRAINT [PK__DonHang__27258661FE3F4F63] PRIMARY KEY CLUSTERED 
(
	[MaDH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKH] [int] IDENTITY(1,1) NOT NULL,
	[TaiKhoan] [varchar](250) NULL,
	[MatKhau] [varchar](250) NULL,
	[HoTen] [nvarchar](250) NULL,
	[NgaySinh] [date] NULL,
	[GioiTinh] [nchar](30) NULL,
	[DienThoai] [nchar](15) NULL,
	[Email] [varchar](250) NULL,
	[DiaChi] [nvarchar](250) NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK__KhachHan__2725CF1E976E20B9] PRIMARY KEY CLUSTERED 
(
	[MaKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Uni_DienThoai] UNIQUE NONCLUSTERED 
(
	[DienThoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoaiSP]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSP](
	[MaLoai] [int] IDENTITY(1,1) NOT NULL,
	[MaDM] [int] NULL,
	[TenLoaiSP] [nvarchar](250) NULL,
 CONSTRAINT [PK__LoaiSP__730A5759B9991D12] PRIMARY KEY CLUSTERED 
(
	[MaLoai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Uni_TenLoaiSP] UNIQUE NONCLUSTERED 
(
	[TenLoaiSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Manager]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Manager](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [nvarchar](150) NULL,
	[Password] [nvarchar](250) NULL,
	[Name] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](250) NULL,
	[Phone] [nvarchar](250) NULL,
	[GroupID] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UNI_UserName] UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ManagerGroup]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ManagerGroup](
	[ID_Group] [varchar](20) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Group] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Permission]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permission](
	[ID_Group] [varchar](20) NOT NULL,
	[ID_Role] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Group] ASC,
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[ID_Role] [varchar](50) NOT NULL,
	[Name] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Role] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSP] [nchar](20) NOT NULL,
	[MaThuongHieu] [int] NULL,
	[MaLoai] [int] NULL,
	[TenSP] [nvarchar](300) NULL,
	[Hinh] [nvarchar](700) NULL,
	[GiaBan] [int] NULL,
	[NhaSanXuat] [nvarchar](250) NULL,
	[XuatXu] [nvarchar](250) NULL,
	[DungTich] [nvarchar](250) NULL,
	[ChatLieu] [nvarchar](250) NULL,
	[DoiTuong] [nvarchar](250) NULL,
	[CreatedDate] [date] NULL,
	[Description] [nvarchar](max) NULL,
 CONSTRAINT [PK__SanPham__2725081CCF802F76] PRIMARY KEY CLUSTERED 
(
	[MaSP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Slide]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slide](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Image] [nvarchar](250) NULL,
	[DisplayOrder] [int] NULL,
	[status] [bit] NOT NULL,
 CONSTRAINT [PK__Slide__3214EC27FF5A04F1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[MaThuongHieu] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[MaThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [Uni_TenThuongHieu] UNIQUE NONCLUSTERED 
(
	[TenThuongHieu] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_NgayDat]  DEFAULT (getdate()) FOR [NgayDat]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_DaThanhToan]  DEFAULT ((0)) FOR [DaThanhToan]
GO
ALTER TABLE [dbo].[DonHang] ADD  CONSTRAINT [DF_DonHang_TinhTrangGiaoHang]  DEFAULT ((0)) FOR [TinhTrangGiaoHang]
GO
ALTER TABLE [dbo].[Manager] ADD  CONSTRAINT [DF_Manager_GroupID]  DEFAULT ('Moderatior') FOR [GroupID]
GO
ALTER TABLE [dbo].[SanPham] ADD  CONSTRAINT [DF_SanPham_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_DH] FOREIGN KEY([MaDH])
REFERENCES [dbo].[DonHang] ([MaDH])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_DH]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [FK_CTDonHang_SP] FOREIGN KEY([MaSP])
REFERENCES [dbo].[SanPham] ([MaSP])
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [FK_CTDonHang_SP]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [FK_DH_KH] FOREIGN KEY([MaKH])
REFERENCES [dbo].[KhachHang] ([MaKH])
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [FK_DH_KH]
GO
ALTER TABLE [dbo].[LoaiSP]  WITH CHECK ADD  CONSTRAINT [FK_LoaiSP_DM] FOREIGN KEY([MaDM])
REFERENCES [dbo].[DanhMuc] ([MaDM])
GO
ALTER TABLE [dbo].[LoaiSP] CHECK CONSTRAINT [FK_LoaiSP_DM]
GO
ALTER TABLE [dbo].[Manager]  WITH CHECK ADD  CONSTRAINT [FK_Manager_ManagerGroup] FOREIGN KEY([GroupID])
REFERENCES [dbo].[ManagerGroup] ([ID_Group])
GO
ALTER TABLE [dbo].[Manager] CHECK CONSTRAINT [FK_Manager_ManagerGroup]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Premission_Group] FOREIGN KEY([ID_Group])
REFERENCES [dbo].[ManagerGroup] ([ID_Group])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Premission_Group]
GO
ALTER TABLE [dbo].[Permission]  WITH CHECK ADD  CONSTRAINT [FK_Premission_Role] FOREIGN KEY([ID_Role])
REFERENCES [dbo].[Role] ([ID_Role])
GO
ALTER TABLE [dbo].[Permission] CHECK CONSTRAINT [FK_Premission_Role]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SP_LoaiSP] FOREIGN KEY([MaLoai])
REFERENCES [dbo].[LoaiSP] ([MaLoai])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SP_LoaiSP]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SP_ThuongHieu] FOREIGN KEY([MaThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([MaThuongHieu])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SP_ThuongHieu]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [CHK_DonGia] CHECK  ((len([DonGia])>(3)))
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [CHK_DonGia]
GO
ALTER TABLE [dbo].[CTDonHang]  WITH CHECK ADD  CONSTRAINT [CHK_SoLuong] CHECK  (([SoLuong]>(0)))
GO
ALTER TABLE [dbo].[CTDonHang] CHECK CONSTRAINT [CHK_SoLuong]
GO
ALTER TABLE [dbo].[DonHang]  WITH CHECK ADD  CONSTRAINT [CHK_NgayDat_NgayGiao] CHECK  ((datediff(day,[NgayDat],[NgayGiao])>=(0)))
GO
ALTER TABLE [dbo].[DonHang] CHECK CONSTRAINT [CHK_NgayDat_NgayGiao]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_DienThoai] CHECK  ((len([DienThoai])>=(8) AND len([DienThoai])<=(12)))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_DienThoai]
GO
ALTER TABLE [dbo].[KhachHang]  WITH CHECK ADD  CONSTRAINT [CHK_GioiTinh] CHECK  (([GioiTinh]='Nam' OR [GioiTinh]=N'Nữ'))
GO
ALTER TABLE [dbo].[KhachHang] CHECK CONSTRAINT [CHK_GioiTinh]
GO
/****** Object:  StoredProcedure [dbo].[CapNhatDanhMuc]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatDanhMuc]
(
	@MaDM int,
	@TenDM nvarchar(250)
)
as
begin
	update DanhMuc
	set TenDM=@TenDM where MaDM=@MaDM
end

GO
/****** Object:  StoredProcedure [dbo].[CapNhatLoaiSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatLoaiSanPham]
(
	@MaLoai int,
	@MaDM int,
	@TenLoaiSP nvarchar(250)
)
as
begin
	update LoaiSP
	set MaDM = @MaDM,TenLoaiSP=@TenLoaiSP where MaLoai=@MaLoai
end

GO
/****** Object:  StoredProcedure [dbo].[CapNhatSP]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[CapNhatSP]
(
	@MaSP nchar(20),
	@MaThuongHieu int,
	@MaLoai int,
	@TenSP nvarchar(300),
	@Hinh nvarchar(700),
	@GiaBan int,
	@NhaSanXuat nvarchar(250),
	@XuatXu nvarchar(250),
	@DungTich nvarchar(250),
	@ChatLieu nvarchar(250),
	@DoiTuong nvarchar(250),
	@Description nvarchar(Max)

)
as
begin
update SanPham
set MaThuongHieu = @MaThuongHieu,MaLoai=@MaLoai,Hinh=@Hinh,GiaBan=@GiaBan,NhaSanXuat=@NhaSanXuat,XuatXu=@XuatXu,DungTich=@DungTich,ChatLieu=@ChatLieu,DoiTuong=@DoiTuong,TenSP=@TenSP,Description=@Description where MaSP=@MaSP
end

GO
/****** Object:  StoredProcedure [dbo].[CapNhatThuongHieu]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CapNhatThuongHieu]
(
	@MaThuongHieu int,
	@TenThuongHieu nvarchar(250)
)
as
begin
	update ThuongHieu
	set TenThuongHieu=@TenThuongHieu where MaThuongHieu=@MaThuongHieu
end

GO
/****** Object:  StoredProcedure [dbo].[CategoryDM]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CategoryDM]
as
begin
select DanhMuc.MaDM,DanhMuc.TenDM,LoaiSP.MaLoai,LoaiSP.TenLoaiSP  from DanhMuc,LoaiSP where DanhMuc.MaDM = LoaiSP.MaDM
end

GO
/****** Object:  StoredProcedure [dbo].[CategoryLoaiSP]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[CategoryLoaiSP]
as
begin
select LoaiSP.MaLoai,LoaiSP.TenLoaiSP,SanPham.MaSP,SanPham.TenSP,ThuongHieu.MaThuongHieu,ThuongHieu.TenThuongHieu  from LoaiSP,SanPham,ThuongHieu where LoaiSP.MaLoai = SanPham.MaLoai and SanPham.MaThuongHieu = ThuongHieu.MaThuongHieu
end

GO
/****** Object:  StoredProcedure [dbo].[ChangeStatus_KhachHang]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangeStatus_KhachHang]
(
	@MaKH int,
	@Status bit
)
as
begin
update KhachHang
set Status = @Status where MaKH = @MaKH
end

GO
/****** Object:  StoredProcedure [dbo].[ChangeTinhTrangGiao]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChangeTinhTrangGiao]
(
	@MaDH int,
	@TinhTrangGiaoHang bit,
		@DaThanhToan bit
)
as
begin
update DonHang
set TinhTrangGiaoHang = @TinhTrangGiaoHang,DaThanhToan = @DaThanhToan where MaDH = @MaDH
end

GO
/****** Object:  StoredProcedure [dbo].[ChiTietSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ChiTietSanPham]
(
	@MaSP nchar(20)
)
as
begin
	select * from SanPham where MaSP=@MaSP
end

GO
/****** Object:  StoredProcedure [dbo].[LayChiTietHoaDon]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LayChiTietHoaDon]
(
	@MaDH int
)
as
begin
	select   CTDonHang.MaDH,TenSP,SoLuong,DonGia  from CTDonHang,SanPham where SanPham.MaSP = CTDonHang.MaSP and CTDonHang.MaDH = @MaDH
end

GO
/****** Object:  StoredProcedure [dbo].[LayHoaDon]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[LayHoaDon]
as
begin
	select DISTINCT DonHang.MaDH,KhachHang.HoTen,NgayGiao,NgayDat,DaThanhToan,TinhTrangGiaoHang    from KhachHang,CTDonHang,DonHang where KhachHang.MaKH = DonHang.MaKH and CTDonHang.MaDH = CTDonHang.MaDH
end

GO
/****** Object:  StoredProcedure [dbo].[LayLoaiSanPhamTheoDM]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------- Loai San Pham------------------------------------------------------------------------------------------------------------
create proc [dbo].[LayLoaiSanPhamTheoDM]
(
	@MaDM int
)
as
begin
	select * from LoaiSP where MaDM = @MaDM
end

GO
/****** Object:  StoredProcedure [dbo].[LaySanPhamTheoLoaiSP]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[LaySanPhamTheoLoaiSP]
(
	@MaLoai int,
	@MaThuongHieu int
) 
as
begin
select * from SanPham where MaLoai = @MaLoai or MaThuongHieu = @MaThuongHieu
end

GO
/****** Object:  StoredProcedure [dbo].[ThemDanhMuc]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------- Danh Muc --------------------------------------------------------------------
create proc [dbo].[ThemDanhMuc]
(
	@TenDM nvarchar(250)
)
as
begin
	Insert into DanhMuc(TenDM) values(@TenDM)
end

GO
/****** Object:  StoredProcedure [dbo].[ThemLoaiSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ThemLoaiSanPham]
(
	@MaDM int,
	@TenLoaiSP nvarchar(250)
)
as
begin
	insert into LoaiSP(MaDM,TenLoaiSP) values(@MaDM,@TenLoaiSP)
end

GO
/****** Object:  StoredProcedure [dbo].[ThemSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[ThemSanPham]
(
	@MaSP nchar(20),
	@MaThuongHieu int,
	@MaLoai int,
	@Hinh nvarchar(700),
	@GiaBan int,
	@NhaSanXuat nvarchar(250),
	@XuatXu nvarchar(250),
	@DungTich nvarchar(250),
	@ChatLieu nvarchar(250),
	@DoiTuong nvarchar(250),
	@TenSP nvarchar(300),
	@CreatedDate date,
	@Description nvarchar(max)
)
as
begin
	insert into SanPham(MaSP,MaThuongHieu,MaLoai,TenSP,Hinh,GiaBan,NhaSanXuat,XuatXu,DungTich,ChatLieu,DoiTuong,CreatedDate,Description) values(@MaSP,@MaThuongHieu,@MaLoai,@TenSP,@Hinh,@GiaBan,@NhaSanXuat,@XuatXu,@DungTich,@ChatLieu,@DoiTuong,@CreatedDate,@Description)	
end

GO
/****** Object:  StoredProcedure [dbo].[ThemThuongHieu]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--------------------------- Thuong Hieu ---------------------------------------------------
create proc [dbo].[ThemThuongHieu]
(
	@TenThuongHieu nvarchar(250)
)
as
begin
	Insert into ThuongHieu(TenThuongHieu) values(@TenThuongHieu)
end

GO
/****** Object:  StoredProcedure [dbo].[TimKiemSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[TimKiemSanPham]
(
	@MaSP char(20),
	@TenSP nvarchar(300)
)
as
begin
	select * from SanPham where MaSP = @MaSP or TenSP like @TenSP + '%'
end

GO
/****** Object:  StoredProcedure [dbo].[XoaDanhMuc]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaDanhMuc]
(
	@MaDM int
)
as
begin
	delete from DanhMuc where MaDM=@MaDM
end

GO
/****** Object:  StoredProcedure [dbo].[XoaHoaDon]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaHoaDon]
(
	@MaDH int
)
as
begin
delete from DonHang where MaDH=@MaDH
end

GO
/****** Object:  StoredProcedure [dbo].[XoaLoaiSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaLoaiSanPham]
(
	@MaLoai int
)
as
begin
	delete from LoaiSP where MaLoai=@MaLoai
end

GO
/****** Object:  StoredProcedure [dbo].[XoaSanPham]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaSanPham]
(
	@MaSP nchar(20)
)
as
begin
delete from SanPham where MaSP = @MaSP
end

GO
/****** Object:  StoredProcedure [dbo].[XoaThuongHieu]    Script Date: 11/27/2019 10:42:41 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[XoaThuongHieu]
(
	@MaThuongHieu int
)
as
begin
	delete from ThuongHieu where MaThuongHieu=@MaThuongHieu
end

GO
USE [master]
GO
ALTER DATABASE [QLDODUNGTREEM] SET  READ_WRITE 
GO
