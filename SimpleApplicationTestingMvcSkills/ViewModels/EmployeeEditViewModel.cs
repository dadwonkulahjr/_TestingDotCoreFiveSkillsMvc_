using Microsoft.AspNetCore.Http;
using SimpleApplicationTestingMvcSkills.HelperEnum;
using SimpleApplicationTestingMvcSkills.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleApplicationTestingMvcSkills.ViewModels
{
    public class EmployeeEditViewModel : Employee
    {
        //public int Id { get; set; }
        //[Required]
        //[Column(name: "Employee Name", TypeName = "nvarchar(50)")]
        //public string Name { get; set; }
        //[Required, EmailAddress(ErrorMessage = "Invalid emial"),
        //    Display(Name = "Office Email")]
        //[Column(name: "Office Email", TypeName = "navarchar(50)")]
        //public string Email { get; set; }
        //[Required]
        //[Column(name: "Department ID", TypeName = "int")]
        //public Department? Department { get; set; }
        public string ExistingPhoto { get; set; }
        public IFormFile Photo { get; set; }
    }
}
