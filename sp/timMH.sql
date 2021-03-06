USE [QLDSV]
GO
/****** Object:  StoredProcedure [dbo].[sp_timmonhoc]    Script Date: 08/28/2020 23:29:48 ******/
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
