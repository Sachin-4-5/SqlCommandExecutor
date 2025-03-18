-- *************************************************************************
-- Developer:  sachin kumar
-- Description: complete necessary script for SqlCommandExecutor application.
-- Testing: exec sp_GetEmployeeById 1
-- Note: It's recommended to execute script before running the application.
-- *************************************************************************



-- Table
CREATE TABLE Employees 
(
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Age INT NOT NULL,
    Department NVARCHAR(50) NOT NULL,
    JoinDate DATETIME DEFAULT GETDATE()
);

INSERT INTO Employees (Name, Age, Department) VALUES
('John Doe', 30, 'IT'),
('Jane Smith', 28, 'HR'),
('Alice Johnson', 35, 'Finance'),
('Bob Williams', 40, 'IT'),
('Charlie Brown', 25, 'Marketing');





-- Stored Procedure
CREATE PROCEDURE sp_GetEmployeeById @EmployeeId INT
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT EmployeeId, Name, Age, Department, JoinDate
    FROM TransactionDB..Employees
    WHERE EmployeeId = @EmployeeId;
END;











