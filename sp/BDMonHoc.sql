USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[sp_InBDMonHoc]    Script Date: 09/05/2020 02:18:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_InBDMonHoc]
@MALOP VARCHAR(8),
@MAMH NVARCHAR(6),
@LAN smallint
AS
BEGIN 
	SELECT  HO +' '+TEN as HOTEN, DIEM
 	FROM SINHVIEN, DIEM
 	where SINHVIEN.MALOP = @MALOP and diem.MAMH = @MAMH and DIEM.LAN = @LAN
END
GO
