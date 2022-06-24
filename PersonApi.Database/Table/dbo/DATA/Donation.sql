CREATE TABLE [dbo].[Donation]
(
	[DonationKey] INT NOT NULL PRIMARY KEY Identity, 
    [DonationDate] DATETIME NULL, 
    [DonationAmount] INT NULL, 
    [PersonKey] INT NULL, 
    [EmployeeKey] NVARCHAR(MAX) NULL, 
    CONSTRAINT [FK_Donation_PersonKey] FOREIGN KEY ([PersonKey]) REFERENCES [Person]([PersonKey])
)
