CREATE TABLE [dbo].[Login] (
    [Id]       INT           NOT NULL,
    [First Name] VARCHAR (100) NOT NULL,
    [Last Name] VARCHAR (100) NOT NULL,
    [Username] VARCHAR(MAX) NOT NULL, 
    [Password] VARCHAR(200) NOT NULL, 
    [Email address] TEXT NOT NULL, 
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

