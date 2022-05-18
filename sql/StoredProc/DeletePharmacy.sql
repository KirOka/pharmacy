USE [pharmacy]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[DeletePharmacy]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	Delete from b from Batchs b inner join Warehouses w on w.Id=b.WarehouseId where w.PharmacyId=@id
	Delete from Warehouses where PharmacyId=@id
    Delete from Pharmacies where Id=@id
END
GO


