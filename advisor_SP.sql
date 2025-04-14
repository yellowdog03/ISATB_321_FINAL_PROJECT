--stored procedures




USE b320
GO


-------------------------------------------- Get (i.e., SELECT) SProc


DROP PROCEDURE IF EXISTS sp_GetPet;
GO

CREATE PROCEDURE sp_GetAdvisor
	@AdvisorID INT = NULL
AS
BEGIN
	IF (@AdvisorID IS NULL)
		SELECT AdvisorID, AdvisorFName, AdvisorLName, AdvisorEmail
		FROM Advisors;
	ELSE
		SELECT AdvisorID, AdvisorFName, AdvisorLName, AdvisorEmail
		FROM Advisors
		WHERE AdvisorID = @AdvisorID;
END
GO


EXEC sp_GetAdvisor;




-------------------------------------------- Insert SProc

DROP PROCEDURE IF EXISTS sp_InsertAdvisor;
GO

CREATE PROCEDURE sp_InsertAdvisor
	@AdvisorFName VARCHAR(25),
	@AdvisorLName VARCHAR(40) = NULL,
	@AdvisorEmail VARCHAR(50) = NULL
AS
BEGIN
	INSERT INTO [Advisors]
	([AdvisorFName], [AdvisorLName], [AdvisorEmail])
	VALUES
	(@AdvisorFName, @AdvisorLName, @AdvisorEmail)
END
GO


-- Test insert SProc

EXEC sp_InsertAdvisor @AdvisorFName='Archer', @AdvisorLName = 'Cat'

EXEC sp_GetAdvisor

EXEC sp_GetAdvisor @AdvisorID=@@IDENTITY

-------------------------------------------- Update SProc

DROP PROCEDURE IF EXISTS sp_UpdateAdvisor;
GO

CREATE PROCEDURE sp_UpdatePet
	@AdvisorID INT,
	@AdvisorFName VARCHAR(25),
	@AdvisorLName VARCHAR(40) = NULL,
	@AdvisorEmail VARCHAR(50) = NULL
AS
BEGIN
	UPDATE [Advisors]
	SET [AdvisorFName] =  @AdvisorFName, 
		[AdvisorLName] = @AdvisorLName, 
		[AdvisorEmail] = @AdvisorEmail 
	WHERE AdvisorID = @AdvisorID
END
GO

-- Test update SProc

--EXEC sp_UpdatePet @PetID = 1004, @PetName='Chewbacca (aka Chewy)', @Species = 'Cat', @BirthDate = '03-15-2023', @Weight = 8.4

EXEC sp_GetPet @AdvisorID = 1


-------------------------------------------- Delete SProc

DROP PROCEDURE IF EXISTS sp_DeleteAdvisor;
GO

CREATE PROCEDURE sp_DeletePet
	@AdvisorID INT
AS
BEGIN
	DELETE 
	FROM [Advisors]
	WHERE AdvisorID = @AdvisorID
END
GO

-- Test delete SProc
EXEC sp_DeleteAdvisor @AdvisorID = 1

--EXEC sp_GetPet @PetID = 1002

--EXEC sp_GetPet