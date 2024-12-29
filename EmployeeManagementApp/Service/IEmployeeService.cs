using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Service
{
        public  interface IEmployeeService
    {
        string AddEmployee(Employee employee);
        string DeleteEmployee(int Id);
        List<Employee> GetAllEmploye();
        Employee GetEmployee(int Id);
        string UpdateEmployee(Employee employee);
    }
}
