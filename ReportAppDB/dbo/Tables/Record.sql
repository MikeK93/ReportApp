CREATE TABLE [dbo].[Record] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Date]        DATE          NOT NULL,
    [Title]       VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (400) NOT NULL,
    [MoneySpent]  FLOAT (53)    NOT NULL,
	[DateCreated] DATETIME		NOT NULL, 

    CONSTRAINT [PK_Record] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO CREATE NONCLUSTERED INDEX [IX_Record_Date_Title_Description_MoneySpent]
    ON [dbo].[Record]([Date] ASC, [Title] ASC, [Description] ASC, [MoneySpent] ASC);
