using ADO_Project;




namespace AdoNetProject
{
    public class Program
    {
        static void Main(string[] args)
        {
            EmployeeService employee = new EmployeeService();

            //employee.DeleteEmployee(7);

            EmployeeDTO employees = new EmployeeDTO();

            //employee.GetEmployeeById(7);

            employees.FirstName = "Farxodbek";
            employees.Lastname = "Madrahimov";
            employees.Email = "hiihihh@gmail.com";
            employees.Login = "farxodbek206";
            employees.Password = "password123";
            employees.Role = Role.Programmer;

            employee.CreateEmployee(employees);

           // employee.UpdateEmployee(6, employees);
            //employee.EmployeeDeepDelete(8);
        }
    }
}
