CREATE DATABASE QuanLyCuaHangSach
USE QuanLyCuaHangSach
GO

--tạo bảng nxb và ràng buộc
CREATE TABLE tblNXB(
	sMaNXB VARCHAR(10) NOT NULL,
	sTenNXB NVARCHAR(25) UNIQUE NULL,
	sSDT VARCHAR(10) UNIQUE NULL,
	sDC NVARCHAR(255)NULL,
	CONSTRAINT PK_sMaNXB PRIMARY KEY(sMaNXB)
);

--tạo bảng sách và ràng buộc
CREATE TABLE tblSach(
	sMasach VARCHAR(10) NOT NULL,
	sTensach NVARCHAR(255) NULL,
	sMaNXB VARCHAR(10) NOT NULL,
	sTacgia NVARCHAR(255) NULL,
	sTheloai NVARCHAR(255) NULL,
	iSLSach INT DEFAULT 0 ,

	CONSTRAINT PK_sMasach PRIMARY KEY(sMasach),
	CONSTRAINT FK_Sach_NXB FOREIGN KEY(sMaNXB)
	REFERENCES tblNXB(sMaNXB),
	
	CONSTRAINT CHK_iSLSach CHECK (iSLSach>=0)
);

alter table tblSach
add constraint ucTensach UNIQUE (sTensach)

--tạo bảng nhân viên và ràng buộc
CREATE TABLE tblNhanVien(
	sMaNV VARCHAR(10) NOT NULL,
	sTenNV NVARCHAR(25) NULL,
	dNgaysinh DATETIME NULL,
	bGioitinh bit NULL,
	sDiachi NVARCHAR(255) NULL,
	sSDT VARCHAR(10) Unique NULL,
	fHSL FLOAT NULL,
	fPC FLOAT NULL,
	dNgayvaolam DATE NULL,

	CONSTRAINT PK_sMaNV PRIMARY KEY(sMaNV),
	CONSTRAINT CHK_fHSL CHECK (fHSL>0),
	CONSTRAINT CHK_fPC CHECK (fPC>0),
	CONSTRAINT CHK_dNgayvaolam CHECK (dNgayvaolam<=GETDATE()),
	CONSTRAINT CHK_dNgaysinh CHECK (dNgaysinh<=GETDATE())
);

alter table tblNhanVien
add CONSTRAINT  CHK_dTuoidilam CHECK (DATEDIFF(year,dNgaysinh,dNgayvaolam) >= 18)

--tạo hóa đơn và ràng buộc
CREATE TABLE tblHoaDonXuat(
	sMaHDX VARCHAR(10) NOT NULL,
	sMaNV VARCHAR(10) NULL,
	dNgayLap DATE NULL,

	CONSTRAINT PK_sMaHDX PRIMARY KEY(sMaHDX),
	CONSTRAINT FK_HoaDonX_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES tblNhanVien(sMaNV),
	CONSTRAINT CHK_dNgayLapHDX CHECK (dNgayLap<=GETDATE())
);


--tạo bảng chi tiết hóa đơn và ràng buộc
CREATE TABLE tblChiTietHDX(
	sMaHDX VARCHAR(10) NOT NULL,
	sMasach VARCHAR(10) NOT NULL,
	iSL INT NULL,
	fDGban FLOAT NULL,

	CONSTRAINT PK_sMaHDX_sMasach PRIMARY KEY(sMaHDX,sMasach),
	CONSTRAINT CHK_iSLHDX CHECK (iSL>0),
	CONSTRAINT CHK_fDGban CHECK (fDGban>0),
	CONSTRAINT FK_ChiTietHDX_HoaDonXuat FOREIGN KEY(sMaHDX)
	REFERENCES tblHoaDonXuat(sMaHDX),
	CONSTRAINT FK_ChiTietHDX_Sach FOREIGN KEY(sMasach)
	REFERENCES tblSach(sMasach)
);
alter table tblChiTietHDX
add constraint ucHDXMS UNIQUE (sMaHDX,sMasach)


CREATE TABLE tblHoaDonNhap(
	sMaHDN VARCHAR(10) NOT NULL,
	sMaNV VARCHAR(10) NULL,
	dNgayLap DATETIME NULL,
	CONSTRAINT PK_sMaHDN PRIMARY KEY(sMaHDN),
	CONSTRAINT FK_HoaDonNhap_NhanVien FOREIGN KEY(sMaNV)
	REFERENCES tblNhanVien(sMaNV),
	CONSTRAINT CHK_dNgayLapHDN CHECK (dNgayLap<=GETDATE())
);


--tạo bảng chi tiết hóa đơn và ràng buộc
CREATE TABLE tblChiTietHDN(
	sMaHDN VARCHAR(10) NOT NULL,
	sMasach VARCHAR(10) NOT NULL,
	iSL INT NULL,
	fDGmua FLOAT NULL,

	CONSTRAINT PK_sMaHDN_sMasach PRIMARY KEY(sMaHDN,sMasach),
	CONSTRAINT CHK_iSLHDN CHECK (iSL>0),
	CONSTRAINT CHK_fDGmua CHECK (fDGmua>0),
	CONSTRAINT FK_ChiTietHDN_HoaDonNhap FOREIGN KEY(sMaHDN)
	REFERENCES tblHoaDonNhap(sMaHDN),
	CONSTRAINT FK_ChiTietHDN_Sach FOREIGN KEY(sMasach)
	REFERENCES tblSach(sMasach)
);

alter table tblChiTietHDN
add constraint ucHDNMS UNIQUE (sMaHDN,sMasach)

CREATE TABLE tblTaiKhoan(
	sTenDangNhap VARCHAR(50) NOT NULL,
	sMatKhau VARCHAR(50) NOT NULL,
	
	CONSTRAINT PK_sTenDangNhap PRIMARY KEY(sTenDangNhap)
);
-- Tài khoản
create procedure them_TK
@sTenDangNhap VARCHAR(50),
@sMatKhau VARCHAR(50)
AS
begin 
	INSERT INTO tblTaiKhoan VALUES (@sTenDangNhap,@sMatKhau)
end
-----NXB-------
--proc them nxb
create procedure them_NXB
@MaNXB VARCHAR(10),
@TenNXB NVARCHAR(25),
@SDT VARCHAR(10),
@DC NVARCHAR(255)
AS
begin 
	INSERT INTO tblNXB VALUES (@MaNXB,@TenNXB,@SDT,@DC)
end

exec them_NXB '241',N'Kim Đồng','0696969669',N'Hà Nội'
select * from tblNXB

--proc xoa nxb
create procedure xoa_NXB
@MaNXB VARCHAR(10)
AS
begin 
	delete from tblNXB where (@MaNXB=sMaNXB)
end
exec xoa_NXB '241'
create proc procSuaNXB
@MaNXB VARCHAR(10),
@TenNXB NVARCHAR(25),
@SDT VARCHAR(10),
@DC NVARCHAR(255)

as
begin 
	Update tblNXB
	Set sMaNXB=@MaNXB, sTenNXB=@TenNXB,sDC=@DC,sSDT=@SDT
	where sMaNXB=@MaNXB
end
----SÁCH-------
alter procedure them_sach
@Masach VARCHAR(10),
@Tensach NVARCHAR(255),
@MaNXB VARCHAR(10),
@Tacgia NVARCHAR(255),
@Theloai NVARCHAR(255),
@Soluong int
as 
begin 
	insert into tblSach values (@Masach,@Tensach,@MaNXB,@Tacgia,@Theloai,@Soluong)
end

exec them_sach '22',N'dark nhân tâm','241',N'hung',N'chúa hề'
delete from tblSach where sMasach = '21'
select * from tblSach

alter procedure xoa_sach
@Masach VARCHAR(10)
as 
begin 
	delete from tblSach where (@Masach=sMasach)
end

exec xoa_sach '21'
create proc procSuaSach
@Masach VARCHAR(10),
@Tensach NVARCHAR(255),
@MaNXB varchar(10),
@Tacgia NVARCHAR(255),
@Theloai nVARCHAR(255),
@Soluong int 
as
begin 
	Update tblSach
	Set sMasach=@Masach, sTensach=@Tensach,sTacgia=@Tacgia,sMaNXB =@MaNXB, sTheloai=@Theloai, iSLSach=@SoLuong
	where sMasach=@Masach
end
alter trigger trg_xoa_nxb
on tblNXB
instead of delete
as
begin
declare @MaNXB varchar(10)
select @MaNXB = sMaNXB from deleted
if exists( select *from tblSach where sMaNXB = @MaNXB)
	begin
	delete tblSach where sMaNXB = @MaNXB
	delete tblNXB where sMaNXB = @MaNXB
	end
end
create procedure sua_sach_theo_ma
@Masach VARCHAR(10),
@Tensach NVARCHAR(255)
as
begin 
	update tblSach
	set sTensach=@Tensach
	where sMasach=@Masach
end

create procedure sua_nxb_theo_ma
@Manxb VARCHAR(10),
@Tennxb NVARCHAR(25)
as
begin 
	update tblNXB
	set sTenNXB=@Tennxb
	where sMaNXB=@Manxb
end

select * from tblNXB

select * from tblSach

--thủ tục liên quan đến nhân viên

create proc procThemNhanVien
@MaNV VARCHAR(10),
@TenNV NVARCHAR(25),
@Ngaysinh DATE, 
@Gioitinh bit,
@Diachi NVARCHAR(255),
@SDT VARCHAR(10),
@HSL FLOAT,
@PC FLOAT,
@Ngayvaolam DATE
as
begin 
	insert into tblNhanVien values (@MaNV,@TenNV,@Ngaysinh,@Gioitinh,@Diachi,@SDT,@HSL,@PC,@Ngayvaolam)
end

exec procThemNhanVien '001',N'Hùng','3/20/1990',1,N'Hà Nội','0123456789',2,30000,'3/20/2012'
exec procThemNhanVien '002',N'Linh','3/20/1990',0,N'Hà Nội','0123456241',3,200000,'5/20/2012'

--luong co ban =1000000

CREATE VIEW vDanhSachNhanVien 
AS
with Luongcoban(luong) as (
	select 100000 as 'luong'
	)
SELECT sMaNV as N'Mã Nhân viên', sTenNV , dNgaysinh as N'Ngày sinh',
case bGioitinh  WHEN 1 THEN N'Nam' ELSE N'Nữ' END 
as N'Giới tính',sDiachi as N'Địa chỉ',
sSDT as N'Số điện thoại', fHSL as N'Hệ số lương',
fPC as N'Phụ Cấp', fHSL*luong+fPC as N'Lương',dNgayvaolam N'Ngày vào làm'
FROM tblNhanVien,Luongcoban

select * from vDanhSachNhanVien

create proc procSuaNhanVien
@MaNV VARCHAR(10),
@TenNV NVARCHAR(25),
@Ngaysinh DATE,
@Gioitinh bit,
@Diachi NVARCHAR(255),
@SDT VARCHAR(10),
@HSL FLOAT,
@PC FLOAT,
@Ngayvaolam DATE
as
begin 
	Update tblNhanVien
	Set sTenNV=@TenNV,dNgaysinh=@Ngaysinh,bGioitinh=@Gioitinh
	,sDiachi=@Diachi,sSDT=@SDT,fHSL=@HSL,fPC=@PC,dNgayvaolam=@Ngayvaolam
	where sMaNV=@MaNV
end

create proc procXoaNhanVien
@MaNV VARCHAR(10)
as
begin 
	delete from tblNhanVien
	where sMaNV=@MaNV
end

select * from vDanhSachNhanVien where sTenNV like N'%Hù%'


--thủ tục liên quan đến hóa đơn nhap
create VIEW vDanhSachHoaDonNhap
AS
SELECT sMaHDN as N'Mã hóa đơn', sMaNV as N'Mã nhân viên', 
(
	select sTenNV
	FROM  tblNhanVien 
	where tblNhanVien.sMaNV=tblHoaDonNhap.sMaNV
) as N'Tên nhân viên',
dNgayLap N'Ngày lập', (
	select SUM(iSL*fDGmua)
	FROM  tblChiTietHDN
	where sMaHDN=tblHoaDonNhap.sMaHDN
	GROUP BY sMaHDN
) as N'Tổng tiền'
FROM tblHoaDonNhap 

select *from vDanhSachHoaDonNhap


create proc procThemHDN
@MaHDN VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	insert into tblHoaDonNhap values (@MaHDN,@MaNV,@NgayLap)

execute procThemHDN 'HDN001','001','03/04/2019'
execute procThemHDN 'HDN002','002','03/04/2018'

create proc procSuaHDN
@MaHDN VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	update tblHoaDonNhap set sMaNV=@MaNV,dNgayLap=@NgayLap where  sMaHDN = @MaHDN


create proc procXoaHDN
@MaHDN VARCHAR(10)
as
	delete from tblHoaDonNhap where  sMaHDN=@MaHDN

exec procXoaHDN N'HDN001'
select * from tblHoaDonNhap
select * from tblSach

-- proc chi tiet hd nhap

select * from tblChiTietHDN
select * from tblHoaDonNhap
select * from tblSach

create proc procThemChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGmua FLOAT
as
	insert tblChiTietHDN values (@MaHDN,@Masach,@SL,@DGmua)

exec procThemChiTietHDN 'HDN001','22',30,4000

create proc procXoaChiTietHDN
@MaHDN VARCHAR(10)

as
	delete from tblChiTietHDN where  sMaHDN =@MaHDN 

create proc procSuaChiTietHDN
@MaHDN VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGmua FLOAT
as
	update tblChiTietHDN set iSL=@SL, fDGmua = @DGmua where  sMaHDN = @MaHDN and sMasach=@Masach

create view vDanhSachChiTietHoaDonNhap
as
select sMaHDN, sMasach, 
(
	select sTensach
	FROM  tblSach 
	where tblSach.sMasach=tblChiTietHDN.sMasach
) as N'Ten sach',
iSL,fDGmua,
(iSL*fDGmua) as 'tong tien'
from tblChiTietHDN

select * from  vDanhSachChiTietHoaDonNhap

-- trigger chi tiet HDN va sach
create trigger trInsertChiTietHDN_Sach
on tblChiTietHDN
after insert
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from inserted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach + @sosach
			WHERE sMasach = @masach
		END
	
end


create trigger trDeleteChiTietHDN_Sach
on tblChiTietHDN
for delete
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from deleted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach) and @sosach <= (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @sosach
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể xóa vì đã không còn đủ sách này'
			ROLLBACK TRAN
		END
end


CREATE TRIGGER UpdateChiTietHDN_Sach
ON tblChiTietHDN
FOR UPDATE
AS
BEGIN

	DECLARE @slmoi int, @slcu int, @masach VARCHAR(10)
	SELECT @slmoi = iSL,@masach=sMasach FROM inserted
	SELECT @slcu = iSL FROM deleted
	

	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
	and  (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)-@slcu+@slmoi>=0
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @slcu+@slmoi
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể sửa được'
			ROLLBACK TRAN
		END
END

-----HÓA ĐƠN XUẤT-------
create VIEW vDanhSachHoaDonXuat
AS
SELECT sMaHDX as N'Mã hóa đơn', sMaNV as N'Mã nhân viên', 
(
	select sTenNV
	FROM  tblNhanVien 
	where tblNhanVien.sMaNV=tblHoaDonXuat.sMaNV
) as N'Tên nhân viên',
dNgayLap N'Ngày lập', (
	select SUM(iSL*fDGban)
	FROM  tblChiTietHDX
	where sMaHDX=tblHoaDonXuat.sMaHDX
	GROUP BY sMaHDX
) as N'Tổng tiền'
FROM tblHoaDonXuat

create proc procThemHDX
@MaHDX VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	insert into tblHoaDonXuat values (@MaHDX,@MaNV,@NgayLap)



create proc procSuaHDX
@MaHDX VARCHAR(10),
@MaNV VARCHAR(10),
@NgayLap DATE
as
	update tblHoaDonXuat set sMaNV=@MaNV,dNgayLap=@NgayLap where  sMaHDX = @MaHDX

create proc procXoaHDX
@MaHDX VARCHAR(10)
as
	delete from tblHoaDonXuat where  sMaHDX=@MaHDX

select * from tblHoaDonNhap
select * from tblSach


-----CHI TIẾT HÓA ĐƠN XUÂT------
create view vDanhSachChiTietHoaDonXuat
as
select sMaHDX, sMasach, 
(
	select sTensach
	FROM  tblSach 
	where tblSach.sMasach=tblChiTietHDX.sMasach
) as N'Ten sach',
iSL,fDGban,
(iSL*fDGban) as 'tong tien'
from tblChiTietHDX

create proc procThemChiTietHDX
@MaHDX VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGban FLOAT
as
	insert tblChiTietHDX values (@MaHDX,@Masach,@SL,@DGban)


alter proc procXoaChiTietHDX
@MaHDX VARCHAR(10),
@MaSach VARCHAR(10)
as
	delete from tblChiTietHDX where  sMaHDX =@MaHDX and sMasach = @MaSach

create proc procSuaChiTietHDX
@MaHDX VARCHAR(10),
@Masach VARCHAR(10),
@SL INT,
@DGban FLOAT
as
	update tblChiTietHDX set iSL=@SL, fDGban = @DGban where  sMaHDX = @MaHDX and sMasach=@Masach

select * from  vDanhSachChiTietHoaDonNhap

-- trigger chi tiet HDX va sach
alter trigger trInsertChiTietHDX_Sach
on tblChiTietHDX
after insert
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from inserted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @sosach
			WHERE sMasach = @masach
		END
	
end


alter trigger trDeleteChiTietHDX_Sach
on tblChiTietHDX
for delete
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from deleted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach) and @sosach <= (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach + @sosach
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể xóa vì đã không còn đủ sách này'
			ROLLBACK TRAN
		END
end


alter TRIGGER UpdateChiTietHDX_Sach
ON tblChiTietHDX
FOR UPDATE
AS
BEGIN

	DECLARE @slmoi int, @slcu int, @masach VARCHAR(10)
	SELECT @slmoi = iSL,@masach=sMasach FROM inserted
	SELECT @slcu = iSL FROM deleted
	

	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
	and  (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)-@slcu+@slmoi>=0
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach + @slcu-@slmoi
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể sửa được'
			ROLLBACK TRAN
		END
END

-- trigger chi tiet HDN va sach
create trigger trInsertChiTietHDN_Sach
on tblChiTietHDN
after insert
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from inserted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach + @sosach
			WHERE sMasach = @masach
		END
	
end


create trigger trDeleteChiTietHDN_Sach
on tblChiTietHDN
for delete
as 
begin
	declare @sosach INT,@masach varchar(10)
	select @sosach=iSL,@masach=sMasach from deleted
	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach) and @sosach <= (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @sosach
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể xóa vì đã không còn đủ sách này'
			ROLLBACK TRAN
		END
end


CREATE TRIGGER UpdateChiTietHDN_Sach
ON tblChiTietHDN
FOR UPDATE
AS
BEGIN

	DECLARE @slmoi int, @slcu int, @masach VARCHAR(10)
	SELECT @slmoi = iSL,@masach=sMasach FROM inserted
	SELECT @slcu = iSL FROM deleted
	

	IF EXISTS(SELECT * FROM tblSach WHERE sMasach = @masach)
	and  (SELECT iSLSach FROM tblSach WHERE sMasach = @masach)-@slcu+@slmoi>=0
		BEGIN
			UPDATE tblSach
			SET iSLSach = iSLSach - @slcu+@slmoi
			WHERE sMasach = @masach
		END
	ELSE
		BEGIN
			print N'Không thể sửa được'
			ROLLBACK TRAN
		END
END



ALTER TRIGGER Delete_HoaDonNhap
ON tblHoaDonNhap
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMaHDN from deleted

	IF EXISTS(SELECT * FROM tblChiTietHDN WHERE sMaHDN = @MaCTHD)
		BEGIN
			DELETE tblChiTietHDN
			WHERE sMaHDN = @MaCTHD

			DELETE tblHoaDonNhap
			WHERE sMaHDN = @MaCTHD
		END

	
END

ALTER TRIGGER Delete_HoaDonNhap
ON tblHoaDonNhap
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMaHDN from deleted

	IF EXISTS(SELECT * FROM tblChiTietHDN WHERE sMaHDN = @MaCTHD)
		BEGIN
			DELETE tblChiTietHDN
			WHERE sMaHDN = @MaCTHD

			DELETE tblHoaDonNhap
			WHERE sMaHDN = @MaCTHD
		END

	
END

create view vv_HoaDon_NV
AS
select tblNhanVien.sMaNV,sTenNV, tblHoaDonNhap.sMaHDN as[Mã hóa đơn nhập]
from tblNhanVien left join tblHoaDonNhap on tblHoaDonNhap.sMaNV = tblNhanVien.sMaNV 

Create TRIGGER Delete_HoaDonXuat
ON tblHoaDonXuat
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMaHDX from deleted

	IF EXISTS(SELECT * FROM tblChiTietHDX WHERE sMaHDX = @MaCTHD)
		BEGIN
			DELETE tblChiTietHDX
			WHERE sMaHDX = @MaCTHD

			DELETE tblHoaDonXuat
			WHERE sMaHDX = @MaCTHD
		END

	
END

alter TRIGGER Delete_nxb_sach
ON tblNXB
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMaNXB from deleted

	IF EXISTS(SELECT * FROM tblSach WHERE sMaNXB = @MaCTHD)
		BEGIN
			DELETE tblSach
			WHERE sMaNXB = @MaCTHD

			DELETE tblNXB
			WHERE sMaNXB = @MaCTHD
		END

	
END

alter TRIGGER Delete_sach_CThd
ON tblSach
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMasach from deleted

	IF EXISTS(SELECT * FROM tblChiTietHDN WHERE sMasach = @MaCTHD)
		BEGIN
			DELETE tblChiTietHDN
			WHERE sMasach = @MaCTHD

			
			
		END

	IF EXISTS(SELECT * FROM tblChiTietHDX WHERE sMasach = @MaCTHD)
		BEGIN
			DELETE tblChiTietHDX
			WHERE sMasach = @MaCTHD

			
		END
		DELETE tblSach
			WHERE sMasach = @MaCTHD
	
END

create TRIGGER Delete_nv_hd
ON tblNhanVien
INSTEAD OF DELETE
AS
BEGIN

	declare @MaCTHD varchar(10)
	SELECT @MaCTHD = sMaNV from deleted

	IF EXISTS(SELECT * FROM tblHoaDonNhap WHERE sMaNV = @MaCTHD)
		BEGIN
			DELETE tblHoaDonNhap
			WHERE sMaNV = @MaCTHD

			
			
		END

	IF EXISTS(SELECT * FROM tblHoaDonXuat WHERE sMaNV = @MaCTHD)
		BEGIN
			DELETE tblHoaDonXuat
			WHERE sMaNV = @MaCTHD

			
		END
		DELETE tblNhanVien
			WHERE sMaNV = @MaCTHD

	
END



