CREATE DATABASE CourseCatalog_DB;

USE CourseCatalog_DB;

CREATE TABLE Courses (
    CourseId INT IDENTITY(1,1) PRIMARY KEY,
    CourseName NVARCHAR(50) NOT NULL,
    ProfessorName NVARCHAR(50),
    ProfessorEmail NVARCHAR(50),
    RoomNumber NVARCHAR(50),
    Monday BIT,
    Tuesday BIT,
    Wednesday BIT,
    Thursday BIT,
    Friday BIT,
    Saturday BIT,
    Sunday BIT
);

INSERT INTO Courses (CourseName, ProfessorName, ProfessorEmail, RoomNumber, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday)
VALUES
    ('Course 1', 'Professor 1', 'prof1@gmail.com', 'Room 1', 1, 0, 1, 0, 1, 0, 0),
    ('Course 2', 'Professor 2', prof2@gmail.com', 'Room 2', 0, 1, 0, 1, 0, 0, 0),
    ('Course 3', 'Professor 3', NULL, NULL, 0, 0, 1, 1, 0, 0, 0);