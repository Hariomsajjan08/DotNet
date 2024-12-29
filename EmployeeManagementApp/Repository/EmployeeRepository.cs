using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MySql.Data.MySqlClient;

namespace Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private MySqlConnection connection;
        public EmployeeRepository()
        {
            string connectionStirng = "server=localhost;database=dotnet_test;user=root;password=cdac";
            connection = new MySqlConnection(connectionStirng);
        }
        public bool AddEmployee(Employee employee)
        {
            bool result = false;
            try
            {
                string query = "insert into employees (Name, Age, Department, Designation, Salary) values (@Name, @Age, @Department, @Designation, @Salary)";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", employee.Name);
                command.Parameters.AddWithValue("@Age", employee.Age);
                command.Parameters.AddWithValue("@Department", employee.Department);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
        public bool DeleteEmployee(int Id)
        {
            bool result = false;
            try { 
                string query = "delete from employees where Id = @Id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    result = true;
                }   
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return false;
        }

        public List<Employee> GetAllEmploye()
        {
            List<Employee> employees = new List<Employee>();
            Employee employee = new Employee();
            try {
                string query = "select * from employees";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read()) {
                    employee = new Employee();
                    employee.Id = reader.GetInt32("Id");
                    employee.Name = reader.GetString("Name");
                    employee.Age = reader.GetInt32("Age");
                    employee.Department = reader.GetString("Department");
                    employee.Designation = reader.GetString("Designation");
                    employee.Salary = reader.GetFloat("Salary");
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return employees;
        }

        public Employee GetEmployee(int Id)
        {
            Employee employee = null;
            try {
                string query = "select * from employees where Id = @Id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", Id);
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    employee = new Employee();
                    employee.Id = reader.GetInt32("Id");
                    employee.Name = reader.GetString("Name");
                    employee.Age = reader.GetInt32("Age");
                    employee.Department = reader.GetString("Department");
                    employee.Designation = reader.GetString("Designation");
                    employee.Salary = reader.GetFloat("Salary");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return employee;
        }

        public bool UpdateEmployee(Employee person)
        {
            bool result = false;
            try {
                string query = "update employees set Name = @Name, Age = @Age, Department = @Department, Designation = @Designation, Salary = @Salary where Id = @Id";
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", person.Id);
                command.Parameters.AddWithValue("@Name", person.Name);
                command.Parameters.AddWithValue("@Age", person.Age);
                command.Parameters.AddWithValue("@Department", person.Department);
                command.Parameters.AddWithValue("@Designation", person.Designation);
                command.Parameters.AddWithValue("@Salary", person.Salary);
                int rowAffected = command.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    result = true;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return result;
        }
    }
}
