CREATE TABLE [dbo].[Posts] (
    [PostID]  INT           IDENTITY (1, 1) NOT NULL,
    [CreatorID] INT NOT NULL,
    [Content]  NVARCHAR (255) NULL,
    [CreatedDateTime]     DATETIME NOT NULL
);

