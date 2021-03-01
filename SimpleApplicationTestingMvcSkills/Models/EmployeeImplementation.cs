using System.Collections.Generic;
using SimpleApplicationTestingMvcSkills.HelperEnum;
using System.Linq;

namespace SimpleApplicationTestingMvcSkills.Models
{
    public class EmployeeImplementation : IEmployeeRepo
    {
        private List<Employee> _list;
        public EmployeeImplementation()
        {
            _list = new List<Employee>()
            {
                new Employee(){ID = 1, Name = "Princess", Department = Department.Mgt , Email = "princess@outlook.com"},
                new Employee(){ID = 2, Name = "James", Department = Department.HR, Email = "james@yahoo.com"},
                new Employee(){ID = 3, Name = "Precious", Department = Department.IT, Email = "precious@gmail.com.com"},
                new Employee(){ID = 4, Name = "Tim", Department = Department.IT, Email = "tim@hotmail.com"},
            };
        }

        public void Add(Employee employee)
        {
            employee.ID = _list.Max((e) => e.ID) + 1;
            _list.Add(employee);
        }

        public void Delete(int id)
        {
            Employee employee = _list.FirstOrDefault((e) => e.ID == id);
            if (employee != null)
            {
                _list.Remove(employee);
            }
        }

        public Employee GetEmployee(int id)
        {
            return _list.FirstOrDefault((e) => e.ID == id);
        }

        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _list;
        }

        public void Update(Employee employee)
        {
            Employee editedEmployee = _list.FirstOrDefault((e) => e.ID == employee.ID);
            if(editedEmployee != null)
            {
                editedEmployee.Name = employee.Name;
                editedEmployee.Email = employee.Email;
                editedEmployee.Department = employee.Department;
            }
        }
    }
}
