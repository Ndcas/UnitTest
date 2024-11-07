CREATE DATABASE staffs;

use staffs;

CREATE TABLE Department
(
	DepartmentID int AUTO_INCREMENT,
    PRIMARY KEY (DepartmentID),
    DepartmentName char(20) NOT null
);

CREATE TABLE Gender
(
	GenderID int AUTO_INCREMENT,
    PRIMARY KEY (GenderID),
    GenderName char(20) NOT null
);

CREATE TABLE Employee
(
	EmployeeID int AUTO_INCREMENT,
    PRIMARY KEY (EmployeeID),
    GenderID int NOT null,
    FOREIGN KEY (GenderID) REFERENCES Gender(GenderID),
    DepartmentID int NOT null,
    FOREIGN KEY (DepartmentID) REFERENCES Department(DepartmentID),
    FirstName char(50) NOT null,
    LastName char(50) NOT null,
    Email char(200),
    StartingDate date NOT null DEFAULT (CURRENT_DATE)
);

INSERT INTO Department(DepartmentName)
VALUES
	('IT'),
    ('HR'),
    ('SE');
    
INSERT INTO Gender(GenderName)
VALUES
	('Male'),
    ('Female');

INSERT INTO Employee(GenderID, DepartmentID, FirstName, LastName, Email, StartingDate)
VALUES
	(1, 1, 'Hung', 'Nguyen', null, '2024-07-08'),
    (1, 2, 'Duy', 'Nguyen', 'nduy@gmail.com', '2024-01-01'),
    (2, 3, 'Chau', 'Nguyen', 'cnguyen@gmail.com', '2020-02-12'),
    (1, 2, 'Khoa', 'Vo', null, '2015-12-12');
    
SELECT *
FROM Department;

SELECT *
FROM Gender;

SELECT *
FROM Employee;