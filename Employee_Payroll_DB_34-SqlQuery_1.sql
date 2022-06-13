create database Employee_Payroll_DB_Day_34
use Employee_Payroll_DB_Day_34

create Table employee_payroll
(
  ID  int NOT NULL Primary key Identity,
  EmployeeName varchar(25) Not Null,
  JoiningDate date
)

create Table employee_personaldetails
(
 ID int not null primary key Foreign key References employee_payroll(ID),
 EmpDepart varchar(30) not null,
 EmpMobileNo Bigint,
 EmpAddress varchar(70),
) 

create Table employee_paydetails
(
  ID int not null Foreign key References employee_payroll(ID),
  EmpDepart varchar(30) not null ,
  BasicPay money,
  TaxablePay money,
  tax money,
  NetPay money,
)

