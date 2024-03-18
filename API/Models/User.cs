using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models;

public class User
{
    public int UserId { get; set; }
    [Required(ErrorMessage = "Username is required")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Invalid email address")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Password is required")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "Passwords do not match")]
    [DataType(DataType.Password)]
    public string ConfirmPassword { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [RegularExpression(@"^\d{8}$", ErrorMessage = "Invalid phone number")]
    public string PhoneNumber { get; set; } = string.Empty;
    public UserRole Role { get; set; }

}

public enum UserRole { Admin, Client, Renter };
