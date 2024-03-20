
Select * from AspNetUsers;

Select * from AspNetRoles;

select * from FlightSchedules

select * from customerdetails

select * from SearchHistory;

SELECT * 
FROM sys.indexes 
WHERE object_id = OBJECT_ID('dbo.FlightSchedules')


SELECT FULLTEXTSERVICEPROPERTY ('IsFullTextInstalled') AS [FULLTEXTSERVICE]
go;

Update FlightSchedules set ArrivalTime = '2024-03-18 00:50:07.8500052' where id = 2;

Update FlightSchedules set AircraftType = 'Boeing'

delete from AspNetUsers where username='customer1@test.com';

select * from ApiLogs