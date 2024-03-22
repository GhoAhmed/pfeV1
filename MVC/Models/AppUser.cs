using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace MVC.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        public string? Name { get; set; }
        public string? Address { get; set; }
    }
}