using SimpleApplicationTestingMvcSkills.Models;
using System.Collections.Generic;

namespace SimpleApplicationTestingMvcSkills.ViewModels
{
    public class ProgrammingIndexViewModel : EmployeeEditViewModel
    {
        public List<Employee> Employees { get; set; }
      
    }
}
