using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_34_Employee_Payroll_Service_TSQL.Models
{
    public class EmpPayDetailsModel
    {
        public int Id { get; set; }
        public string EmpDepart { get; set; }
        public double BasicPay { get; set; }
        public double TaxablePay { get; set; }
        public double tax { get; set; }
        public double NetPay { get; set; }

    }
}
