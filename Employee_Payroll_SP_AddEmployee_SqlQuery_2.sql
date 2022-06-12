--creating stored procedure to add Employee records in DB
create procedure [dbo].[SpAdd_Employee_Record]
@EmpName varchar(20),
@EmpSalary money,
@JoiningDate date
as

insert into employee_payroll values (@EmpName, @EmpSalary, @JoiningDate)

go


select * from employee_payroll