CREATE TABLE [dbo].[RecordTags]
(
	[Id]		INT NOT NULL  IDENTITY(1,1),
	[TagId]		INT NOT NULL,
	[RecordId]	INT NOT NULL

	CONSTRAINT [PK_RecordTag] PRIMARY KEY CLUSTERED ([Id] ASC), 
    CONSTRAINT [FK_RecordTags_ToRecord] FOREIGN KEY ([RecordId]) REFERENCES [Record]([Id]),
	CONSTRAINT [FK_RecordTags_ToTag] FOREIGN KEY ([TagId]) REFERENCES [Tag]([Id])
)
GO CREATE INDEX [IX_RecordTags_RecordId] ON [dbo].[RecordTags] ([RecordId])
GO CREATE INDEX [IX_RecordTags_TagId] ON [dbo].[RecordTags] ([TagId])
