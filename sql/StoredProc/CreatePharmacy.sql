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
CREATE OR ALTER PROCEDURE [dbo].[CreatePharmacy]
	-- Add the parameters for the stored procedure here
	@name nvarchar(50),
	@address nvarchar(50),
	@phone nvarchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    insert into Pharmacies([Name],[Address],[Phone]) values(@name,@address,@phone)
END
GO


