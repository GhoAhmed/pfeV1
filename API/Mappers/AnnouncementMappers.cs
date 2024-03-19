using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Dtos.Announcement;
using API.Models;

namespace API.Mappers
{
    public static class AnnouncementMappers
    {
        public static AnnouncementDto ToAnnouncementDto(this Announcement announcementModel)
        {
            return new AnnouncementDto
            {
                AnnouncementId = announcementModel.AnnouncementId,
                Title = announcementModel.Title,
                AmountPerMonth = announcementModel.AmountPerMonth,
                UserId = announcementModel.UserId
            };
        }


    }
}