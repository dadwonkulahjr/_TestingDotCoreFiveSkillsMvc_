using System.Collections.Generic;
using System.Linq;

namespace SimpleApplicationTestingMvcSkills.Models
{
    public class SQLDbRepository : IEmployeeRepo
    {
        private AppDbContext _appDbContext;
        public SQLDbRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(Employee employee)
        {
            _appDbContext.Employees.Add(employee);
            _appDbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee employee = _appDbContext.Employees.Find(id);
            if (employee != null)
            {
                _appDbContext.Employees.Remove(employee);
                _appDbContext.SaveChanges();
            }
        }
        public Employee GetEmployee(int id)
        {
            return _appDbContext.Employees.Find(id);
        }
        public IEnumerable<Employee> GetListOfEmployees()
        {
            return _appDbContext.Employees;
        }
        public void Update(Employee employee)
        {
            Employee updatedEmployee = _appDbContext.Employees.Find(employee.ID);
            updatedEmployee.Name = employee.Name;
            updatedEmployee.Email = employee.Email;
            updatedEmployee.Department = employee.Department;
            updatedEmployee.PhotoPath = employee.PhotoPath;

            _appDbContext.SaveChanges();
        }
    }
}
