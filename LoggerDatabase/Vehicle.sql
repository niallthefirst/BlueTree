CREATE TABLE [dbo].[Vehicle]
(
	[RegistrationNumber] INT NOT NULL PRIMARY KEY, 
    [LoggerSerialNumber] INT NOT NULL, 
    CONSTRAINT [Logger.SerialNumber] FOREIGN KEY ([LoggerSerialNumber]) REFERENCES [Logger]([SerialNumber])
)
