CREATE TABLE [dbo].[GPSLocation]
(
	[ID] INT NOT NULL PRIMARY KEY, 
    [TimeStamp] TIMESTAMP NOT NULL, 
    [Latitude] DECIMAL(9, 6) NOT NULL, 
    [Longditude] DECIMAL(9, 6) NOT NULL
)
