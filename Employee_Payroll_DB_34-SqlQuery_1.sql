create database Employee_Payroll_DB_Day_34
use Employee_Payroll_DB_Day_34

create Table employee_payroll
(
  ID  int NOT NULL Primary key Identity,
  EmployeeName varchar(25) Not Null,
  EmpSalary money,
  JoiningDate date
)
