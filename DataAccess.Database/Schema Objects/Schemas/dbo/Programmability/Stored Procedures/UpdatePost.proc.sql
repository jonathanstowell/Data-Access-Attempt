-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePost]
	-- Add the parameters for the stored procedure here
	@PostID INT,
	@CreatorID INT,
	@Content NVARCHAR(255),
	@CreatedDateTime DATETIME
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Posts SET CreatorID = @CreatorID, Content = @Content, CreatedDateTime = @CreatedDateTime WHERE PostID = @PostID
END
