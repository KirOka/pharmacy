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
CREATE OR ALTER PROCEDURE [dbo].[PharmacyContentList]
	-- Add the parameters for the stored procedure here
	@id int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	select max(g.Name), sum(b.Quantity)
	from Warehouses w
		inner join Batchs b on w.Id=b.WarehouseId
		inner join Goods g on b.GoodId=g.Id
	where w.Id=@id
	group by b.GoodId
END
GO


