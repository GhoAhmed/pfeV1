using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos.Announcement
{
    public class UpdateAnnouncementRequestDto
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<string> ImagesUrls { get; set; } = [];
        public HouseSpace Space { get; set; }
        public string Address { get; set; } = string.Empty;
        public decimal AmountPerMonth { get; set; }
        public int UserId { get; set; }
    }
}