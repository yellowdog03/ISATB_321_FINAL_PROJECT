




DROP TABLE IF EXISTS Meetings
GO

DROP TABLE IF EXISTS Availability
GO

DROP TABLE IF EXISTS Students
GO

DROP TABLE IF EXISTS Times
GO

DROP TABLE IF EXISTS Locations
GO

DROP TABLE IF EXISTS Advisors
GO


-- Advisors
CREATE TABLE Advisors (
    AdvisorID INT IDENTITY(1,1) PRIMARY KEY,
    AdvisorFName VARCHAR(25),
    AdvisorLName VARCHAR(40),
    AdvisorEmail VARCHAR(50)
)
GO


-- Students
CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    StudentFName VARCHAR(25),
    StudentLName VARCHAR(50),
    AdvisorID INT,
    Year INT,

    FOREIGN KEY (AdvisorID) REFERENCES Advisors(AdvisorID)
)
GO


-- Locations
CREATE TABLE Locations (
    LocationID INT IDENTITY(1,1) PRIMARY KEY,
    Description VARCHAR(40)
)
GO


-- Times
CREATE TABLE Times (
    TimeID INT IDENTITY(1,1) PRIMARY KEY,
    StartTime TIME,
    EndTime TIME
)
GO


-- Availability
CREATE TABLE Availability (
    AvailabilityID INT IDENTITY(1,1) PRIMARY KEY,
    AdvisorID INT,
    [Date] DATE,
    --StartTimeID INT,
    --EndTimeID INT,
    TimeID INT,
    LocationID INT,
    IsTaken BIT,
    --IsOnline BIT

    FOREIGN KEY (AdvisorID) REFERENCES Advisors(AdvisorID),
    --FOREIGN KEY (StartTimeID) REFERENCES Times(TimeID),
   -- FOREIGN KEY (EndTimeID) REFERENCES Times(TimeID),
    FOREIGN KEY (TimeID) REFERENCES Times(TimeID),
    FOREIGN KEY (LocationID) REFERENCES Locations(LocationID)
)
GO


-- Meetings
CREATE TABLE Meetings (
    MeetingID INT IDENTITY(1,1) PRIMARY KEY,
    StudentID INT,
    AvailabilityID INT,

    FOREIGN KEY (StudentID) REFERENCES Students(StudentID),
    FOREIGN KEY (AvailabilityID) REFERENCES Availability(AvailabilityID)
)
GO
