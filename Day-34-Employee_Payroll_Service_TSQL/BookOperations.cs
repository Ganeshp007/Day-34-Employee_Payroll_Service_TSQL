using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_34_Employee_Payroll_Service_TSQL
{
    public class BookOperations
    {
        //path for Database Connection
        public const string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Employee_Payroll_DB_Day_34;Integrated Security=True;Connect Timeout=40;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Represents a connection to MS Sql Server Database
        SqlConnection connection = new SqlConnection(connectionString);

        public EmployeeModel getContact()
        {
            EmployeeModel EmployeeRecord = new EmployeeModel();
            //Console.Write("Enter Employee ID :- ");
            //contact.ID =Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter Employee Name :- ");
            EmployeeRecord.EmpName = Console.ReadLine();
            Console.Write("Enter Employee Salary :- ");
            EmployeeRecord.EmpSalary = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter Employee Joining Date :- ");
            EmployeeRecord.JoiningDate = Convert.ToDateTime(Console.ReadLine());
            return EmployeeRecord;
        }

        ////Method to ADD New Employee Record in Employee_Payroll_DB
        public void AddNewEmployeeRecord(EmployeeModel model) //passing obj of ContactModel
        {
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("SpAdd_Employee_Record", connection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@PersonId", model.PersonId);//we are not taking this bcoz we assigned it as identity
                    command.Parameters.AddWithValue("@EmpName", model.EmpName);
                    command.Parameters.AddWithValue("@EmpSalary", model.EmpSalary);
                    command.Parameters.AddWithValue("@JoiningDate", model.JoiningDate);

                    connection.Open();
                    var result = command.ExecuteNonQuery();
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
            EmployeeModel employeeModel = new EmployeeModel();
            this.connection.Open();

            string query = @"select * from employee_payroll";  //Query to fetch all records from employee_payroll Table
            //Passign query to sql command object
            SqlCommand command=new SqlCommand(query, connection);  
            SqlDataReader sqlDataReader = command.ExecuteReader();

            if(sqlDataReader.HasRows)
            {
                Console.WriteLine("\n>> Records Retrieved From DataBase : ");
                //Read each row
                while (sqlDataReader.Read())
                {
                    employeeModel.EmpId = Convert.ToInt32(sqlDataReader["ID"]);
                    employeeModel.EmpName = Convert.ToString(sqlDataReader["EmpName"]);
                    employeeModel.EmpSalary = Convert.ToDouble(sqlDataReader["EmpSalary"]);
                    employeeModel.JoiningDate = Convert.ToDateTime(sqlDataReader["JoiningDate"]);
                    //Display Record of current object
                    Console.WriteLine("\nEmployee ID :- {0} \nEmployee Name :- {1} \nEmployee monthly Salary :- {2} \nEmployee Joining Date :- {3}", employeeModel.EmpId, employeeModel.EmpName, employeeModel.EmpSalary,employeeModel.JoiningDate);
                }
                
                //Close sqlDataReader Connection
                sqlDataReader.Close();
            }
            //Close Connection
            connection.Close();
        }
    }
}
