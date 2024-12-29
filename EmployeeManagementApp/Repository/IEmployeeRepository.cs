using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repository
{
    public interface IEmployeeRepository
    {
        Employee GetEmployee(int Id);

        List<Employee> GetAllEmploye();
        bool AddEmployee(Employee employee);

        bool UpdateEmployee(Employee person);

        bool DeleteEmployee(int Id);

    }
}
