CREATE TABLE [dbo].[Logger]
(
	[SerialNumber] INT NOT NULL PRIMARY KEY, 
    [GPSLocationID] INT NOT NULL, 
    [History] TEXT NOT NULL, 
    CONSTRAINT [FK_Logger_GPSLocation] FOREIGN KEY ([GPSLocationID]) REFERENCES [GPSLocation]([ID])
    
)
