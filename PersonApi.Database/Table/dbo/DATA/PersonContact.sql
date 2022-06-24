CREATE TABLE [dbo].[PersonContact]
(
	[ContactKey] INT NOT NULL PRIMARY KEY Identity, 
    [ContactInfo] NVARCHAR(MAX) NULL, 
    [PersonKey] INT NULL, 
    [ContactTypeKey] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_PersonContact_PersonKey] FOREIGN KEY ([PersonKey]) REFERENCES [Person]([PersonKey])
)
