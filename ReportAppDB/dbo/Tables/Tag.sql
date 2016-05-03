CREATE TABLE [dbo].[Tag] (
    [Id]			INT				IDENTITY (1, 1) NOT NULL,
    [Name]			VARCHAR (50)	NOT NULL,
    [DateCreated]	DATETIME		NOT NULL, 

    CONSTRAINT [PK_Tag] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO CREATE NONCLUSTERED INDEX [IX_Tag_Name]		ON [dbo].[Tag] ([Name])