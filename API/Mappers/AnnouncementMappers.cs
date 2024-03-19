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
                Description = announcementModel.Description,
                ImagesUrls = announcementModel.ImagesUrls,
                Space = (Dtos.Announcement.HouseSpace)announcementModel.Space,
                Address = announcementModel.Address,
                AmountPerMonth = announcementModel.AmountPerMonth,
                UserId = announcementModel.UserId
            };
        }

        public static Announcement ToAnnouncementFromCreateDto(this CreateAnnouncementRequestDto announcementDto)
        {
            return new Announcement
            {
                Title = announcementDto.Title,
                Description = announcementDto.Description,
                ImagesUrls = announcementDto.ImagesUrls,
                Space = (Models.HouseSpace)announcementDto.Space,
                Address = announcementDto.Address,
                AmountPerMonth = announcementDto.AmountPerMonth,
                UserId = announcementDto.UserId

            };
        }


    }
}