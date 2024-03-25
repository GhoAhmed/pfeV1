using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? CategoryName { get; set; }
        [Required]
        public string? CategoryImage { get; set; }

    }
}