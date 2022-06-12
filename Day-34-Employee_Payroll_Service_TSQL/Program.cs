// See https://aka.ms/new-console-template for more information
using Day_34_Employee_Payroll_Service_TSQL;

Console.WriteLine("----- Welcome to Employee_Payroll System using ADO Library and TSQL -----\n");
BookOperations obj = new BookOperations();
bool check = true;
while (check)
{
    Console.WriteLine("\nChoose the Operation :");
    Console.WriteLine("1.Connect To Employee_Payroll_DB\n2.Exit");
    Console.Write("\n> ENter your choice : ");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("\n> Establishing connection to Employee_Payroll DB....");
                Console.WriteLine("> Connection to Employee_Payroll_DB Established successfully...");
            break;
      
        case 2:
            check = false;
            break;

        default: Console.WriteLine("Please Enter a valid choice!!"); break;
    }
}