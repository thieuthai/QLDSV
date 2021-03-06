USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[sp_SaveHocPhi]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SaveHocPhi]
@MaSV char(12),
@NienKhoa nvarchar(50),
@HocKy int,
@HocPhi int,
@SoTienDaDong int
as
INSERT INTO HOCPHI
( MASV,NIENKHOA,HOCKY,HOCPHI,SOTIENDADONG)
Values (@MaSV,@NienKhoa,@HocKy,@HocPhi,@SoTienDaDong)
GO
/****** Object:  StoredProcedure [dbo].[sp_LoadHocPhi]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LoadHocPhi]
@MASV char(12)
as
if exists(select MASV from SINHVIEN where MASV = @MASV)
BEGIN
select  NIENKHOA,HOCKY,HOCPHI,SOTIENDADONG
from  HOCPHI
where HOCPHI.MASV = @MASV
order by MASV
 END
GO
/****** Object:  StoredProcedure [dbo].[UpdateScoreByStudent]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateScoreByStudent] @maSV char(12), @maMH char(6), @lan smallint, @diem float
AS
INSERT INTO DIEM(MASV, MAMH, LAN, DIEM)
VALUES (@maSV, @maMH, @lan, @diem);
GO
/****** Object:  StoredProcedure [dbo].[Tim_Hoten]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Tim_Hoten] 
@MASV int
AS
select HO, TEN from SINHVIEN where MASV = @MASV
GO
/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP_GIAOVIEN]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_DANGNHAP_GIAOVIEN]
@LGNAME NVARCHAR (50)
AS
DECLARE @USERNAME NVARCHAR(50)
SELECT @USERNAME=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@LGNAME)
if @USERNAME in (SELECT MAGV FROM GIANGVIEN)
SELECT USERNAME = @USERNAME,
HOTEN = (SELECT HO + ' '+ TEN FROM GIANGVIEN  WHERE MAGV = @USERNAME ),

NAME FROM sys.sysusers WHERE UID = 
(SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID=
 (SELECT UID FROM sys.sysusers  WHERE NAME=@USERNAME))
GO
/****** Object:  StoredProcedure [dbo].[SP_DANGNHAP]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_DANGNHAP]
@LGNAME NVARCHAR (50)
AS
DECLARE @USERNAME NVARCHAR(50)
SELECT @USERNAME=NAME FROM sys.sysusers WHERE sid = SUSER_SID(@LGNAME)
if @USERNAME in (SELECT MASV FROM SINHVIEN)
SELECT USERNAME = @USERNAME,
HOTEN = (SELECT HO + ' '+ TEN FROM SINHVIEN  WHERE MASV = @USERNAME ),

NAME FROM sys.sysusers WHERE UID = 
(SELECT GROUPUID FROM SYS.SYSMEMBERS WHERE MEMBERUID=
 (SELECT UID FROM sys.sysusers  WHERE NAME=@USERNAME))
GO
/****** Object:  StoredProcedure [dbo].[sp_createsv]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--TAO SP THEM SINH VIEN
CREATE PROC [dbo].[sp_createsv](@MASV char(12)
,@HO nvarchar(40)
,@TEN nvarchar(10)
,@MALOP char(8)
,@PHAI bit
,@NGAYSINH datetime
,@NOISINH nvarchar(40)
,@DIACHI nvarchar(80)
,@GHICHU ntext
,@NGHIHOC bit)
AS
INSERT INTO SINHVIEN(MASV,HO,TEN,MALOP,PHAI,NGAYSINH,NOISINH,DIACHI,GHICHU,NGHIHOC)
VALUES(@MASV,@HO,@TEN,@MALOP,@PHAI,@NGAYSINH,@NOISINH,@DIACHI,@GHICHU,@NGHIHOC)
GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVienTheoLop_Delete]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVienTheoLop_Delete] 
@MASV NCHAR(8)
AS
	IF (EXISTS( SELECT 1 FROM dbo.SINHVIEN WHERE MASV = @MASV))
	BEGIN
		DELETE FROM dbo.SINHVIEN WHERE MASV = @MASV
		RETURN 1
	END
        ELSE IF (EXISTS( SELECT 1 FROM LINK2.QLDSV.dbo.SINHVIEN WHERE MASV = @MASV))
	BEGIN
		DELETE FROM LINK2.QLDSV.dbo.SINHVIEN WHERE MASV = @MASV
		RETURN 1
	END
	RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemtrasinhvien]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemtralop]    Script Date: 08/23/2020 12:36:30 ******/
CREATE PROC [dbo].[sp_kiemtrasinhvien]
  @MASV char(8)
AS
  BEGIN
IF EXISTS(SELECT MASV FROM DBO.SINHVIEN WHERE DBO.SINHVIEN.MASV = @MASV)
				BEGIN
					SELECT HO + TEN as HoTen,MALOP FROM DBO.SINHVIEN WHERE DBO.SINHVIEN.MASV = @MASV
				END
			ELSE IF EXISTS(SELECT MASV FROM LINK2.QLDSV.DBO.SINHVIEN AS P WHERE P.MASV = @MASV)
				BEGIN
					SELECT HO + TEN as HoTen,MALOP FROM  LINK2.QLDSV.DBO.SINHVIEN AS P WHERE P.MASV = @MASV
				END
			ELSE
				RETURN -1
				END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachSinhVienTheoLop_Update]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_DanhSachSinhVienTheoLop_Update]
 (@MASV NCHAR(8),
@HO	NVARCHAR(40),
@TEN NVARCHAR(10),
@PHAI BIT,
@NGAYSINH DATETIME,
@NOISINH NVARCHAR(40),
@DIACHI NVARCHAR(80),
@NGHIHOC BIT
)
AS
	IF (EXISTS(SELECT 1 FROM dbo.SINHVIEN WHERE MASV = @MASV))
	BEGIN
		UPDATE dbo.SINHVIEN
		Set	HO = @HO,
			TEN = @TEN,
			PHAI = @PHAI,
			NGAYSINH  = @NGAYSINH,
			NOISINH = @NOISINH,
			DIACHI = @DIACHI,
			NGHIHOC = @NGHIHOC
		WHERE MASV = @MASV
	END
	ELSE IF (EXISTS(SELECT 1 FROM LINK2.QLDSV.dbo.SINHVIEN WHERE MASV = @MASV))
	BEGIN
		UPDATE LINK2.QLDSV.dbo.SINHVIEN
		Set	HO = @HO,
			TEN = @TEN,
			PHAI = @PHAI,
			NGAYSINH  = @NGAYSINH,
			NOISINH = @NOISINH,
			DIACHI = @DIACHI,
			NGHIHOC = @NGHIHOC
		WHERE MASV = @MASV
	END
GO
/****** Object:  StoredProcedure [dbo].[Xoa_Login]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[Xoa_Login]
  @LGNAME VARCHAR(50),
  @USRNAME VARCHAR(50)
  
AS
EXEC SP_DROPUSER @USRNAME
  EXEC SP_DROPLOGIN @LGNAME
GO
/****** Object:  StoredProcedure [dbo].[SP_TAOLOGIN]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[SP_TAOLOGIN]
  @LGNAME VARCHAR(50),
  @PASS VARCHAR(50),
  @USERNAME VARCHAR(50),
  @ROLE VARCHAR(50)
AS
  DECLARE @RET INT
  EXEC @RET= SP_ADDLOGIN @LGNAME, @PASS,'QLDSV'
  IF (@RET =1)  -- LOGIN NAME BI TRUNG
     RETURN 1
 
  EXEC @RET= SP_GRANTDBACCESS @LGNAME, @USERNAME
  IF (@RET =1)  -- USER  NAME BI TRUNG
  BEGIN
       EXEC SP_DROPLOGIN @LGNAME
       RETURN 2
  END
  EXEC sp_addrolemember @ROLE, @USERNAME
      EXEC sp_addsrvrolemember @LGNAME, 'SecurityAdmin'
RETURN 0  -- THANH CONG
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaLop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XoaLop] @MALOP NVARCHAR(255)
AS
	IF (EXISTS(SELECT 1 FROM dbo.LOP WHERE MALOP = @MALOP))
		DELETE FROM dbo.LOP WHERE MALOP = @MALOP
	ELSE IF (EXISTS(SELECT 1 FROM LINK2.QLDSV.dbo.LOP WHERE MALOP = @MALOP))
		DELETE FROM LINK2.QLDSV.dbo.LOP WHERE MALOP = @MALOP
GO
/****** Object:  StoredProcedure [dbo].[sp_SinhVienTheoLop_Insert]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_SinhVienTheoLop_Insert]
 (@MASV NCHAR(12),
@HO	NVARCHAR(40),
@TEN NVARCHAR(10),
@MALOP NVARCHAR(8),
@PHAI BIT,
@NGAYSINH DATETIME,
@NOISINH NVARCHAR(40),
@DIACHI NVARCHAR(80),
@NGHIHOC BIT
)
AS
	IF (EXISTS(SELECT 1 FROM dbo.LOP WHERE MALOP = @MALOP))
	BEGIN
		INSERT INTO dbo.SINHVIEN 
				( MASV ,
				  HO ,
				  TEN ,
				  MALOP,
				  PHAI ,
				  NGAYSINH ,
				  NOISINH ,
				  DIACHI ,
				  NGHIHOC
				)
		VALUES  ( @MASV , -- MASV - nchar(8)
				  @HO , -- HO - nvarchar(40)
				  @TEN , -- TEN - nvarchar(10)
				  @MALOP,  -- MALOP - nchar(8)
				  @PHAI , -- PHAI - bit
				  @NGAYSINH , -- NGAYSINH - datetime
				  @NOISINH , -- NOISINH - nvarchar(40)
				  @DIACHI , -- DIACHI - nvarchar(80)
				  @NGHIHOC -- NGHIHOC - bit
				)
	END
	ELSE IF (EXISTS(SELECT 1 FROM LINK2.QLDSV.dbo.LOP WHERE MALOP = @MALOP))
	BEGIN
		INSERT INTO LINK2.QLDSV.dbo.SINHVIEN 
					( MASV ,
					  HO ,
					  TEN ,
					  MALOP,
					  PHAI ,
					  NGAYSINH ,
					  NOISINH ,
					  DIACHI ,
					  NGHIHOC
					)
			VALUES  ( @MASV , -- MASV - nchar(8)
					  @HO , -- HO - nvarchar(40)
					  @TEN , -- TEN - nvarchar(10)
					  @MALOP,  -- MALOP - nchar(8)
					  @PHAI , -- PHAI - bit
					  @NGAYSINH , -- NGAYSINH - datetime
					  @NOISINH , -- NOISINH - nvarchar(40)
					  @DIACHI , -- DIACHI - nvarchar(80)
					  @NGHIHOC -- NGHIHOC - bit
					)
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDsLopTheoKhoa]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayDsLopTheoKhoa]
 @MaKhoa CHAR(4)
AS
	IF (EXISTS(SELECT 1 FROM dbo.LOP WHERE MAKH = @MaKhoa))
	BEGIN
		 SELECT dbo.LOP.MALOP, dbo.LOP.TENLOP FROM dbo.LOP WHERE MAKH = @MaKhoa
	END
	ELSE IF (EXISTS(SELECT 1 FROM LINK2.QLDSV.dbo.LOP WHERE MAKH = @MaKhoa))
	BEGIN
		 SELECT MALOP, TENLOP FROM LINK2.QLDSV.dbo.LOP WHERE MAKH = @MaKhoa		
	END
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraTenLop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_KiemTraTenLop]
 @TENLOP NVARCHAR(200)
AS
	 if exists(select TENLOP from LOP where TENLOP = @TENLOP)
	 BEGIN	
		 SELECT TENLOP FROM dbo.LOP WHERE TENLOP = @TENLOP
                 RETURN 0
	 END
                 
	 ELSE if exists(select TENLOP from LINK2.QLDSV.dbo.LOP where TENLOP = @TENLOP)
	 BEGIN
	 	SELECT TENLOP FROM LINK2.QLDSV.dbo.LOP WHERE TENLOP = @TENLOP
	        RETURN 0
         END
		RETURN 1
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemtralop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROC [dbo].[sp_kiemtralop]
  @MALOP char(8)
AS
  BEGIN
IF EXISTS(SELECT MALOP FROM DBO.LOP WHERE DBO.LOP.MALOP = @MALOP)
				BEGIN
					SELECT MALOP FROM DBO.LOP WHERE DBO.LOP.MALOP = @MALOP
				END
			ELSE IF EXISTS(SELECT MALOP FROM LINK2.QLDSV.DBO.LOP AS P WHERE P.MALOP = @MALOP)
				BEGIN
					SELECT MALOP FROM  LINK2.QLDSV.DBO.LOP AS P WHERE P.MALOP = @MALOP
				END
			ELSE
				RETURN -1
				END
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertLop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--TAO SP THEM LOP
CREATE PROCEDURE [dbo].[sp_InsertLop]
@maLop CHAR(8),
@tenLop NVARCHAR(200),
@maKH NVARCHAR(4)

AS
	DECLARE @t INT
	EXEC @t = sp_KiemTraTenLop @TENLOP = @tenLop  -- nvarchar(40)
	
	if (exists(select MALOP from LOP where MALOP =@MALOP)
		OR @t = 0)
		 RETURN 1
	else if (exists(select MALOP from LINK2.QLDSV.dbo.LOP where MALOP =@maLop)
				OR @t = 0)
		 RETURN 1
	ELSE IF exists(select MAKH from dbo.KHOA where MAKH = @maKH)
	BEGIN
		INSERT INTO dbo.LOP
		        ( MALOP, TENLOP, MAKH)
		VALUES  ( @maLop, -- MALOP - nchar(8)
		          @tenLop, -- TENLOP - nvarchar(40)
		          @maKH -- MAKH - nchar(8)
		          )
		
		SELECT MALOP, TENLOP, MAKH FROM dbo.LOP WHERE MALOP = @maLop
	
	END	
	ELSE
	BEGIN
		INSERT INTO LINK2.QLDSV.dbo.LOP
		        ( MALOP, TENLOP, MAKH)
		VALUES  ( @maLop, -- MALOP - nchar(8)
		          @tenLop, -- TENLOP - nvarchar(40)
		          @maKH -- MAKH - nchar(8)
		          )

		SELECT MALOP, TENLOP, MAKH FROM LINK2.QLDSV.dbo.LOP WHERE MALOP = @maLop
		
	END
	RETURN 0
GO
/****** Object:  StoredProcedure [dbo].[sp_InDsSinhVienTheoLop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InDsSinhVienTheoLop]
 @MaLop CHAR(8)
as 
	IF (EXISTS(SELECT 1 FROM dbo.LOP WHERE MALOP = @MaLop))
		SELECT MASV, HO + '' + TEN as HOTEN  FROM dbo.SINHVIEN WHERE MALOP = @MaLop
    ELSE IF (EXISTS(SELECT 1 FROM LINK2.QLDSV.dbo.LOP WHERE MALOP = @MaLop))
		SELECT MASV, HO + '' + TEN as HOTEN FROM LINK2.QLDSV.dbo.SINHVIEN WHERE MALOP = @MaLop
GO
/****** Object:  StoredProcedure [dbo].[sp_InDanhSachSinhVien]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_InDanhSachSinhVien]
@MALOP NVARCHAR(8)
AS
Begin
	if (exists(select 1 from LOP where MALOP = @MALOP))
		select HO + TEN as HOTEN, PHAI, NGAYSINH, NOISINH, DIACHI from SINHVIEN where MALOP = @MALOP  Order By HO, TEN asc
	else if (exists(select 1 from LINK2.QLDSV.dbo.LOP where MALOP = @MALOP))
		select HO + TEN as HOTEN, PHAI, NGAYSINH, NOISINH, DIACHI from LINK2.QLDSV.dbo.SINHVIEN where MALOP = @MALOP  Order By HO, TEN asc

End
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertAndUpdateDiem]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertAndUpdateDiem]
@table_temp dbo.DIEM_UPDATE READONLY,
@maKhoa NCHAR(8)
AS
	
	DECLARE @MyTableVar table(  
		MASV CHAR(12) NOT NULL,  
		MAMH CHAR(6) NOT NULL,  
		LAN SMALLINT NOT NULL,  
		DIEM FLOAT);  
	
	INSERT INTO @MyTableVar
	        ( MASV, MAMH, LAN, DIEM )
	SELECT MASV, MAMH, LAN, DIEM FROM @table_temp 
	UNION
	SELECT MASV, MAMH, LAN, DIEM from dbo.DIEM	 
		WHERE ( rtrim(MASV) + RTRIM(MAMH) + ' ' + LAN) NOT IN 
		(SELECT (rtrim(MASV) + RTRIM(MAMH) + ' ' + LAN) FROM @table_temp)
	
	DELETE FROM dbo.DIEM
	INSERT INTO dbo.DIEM
	        ( MASV, MAMH, LAN, DIEM )
	SELECT MASV, MAMH, LAN, DIEM FROM  @MyTableVar

	SELECT * FROM dbo.DIEM
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDsSinhVienTheoLop]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_LayDsSinhVienTheoLop]
 @MaLop CHAR(8),
 @MaMH CHAR(6)
AS
	IF (EXISTS(SELECT 1 FROM dbo.SINHVIEN 
			   JOIN  dbo.DIEM ON dbo.SINHVIEN.MASV = dbo.DIEM.MASV))
		SELECT dbo.SINHVIEN.MASV,HO + ' ' + TEN AS 'HoTen' FROM dbo.SINHVIEN 
				JOIN DIEM ON dbo.SINHVIEN.MASV = DIEM.MASV
				 WHERE MALOP = @MaLop AND MAMH = @MaMH
     ELSE IF (EXISTS(SELECT COUNT(*) FROM LINK2.QLDSV.dbo.SINHVIEN AS SV
			   JOIN  LINK2.QLDSV.dbo.DIEM AS DIEM ON SV.MASV  = DIEM.MASV))
		SELECT SV.MASV,HO + ' ' + TEN AS 'HoTen' FROM LINK2.QLDSV.dbo.SINHVIEN AS SV
				JOIN LINK2.QLDSV.dbo.DIEM AS DIEM ON SV.MASV = DIEM.MASV
				 WHERE MALOP = @MaLop AND MAMH = @MaMH
GO
/****** Object:  StoredProcedure [dbo].[sp_LayDiemSinhVien]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[sp_LayDiemSinhVien]
@maLop NVARCHAR(255),
@maMH NCHAR(8),
@lan SMALLINT
AS
	if exists(select MALOP from LOP where MALOP =@maLop)
		SELECT a.MASV AS MASV, a.HOTEN AS HOTEN, b.Diem
		FROM (SELECT MASV, (HO + ' ' + TEN) AS HOTEN FROM dbo.SINHVIEN WHERE MALOP = @maLop) a LEFT OUTER JOIN
			 (SELECT DIEM AS Diem, MASV FROM dbo.DIEM WHERE LAN = @lan AND MAMH = @maMH) b
			ON a.MASV = b.MASV 
	else if exists(select MALOP from LINK2.QLDSV.dbo.LOP where MALOP =@maLop)
		SELECT a.MASV AS MASV, a.HOTEN AS HOTEN, b.Diem
		FROM (SELECT MASV, (HO + ' ' + TEN) AS HOTEN FROM LINK2.QLDSV.dbo.SINHVIEN WHERE MALOP = @maLop) a 
		LEFT OUTER JOIN (SELECT DIEM AS Diem, MASV from LINK2.QLDSV.dbo.DIEM WHERE LAN = @lan AND MAMH = @maMH) b
			ON a.MASV = b.MASV
GO
/****** Object:  StoredProcedure [dbo].[sp_InPhieuDiemCaNhan]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InPhieuDiemCaNhan]
@MASV char(12)
as
if exists(select MASV from DIEM where MASV = @MASV)
BEGIN
select TENMH, maxDIEM 
from (select MAMH, MAX(DIEM) as maxDIEM from DIEM GROUP BY MAMH) as x, MONHOC
where  x.MAMH = MONHOC.MAMH 
order by TENMH
END
else if exists(select MASV from LINK2.QLDSV.dbo.DIEM where MASV = @MASV)
BEGIN
select TENMH, maxDIEM 
from (select MAMH, MAX(DIEM) as maxDIEM from LINK2.QLDSV.dbo.DIEM group by MAMH) as x, LINK2.QLDSV.dbo.MONHOC 
where    x.MAMH = MONHOC.MAMH 
order by TENMH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_timmonhoc]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/****** Object:  StoredProcedure [dbo].[sp_kiemtralop]    Script Date: 08/23/2020 12:36:30 ******/
create PROC [dbo].[sp_timmonhoc]
  @MAMH char(8)
AS
  BEGIN
IF EXISTS(SELECT MAMH FROM DBO.MONHOC WHERE DBO.MONHOC.MAMH = @MAMH)
				BEGIN
					SELECT MAMH FROM DBO.MONHOC WHERE DBO.MONHOC.MAMH = @MAMH
				END
			ELSE IF EXISTS(SELECT MAMH FROM LINK2.QLDSV.DBO.MONHOC AS P WHERE P.MAMH = @MAMH)
				BEGIN
					SELECT MAMH FROM  LINK2.QLDSV.DBO.MONHOC AS P WHERE P.MAMH = @MAMH
				END
			ELSE
				RETURN -1
				END
GO
/****** Object:  StoredProcedure [dbo].[sp_XoaMonHoc]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_XoaMonHoc] @MAMH NVARCHAR(10)
AS
	IF (EXISTS(SELECT 1 FROM dbo.MONHOC WHERE MAMH = @MAMH))
		DELETE FROM dbo.MONHOC WHERE MAMH = @MAMH
GO
/****** Object:  StoredProcedure [dbo].[sp_InsertMonHoc]    Script Date: 08/30/2020 22:55:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InsertMonHoc]
@MAMH NVARCHAR(10),
@TENMH NVARCHAR(50)

AS
	 if exists(select MAMH from MONHOC where MAMH =@MAMH)
		 RETURN 0
	else
		INSERT INTO dbo.MONHOC
		        ( MAMH, TENMH)
		VALUES  (@MAMH, @TENMH)
	
	RETURN 1
GO
