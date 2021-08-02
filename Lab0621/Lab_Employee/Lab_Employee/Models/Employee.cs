using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab_Employee.Models
{
    public class Employee
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string picture { get; set; }
        public string officePhone { get; set; }
        public string cellPhone { get; set; }
        public string email { get; set; }
        public string city { get; set; }
    }
}
