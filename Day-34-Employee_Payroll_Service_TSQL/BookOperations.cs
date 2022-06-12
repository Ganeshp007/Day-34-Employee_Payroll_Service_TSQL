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

        //Method to get connection to DB
        public void getConnection()
        {
            //Represents a connection to MS Sql Server Database
            SqlConnection connection = new SqlConnection(connectionString);

        }

    }
}
