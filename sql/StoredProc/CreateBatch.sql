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
CREATE OR ALTER PROCEDURE [dbo].[CreateBatch]
	-- Add the parameters for the stored procedure here
	@GoodId int,
	@WarehouseId int,
	@qty decimal(18,2)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into Batchs([GoodId],[WarehouseId],Quantity) values(@GoodId,@WarehouseId,@qty)
END


