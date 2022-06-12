// See https://aka.ms/new-console-template for more information
using Day_34_Employee_Payroll_Service_TSQL;

Console.WriteLine("----- Welcome to Employee_Payroll System using ADO Library and TSQL -----\n");
BookOperations obj = new BookOperations();
bool check = true;
while (check)
{
    Console.WriteLine("\nChoose the Operation :");
    Console.WriteLine("1.Add New Employee To Employee_Payroll_DB\n2.Display Employee Records from Employee_payroll_DB\n3.Exit");
    Console.Write("\n> ENter your choice : ");
    int option = Convert.ToInt32(Console.ReadLine());

    switch (option)
    {
        case 1:
            Console.WriteLine("\n> Add Employee Records to Employee_Payroll DB....");
            Console.Write("\nHow many Employee Records you want to add :- ");
            int count = Convert.ToInt32(Console.ReadLine());
            int num_of_records = 0;
            while (count > 0)
            {
                BookOperations obj1 = new BookOperations();
                num_of_records++;
                Console.WriteLine("\nEnter Details for contact {0} :", num_of_records);
                var contactmodel = obj1.getContact();
                obj1.AddNewEmployeeRecord(contactmodel);
                count--;
            }
            if (count == 0)
                Console.WriteLine("\n> Records Inserted into AddressBook DB successfully...");
            break;

        case 2:
            Console.WriteLine("\n> Employee Records from Employee_Payroll_DB\n");
            obj.DisplayEmployeeRecord();
            Console.WriteLine("------------------------------------------------");
            break;

        case 3:
            check = false;
            break;

        default: Console.WriteLine("Please Enter a valid choice!!"); break;
    }
}