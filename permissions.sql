/*
James Plant
B321
ICE_13_1
*/



/*
Create login in master

create and run user in b320
*/





USE MASTER
GO

CREATE LOGIN B321_S25_APP 
WITH PASSWORD = 'Password!'

USE b320
GO

CREATE USER B321_S25_APP 
FOR LOGIN B321_S25_APP
GO


DROP Procedure IF EXISTS sp_GetVendors
GO


CREATE PROCEDURE sp_GetVendors
as
SELECT *
FROM Vendors
GO

GRANT EXECUTE ON sp_GetVendors to B321_S25_APP
GO

GRANT EXECUTE ON sp_GetAdvisor to B321_S25_APP
GO

GRANT EXECUTE ON sp_InsertAdvisor to B321_S25_APP
GO

GRANT EXECUTE ON sp_UpdateAdvisor to B321_S25_APP
GO

GRANT EXECUTE ON sp_DeleteAdvisor to B321_S25_APP
GO

GRANT EXECUTE ON sp_GetStudent to B321_S25_APP
Go

GRANT EXECUTE ON sp_InsertStudent to B321_S25_APP
Go

GRANT EXECUTE ON sp_UpdateStudent to B321_S25_APP
Go

GRANT EXECUTE ON sp_DeleteStudent to B321_S25_APP
Go