--creating stored procedure to add Employee records in DB
create procedure [dbo].[SpAdd_Employee_Record]
@EmployeeName varchar(20),
@JoiningDate date
as

insert into employee_payroll values (@EmployeeName,@JoiningDate)

go

create proc [dbo].[SpAdd_Employee_PersonalDetails_Record]
@ID int,
@EmpDepart varchar(30) ,
@EmpMobileNo bigint,
@EmpAddress varchar(70)
as

insert into employee_personaldetails values(@ID,@EmpDepart,@EmpMobileNo,@EmpAddress) 

go

create proc [dbo].[SpAdd_Employee_PayDetails_Record]
@ID int ,
@EmpDepart varchar(30),
@BasicPay money,
@TaxablePay money,
@tax money,
@NetPay money
as

insert into employee_paydetails values(@ID,@EmpDepart,@BasicPay,@TaxablePay,@tax,@NetPay) 

go


select * from employee_payroll