using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models;

public class Announcement
{
    [Key]
    public int AnnouncementId { get; set; }
    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    [Required(ErrorMessage = "Images URLs are required")]
    public List<string> ImagesUrls { get; set; }
    [Required(ErrorMessage = "Space is required")]
    public HouseSpace Space { get; set; }
    public string Address { get; set; } = string.Empty;
    [Required(ErrorMessage = "Amount per month is required")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal AmountPerMonth { get; set; }
    [ForeignKey("User")]
    public int UserId { get; set; }
    public User? User { get; set; }

}


public enum HouseSpace { S0, S1, S2, S3, S4, other };