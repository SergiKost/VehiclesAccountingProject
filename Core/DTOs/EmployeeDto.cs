using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Core.DTOs
{
    public class EmployeeDto : BaseDto
    {
        [Display(Name = "First name")]
        public string FirstName { get; set; }   

        [Display(Name ="Last name")]
        public string LastName { get; set; }

        [Display(Name = "Role")]
        public string RoleId { get; set; }

        public string Role { get; set; }

        [Display(Name = "Drive License Number ")]
        public string DriveLicenseNumber { get; set; }

        public List<MultiSelectDto> Vehicles { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "The password and confirmation password don't match")]
        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }

        public bool IsActive { get; set; }
    }
}
