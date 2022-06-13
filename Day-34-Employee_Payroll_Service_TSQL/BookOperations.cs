using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_34_Employee_Payroll_Service_TSQL.Models;

/// >>> Implemented using Normalixation technique OF ER Diagram

namespace Day_34_Employee_Payroll_Service_TSQL
{
    public class BookOperations
    {
        //path for Database Connection
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_DB_Day_34;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Represents a connection to MS Sql Server Database
        SqlConnection connection = new SqlConnection(connectionString);

        // MEthod to get EmployeeRecord
        public EmployeeModel getEmpRecord()
        {
            EmployeeModel EmployeeRecord = new EmployeeModel();
            Console.Write("\nEnter Employee ID :- ");
            EmployeeRecord.EmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Employee Name :- ");
            EmployeeRecord.EmployeeName = Console.ReadLine();
            Console.Write("Enter Employee Joining Date :- ");
            EmployeeRecord.JoiningDate = Convert.ToDateTime(Console.ReadLine());
            return EmployeeRecord;
        }

        // Method to get Employee Personal Details Record
        public EmpPersonalDetailsModel getEmpPersonalRecords()
        {
            EmpPersonalDetailsModel EmpPersonalDetails = new EmpPersonalDetailsModel();
            Console.Write("Enter Department :- ");
            EmpPersonalDetails.EmpDepart = Console.ReadLine();
            Console.Write("Enter Mobile number :- ");
            EmpPersonalDetails.EmpMobileNo = Convert.ToInt64(Console.ReadLine());
            Console.Write("Enter Employee Full Address :- ");
            EmpPersonalDetails.EmpAddress = Console.ReadLine();
            return EmpPersonalDetails;
        }

        // Method to get Employee Personal Details Record
        public EmpPayDetailsModel getEmpPayRecords()
        {
            EmpPayDetailsModel EmpPayDetails = new EmpPayDetailsModel();
            Console.Write("Enter Basic Pay :- ");
            EmpPayDetails.BasicPay = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Taxable Pay :- ");
            EmpPayDetails.TaxablePay = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Income Tax Rate :- ");
            EmpPayDetails.tax = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Net Pay :- ");
            EmpPayDetails.NetPay = Convert.ToDouble(Console.ReadLine());
            return EmpPayDetails;
        }

        ////Method to ADD New Employee Record in Employee_Payroll_DB
        public void AddNewEmployeeRecord(EmployeeModel empModel,EmpPersonalDetailsModel empPersonalDetailsModel,EmpPayDetailsModel empPayDetailsModel) //passing obj of ContactModel
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAdd_Employee_Record", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@PersonId", model.PersonId);//we are not taking this bcoz we assigned it as identity
                    command.Parameters.AddWithValue("@EmployeeName",empModel.EmployeeName);
                    command.Parameters.AddWithValue("@JoiningDate", empModel.JoiningDate);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
                    
                    empPersonalDetailsModel.ID=empModel.EmpId;
                    SqlCommand command2 = new SqlCommand("SpAdd_Employee_PersonalDetails_Record", connection);
                    command2.CommandType = System.Data.CommandType.StoredProcedure;
                    command2.Parameters.AddWithValue("ID", empPersonalDetailsModel.ID);
                    command2.Parameters.AddWithValue("@EmpDepart", empPersonalDetailsModel.EmpDepart);
                    command2.Parameters.AddWithValue("@EmpMobileNo", empPersonalDetailsModel.EmpMobileNo);
                    command2.Parameters.AddWithValue("@EmpAddress", empPersonalDetailsModel.EmpAddress);

                    var result2 = command2.ExecuteNonQuery();

                    empPayDetailsModel.Id= empModel.EmpId;
                    empPayDetailsModel.EmpDepart = empPersonalDetailsModel.EmpDepart;
                    SqlCommand command3 = new SqlCommand("SpAdd_Employee_PayDetails_Record", connection);
                    command3.CommandType = System.Data.CommandType.StoredProcedure;
                    command3.Parameters.AddWithValue("ID", empPayDetailsModel.Id);
                    command3.Parameters.AddWithValue("@EmpDepart", empPayDetailsModel.EmpDepart);
                    command3.Parameters.AddWithValue("@BasicPay", empPayDetailsModel.BasicPay);
                    command3.Parameters.AddWithValue("@TaxablePay", empPayDetailsModel.TaxablePay);
                    command3.Parameters.AddWithValue("@tax", empPayDetailsModel.tax);
                    command3.Parameters.AddWithValue("@NetPay", empPayDetailsModel.NetPay);

                    var result3 = command3.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        //Method to retrieve All Records of Employees from DB
        public void DisplayEmployeeRecord()
        {
            try
            {
                EmployeeModel employeeModel = new EmployeeModel();
                EmpPersonalDetailsModel empPersonalDetailsModel = new EmpPersonalDetailsModel();    
                EmpPayDetailsModel empPayDetailsModel = new EmpPayDetailsModel();
                this.connection.Open();

                string query = @"select emp.* ,empdetails.*,emppaydetails.* from ((employee_payroll emp inner join employee_personaldetails empdetails on emp.ID=empdetails.ID) inner join employee_paydetails emppaydetails  on emp.ID=emppaydetails.ID and  empdetails.EmpDepart=emppaydetails.EmpDepart)";  //Query to fetch all records from employee_payroll Table with implentation ER diagram
                
                //Passign query to sql command object
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader sqlDataReader = command.ExecuteReader();

                if (sqlDataReader.HasRows)
                {
                    Console.WriteLine("\n>> Records Retrieved From DataBase : ");
                    //Read each row
                    while (sqlDataReader.Read())
                    {
                        employeeModel.EmpId = Convert.ToInt32(sqlDataReader["ID"]);
                        employeeModel.EmployeeName = Convert.ToString(sqlDataReader["EmployeeName"]);
                        
                        empPersonalDetailsModel.EmpDepart = Convert.ToString(sqlDataReader["EmpDepart"]);
                        employeeModel.JoiningDate = Convert.ToDateTime(sqlDataReader["JoiningDate"]);
                        empPersonalDetailsModel.EmpMobileNo = Convert.ToInt64(sqlDataReader["EmpMobileNo"]);
                        empPersonalDetailsModel.EmpAddress = Convert.ToString(sqlDataReader["EmpAddress"]);
                        
                        empPayDetailsModel.BasicPay = Convert.ToDouble(sqlDataReader["BasicPay"]);
                        empPayDetailsModel.TaxablePay = Convert.ToDouble(sqlDataReader["TaxablePay"]);
                        empPayDetailsModel.tax= Convert.ToDouble(sqlDataReader["tax"]);
                        empPayDetailsModel.NetPay = Convert.ToDouble(sqlDataReader["NetPay"]);

                        //Display Record of current object
                        Console.WriteLine("\nEmployee ID :- {0} \nEmployee Name :- {1} \nEmployee Department :- {2} \nEmployee Join Date :- {3} \nMobile No :- {4} \nAddress :- {5} \nBasic Pay :- {6} \nTaxable Pay :- {7} \nTax Rate :- {8} \nNet Pay :- {9}", employeeModel.EmpId, employeeModel.EmployeeName, empPersonalDetailsModel.EmpDepart,employeeModel.JoiningDate,empPersonalDetailsModel.EmpMobileNo,empPersonalDetailsModel.EmpAddress,empPayDetailsModel.BasicPay,empPayDetailsModel.TaxablePay,empPayDetailsModel.tax,empPayDetailsModel.NetPay);
                    }

                    //Close sqlDataReader Connection
                    sqlDataReader.Close();
                }
                else
                {
                    Console.WriteLine("\n> Your DataBase is Empty!!");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
    }
}
