
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Interfaces
{
    public interface IEmployee
    {
        void CreateEmployee(EmployeeDTO employee);
        void UpdateEmployee(int EmployeeId, EmployeeDTO employee);
        void DeleteEmployee(int EmployeeId);
        void EmployeeDeepDelete(int EmployeeId);
        void GetAllEmployees();
        void GetEmployeeById(int EmployeeId);
    }
}
