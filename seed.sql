-- 1. Seed the "Students" (Master) table
INSERT INTO Students (StudentNo, FullName, Department, YearLevel, CreatedAt)
VALUES ('23-0001', 'Jan Dela Cruz', 'CITE', '3rd Year', Now());

INSERT INTO Students (StudentNo, FullName, Department, YearLevel, CreatedAt)
VALUES ('23-0002', 'Maria Santos', 'COE', '2nd Year', Now());

INSERT INTO Students (StudentNo, FullName, Department, YearLevel, CreatedAt)
VALUES ('22-0003', 'John Doe', 'CITE', '4th Year', Now());

-- 2. Seed the "AdvisingSessions" (Transactional) table
-- We assume 'Jan Dela Cruz' has StudentID = 1
INSERT INTO AdvisingSessions (StudentID, Adviser, QueueNumber, Purpose, Status, CreatedAt)
VALUES (1, 'Mr. Reyes', 1, 'Enrollment Override', 'Waiting', Now());

-- We assume 'Maria Santos' has StudentID = 2
INSERT INTO AdvisingSessions (StudentID, Adviser, QueueNumber, Purpose, Status, CreatedAt)
VALUES (2, 'Ms. Gonzales', 2, 'Adding of Subject', 'Waiting', Now());

-- We assume 'John Doe' has StudentID = 3
INSERT INTO AdvisingSessions (StudentID, Adviser, QueueNumber, Purpose, Status, CreatedAt)
VALUES (3, 'Mr. Reyes', 3, 'Dropping', 'Serving', Now());