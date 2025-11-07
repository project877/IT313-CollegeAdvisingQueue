-- 1. Create the Students table (basic structure)
CREATE TABLE Students (
   StudentID AUTOINCREMENT PRIMARY KEY,
   StudentNo VARCHAR(50),
   FullName VARCHAR(255),
   Department VARCHAR(100),
   YearLevel VARCHAR(20),
   CreatedAt DATETIME,
   UpdatedAt DATETIME
);

-- 2. Create the AdvisingSessions table (basic structure)
CREATE TABLE AdvisingSessions (
   SessionID AUTOINCREMENT PRIMARY KEY,
   StudentID LONG,
   Adviser VARCHAR(255),
   QueueNumber LONG,
   Purpose VARCHAR(255),
   Status VARCHAR(50),
   Remarks MEMO,
   CreatedAt DATETIME,
   UpdatedAt DATETIME
);