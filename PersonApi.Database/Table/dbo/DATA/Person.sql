CREATE TABLE [dbo].[Person]
(
	[PersonKey] INT NOT NULL PRIMARY KEY Identity, 
    [LastName] NVARCHAR(MAX) NULL, 
    [FirstName] NVARCHAR(MAX) NULL
)
