using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Employee : Person
    {

        public Employee() { }

        public Employee(int Id, string Name, int Age, string Department, string Designation, float Salary)
        {
            this.Id = Id;
            this.Name = Name;
            this.Age = Age;
            this.Department = Department;
            this.Designation = Designation;
            this.Salary = Salary;
        }
        public string Department { get; set; }

        public string Designation { get; set; }

        public float Salary { get; set; }
    }
}
