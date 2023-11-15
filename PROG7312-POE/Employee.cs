using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG7312_POE
{
    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public Employee(int empNo, string name) => (EmpNo, Name) = (empNo, name);
    }
}
