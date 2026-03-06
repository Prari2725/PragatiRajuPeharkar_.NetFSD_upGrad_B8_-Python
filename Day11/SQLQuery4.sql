use sql;
-- Bank Account System--Problem Statement:--Create a table BankAccounts with constraints:--AccountNumber as Primary Key.--Balance must always be ≥ 0.--AccountType must allow only 'Savings' or 'Current'.--CreatedDate should have default current date.--AadharNumber must be unique.--5️⃣ Course Enrollment System--Problem Statement:--Create table Enrollments with:--Composite Primary Key using StudentID and CourseID.--EnrollDate default to current date.--Grade must be between 0 and 100.--StudentID must reference Students.--CourseID must reference Courses.--6️⃣ Insurance Claim System (Advanced Scenario)--Since you're working on an insu-- BANK ACCOUNTS
CREATE TABLE accounts
(
    AccountNumber  BIGINT  NOT NULL,
    Balance        DECIMAL  NOT NULL
        CONSTRAINT CK_BankAccounts_Balance_NonNegative CHECK (Balance >= 0),
    AccountType    VARCHAR(10)   NOT NULL
        CONSTRAINT CK_BankAccounts_AccountType CHECK (AccountType IN ('Savings','Current')),
    CreatedDate    DATETIME     NOT NULL
        CONSTRAINT DF_BankAccounts_CreatedDate DEFAULT (SYSDATETIME()),
    AadharNumber   VARCHAR(12)      NOT NULL
        CONSTRAINT UQ_BankAccounts_Aadhar UNIQUE,

    CONSTRAINT PK_Accounts PRIMARY KEY (AccountNumber)
);

INSERT INTO accounts (AccountNumber, Balance, AccountType, AadharNumber)
VALUES 
    (200101, -5000.00, 'Savings', '211122223333');


INSERT INTO accounts (AccountNumber, Balance, AccountType, AadharNumber)
VALUES 
    (100101, 5000.00, 'Savings', '111122223333'),
    (100102, 12500.50, 'Current', '222233334444'),
    (100103, 0.00, 'Savings', '333344445555'),
    (100104, 75000.00, 'Current', '444455556666'),
    (100105, 1200.00, 'Savings', '555566667777'),
    (100106, 2540.75, 'Current', '666677778888'),
    (100107, 9800.00, 'Savings', '777788889999'),
    (100108, 150.25, 'Current', '888899990000');


select * from accounts;



CREATE TABLE Students(StudentID INT NOT NULL CONSTRAINT PK_Students PRIMARY KEY)


INSERT INTO Students (StudentID) 
VALUES (1), (2), (3), (4), (5);


CREATE TABLE Courses(CourseID INT NOT NULL CONSTRAINT PK_Courses PRIMARY KEY);



ALTER TABLE Courses
DROP COLUMN CourseName;



CREATE TABLE Enrollments
(
    StudentID  INT        NOT NULL,
    CourseID   INT        NOT NULL,
    EnrollDate DATE       NOT NULL
	CONSTRAINT DF_Enrollments_EnrollDate DEFAULT GETDATE() ,
    Grade INT NULL
    CONSTRAINT CK_Enrollments_Grade CHECK (Grade BETWEEN 0 AND 100),
    CONSTRAINT PK_Enrollments PRIMARY KEY (StudentID, CourseID),
    CONSTRAINT FK_Enrollments_Students FOREIGN KEY (StudentID)
    REFERENCES Students(StudentID),
	CONSTRAINT FK_Enrollments_Courses FOREIGN KEY (CourseID)
	REFERENCES Courses(CourseID)
);


---

INSERT INTO Enrollments (StudentID, CourseID, EnrollDate, Grade)
VALUES 
    (1, 101, '2024-01-10', 85),
    (1, 102, '2024-01-12', 92),
    (2, 101, '2024-01-10', 78),
    (2, 103, '2024-01-15', 88),
    (3, 102, '2024-01-12', 95),
    (3, 104, '2024-01-20', 60),
    (4, 101, '2024-01-10', NULL), 
    (4, 105, '2024-01-25', 100),
    (5, 103, '2024-01-15', 45),
    (5, 104, '2024-01-20', 72);

	select * from Enrollments;
