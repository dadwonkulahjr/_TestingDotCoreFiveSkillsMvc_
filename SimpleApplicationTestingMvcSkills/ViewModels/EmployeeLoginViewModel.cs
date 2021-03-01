using System.ComponentModel.DataAnnotations;

namespace SimpleApplicationTestingMvcSkills.ViewModels
{
    public class EmployeeLoginViewModel
    {
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        [Display(Name ="Office Email")]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
