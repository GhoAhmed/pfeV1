using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace MVC.Models
{
    public class Announcement
    {
        [Key]
        public int AnnouncementId { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Title must be between 3 and 100 characters")]
        public string? Title { get; set; }

        public string? Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "At least one image URL is required")]
        public List<string> ImageUrls { get; set; } = new List<string>();

        [Required(ErrorMessage = "Price per month is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price per month must be a positive value")]
        public decimal PricePerMonth { get; set; }

        [Required(ErrorMessage = "Price per night is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price per night must be a positive value")]
        public decimal PricePerNight { get; set; }

        [Required(ErrorMessage = "House space is required")]
        public HouseSpace Space { get; set; }

        [Required(ErrorMessage = "House status is required")]
        public HouseStatus Status { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [ForeignKey("AppUser")]
        public string? UserId { get; set; }

        public AppUser? AppUser { get; set; }
    }

    // Enums
    public enum HouseSpace
    {
        [Display(Name = "Studio")]
        S0,
        [Display(Name = "1 Bedroom")]
        S1,
        [Display(Name = "2 Bedrooms")]
        S2,
        [Display(Name = "3 Bedrooms")]
        S3,
        [Display(Name = "4 Bedrooms")]
        S4,
        [Display(Name = "Other")]
        Other
    }

    public enum HouseStatus
    {
        [Display(Name = "Complete")]
        Complete,
        [Display(Name = "Pending")]
        Pending,
        [Display(Name = "Other")]
        Other
    }
}
