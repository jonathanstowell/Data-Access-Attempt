-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[AddPost]
	-- Add the parameters for the stored procedure here
	@CreatorID INT,
	@Content NVARCHAR(255),
	@CreatedDateTime DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO Posts (CreatorID, Content, CreatedDateTime) VALUES (@CreatorID, @Content, @CreatedDateTime)
END
