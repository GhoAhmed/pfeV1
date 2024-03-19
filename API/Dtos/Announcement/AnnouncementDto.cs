using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Dtos.Announcement
{
    public class AnnouncementDto
    {
        public int AnnouncementId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImagesUrls { get; set; } = [];
        public HouseSpace Space { get; set; }
        public string Address { get; set; } = string.Empty;
        public decimal AmountPerMonth { get; set; }
        public int UserId { get; set; }
        //public User? User { get; set; }
    }

    public enum HouseSpace { S0, S1, S2, S3, S4, other };
}