CREATE TABLE [dbo].[PersonAddress]
(
	[PersonAddressKey] INT NOT NULL PRIMARY KEY Identity, 
    [Street] NVARCHAR(MAX) NULL, 
    [Apartment] NVARCHAR(MAX) NULL, 
    [State] NVARCHAR(MAX) NULL, 
    [City] NVARCHAR(MAX) NULL, 
    [Zip] INT NULL, 
    [PersonKey] INT NULL, 
    CONSTRAINT [FK_PersonAddress_PersonKey] FOREIGN KEY ([PersonKey]) REFERENCES [Person]([PersonKey])
)
