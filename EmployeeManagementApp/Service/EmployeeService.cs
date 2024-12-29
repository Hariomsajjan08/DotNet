using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repository;

namespace Service
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }
        public string AddEmployee(Employee employee)
        {
            string res = "Failed to add employee";
            if (employeeRepository.AddEmployee(employee))
            {
                res = "Employee added successfully";
            }
            return res;
        }

        public string DeleteEmployee(int Id)
        {
            string res = "Failed to delete employee";
            if (employeeRepository.DeleteEmployee(Id))
            {
                res = "Employee deleted successfully";
            }
            return res;
        }

        public List<Employee> GetAllEmploye()
        {
            List<Employee> employees = employeeRepository.GetAllEmploye();
            return employees;
        }


        public Employee GetEmployee(int Id)
        {
            Employee employee = employeeRepository.GetEmployee(Id);
            return employee;
        }

        public string UpdateEmployee(Employee employee)
        {
            string res = "Failed to update employee";
            if (employeeRepository.UpdateEmployee(employee))
            {
                res = "Employee updated successfully";
            }
            return res;
        }
    }
}
