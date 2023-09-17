CREATE DATABASE CourseCatalog_DB;

USE CourseCatalog_DB;

CREATE TABLE Professors (
    ProfessorId INT IDENTITY(1,1) PRIMARY KEY,
    ProfessorName NVARCHAR(255) NOT NULL,
    ProfessorEmail NVARCHAR(255)
);

INSERT INTO Professors (ProfessorName, ProfessorEmail)
VALUES
    ('González Bautista', 'bgcarpani@gmail.com'),
    ('David Lancellotti', 'dlanc@gmail.com'),
    ('Lionel Messi', NULL);

CREATE TABLE Rooms (
    RoomId INT IDENTITY(1,1) PRIMARY KEY,
    RoomNumber NVARCHAR(50) NOT NULL
);

INSERT INTO Rooms (RoomNumber)
VALUES
    ('Room 1'),
    ('Room 2'),
	('Room 3');


CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(255) NOT NULL,
    ProfessorId INT,
    RoomId INT,
    Monday BIT,
    Tuesday BIT,
    Wednesday BIT,
    Thursday BIT,
    Friday BIT,
    Saturday BIT,
    Sunday BIT,
    FOREIGN KEY (ProfessorId) REFERENCES Professors(ProfessorId),
    FOREIGN KEY (RoomId) REFERENCES Rooms(RoomId)
);


INSERT INTO Courses (CourseName, ProfessorId, RoomId, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday)
VALUES
    ('Course 1', 1, 1, 1, 0, 1, 0, 1, 0, 0),
    ('Course 2', 2, 2, 0, 1, 0, 1, 0, 0, 0),
    ('Course 3', 3, NULL, 0, 0, 1, 1, 0, 0, 0);