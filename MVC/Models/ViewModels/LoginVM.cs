using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "UserName is Required.")]
        [Display(Name = "Pseudo")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }

    }
}