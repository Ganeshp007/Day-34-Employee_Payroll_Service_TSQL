using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_34_Employee_Payroll_Service_TSQL.Models
{
    public class EmpPersonalDetailsModel
    {
        public int ID { get; set; }
        public string EmpDepart { get; set; }
        public long EmpMobileNo { get; set; }
        public string EmpAddress { get; set; }
    }
}
