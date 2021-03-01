using System.ComponentModel.DataAnnotations;

namespace SimpleApplicationTestingMvcSkills.ViewModels
{
    public class EmployeeRegisterViewModel
    {
        [EmailAddress(ErrorMessage ="Please enter a valid email address.")]
        [Display(Name ="Office Email")]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Display(Name ="Confirm Password")]
        [Compare(nameof(Password), ErrorMessage ="Password and confirm password must match")]
        [Required]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
