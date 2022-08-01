CREATE TABLE [dbo].[DataClients] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [Name]      NVARCHAR (50) NOT NULL,
    [NumberTel] NCHAR (10)    NOT NULL,
    [Email]     NVARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_DataClients] PRIMARY KEY ([Id])
);

