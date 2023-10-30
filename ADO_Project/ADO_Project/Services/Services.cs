using ADO_Project.Dtos;
using ADO_Project.Enums;
using ADO_Project.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Services
{
    public class EmployeeService : IEmployee
    {
        public static string connectionString = "Server=.;Database=Companies;Trusted_Connection=True;";


        public void CreateEmployee(EmployeeDTO employee)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;

                connection.Open();

                string query = $"insert into Employee(FirstName,Lastname,Email,Login,Password,Status,Role) values('{employee.FirstName}', '{employee.Lastname}', '{employee.Email}','{employee.Login}','{(employee.Password)}','{Status.Created}','{employee.Role}')";

                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader()) { }
                    Console.WriteLine("Employee Created");
                }
                catch
                {
                    Console.WriteLine("Already Exist");
                }
            }
        }

        public void DeleteEmployee(int EmployeeId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string query = $"update Employee set Status = '{Status.Deleted}',DeletedDate = '{DateTime.UtcNow}' where Id = {EmployeeId} and Status <> 'Deleted';";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Deleted");
                }
            }
        }
        public void EmployeeDeepDelete(int EmployeeId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string query = $"delete from Employee where Id = {EmployeeId};";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Deleted");
                }
            }
        }
        public void GetAllEmployees()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string query = $"select * from Employee where Status <> 'Deleted'";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    bool res = false;
                    while (reader.Read())
                    {
                        res = true;
                        Console.WriteLine($"{reader["Id"]} {reader["FirtName"]} {reader["Lastname"]} {reader["Email"]} {reader["Login"]} {reader["Password"]} {reader["Status"]} {reader["CreatedDate"]} {reader["ModifyDate"]} {reader["DeletedDate"]}");
                    }
                    if (res == false)
                    {
                        Console.WriteLine("Not found");
                    }
                }
            }
        }
        public void GetEmployeeById(int EmployeeId)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string query = $"select * from Employee where Id = {EmployeeId} and Status <> 'Deleted'";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    bool res = false;
                    while (reader.Read())
                    {
                        res = true;
                        Console.WriteLine($"{reader["Id"]} {reader["FirstName"]} {reader["Lastname"]} {reader["Email"]} {reader["Login"]} {reader["Password"]} {reader["Status"]} {reader["CreatedDate"]} {reader["ModifyDate"]} {reader["DeletedDate"]}");
                    }
                    if (res == false)
                    {
                        Console.WriteLine("Not found");
                    }
                }
            }
        }

        public void UpdateEmployee(int EmployeeId, EmployeeDTO employee)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.ConnectionString = connectionString;
                connection.Open();
                string query = $"update Employee set Name = '{employee.FirstName}',surname = '{employee.Lastname}',email = '{employee.Email}',login = '{employee.Login}',password = '{employee.Password}',status = '{Status.Updated}',role = '{employee.Role}',modifydate='{DateTime.Now}' where Id = {EmployeeId} and Status <> 'Deleted';";
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("Updated");
                }
            }
        }
    }
}