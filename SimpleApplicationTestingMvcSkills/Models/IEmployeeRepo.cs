using System.Collections.Generic;

namespace SimpleApplicationTestingMvcSkills.Models
{
    public interface IEmployeeRepo
    {
        Employee GetEmployee(int id);
        IEnumerable<Employee> GetListOfEmployees();
        void Add(Employee employee);
        void Update(Employee employee);
        void Delete(int id);
    }
}
