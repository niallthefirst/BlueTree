CREATE PROCEDURE [dbo].[GetGPSHistory]
	@VehicleRegistration int = 0
	
AS
	SELECT History from Logger 
	JOIN Logger on Logger.SerialNumber = Vehicle.LoggerSerialNumber
	JOIN Vehicle on Vehicle.RegistrationNumber = @VehicleRegistration

RETURN 0
