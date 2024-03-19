using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Dtos.Announcement;
using API.Mappers;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/announcement")]
[ApiController]
public class AnnouncementController : ControllerBase
{
    private readonly ApplicationDBContext _context;

    public AnnouncementController(ApplicationDBContext context)
    {
        _context = context;
    }

    //Get All Announcements
    [HttpGet]
    public IActionResult GetAnnouncements()
    {
        var announcements = _context.Announcements.ToList()
        .Select(s => s.ToAnnouncementDto());
        return Ok(announcements);
    }

    //Get Announcement By Id
    [HttpGet("{id}")]
    public IActionResult GetAnnouncement([FromRoute] int id)
    {
        var announcement = _context.Announcements.Find(id);
        if (announcement == null)
        {
            return NotFound();
        }
        return Ok(announcement);
    }

    //Create Announcement
    [HttpPost]
    public IActionResult Create([FromBody] CreateAnnouncementRequestDto announcementDto)
    {
        var announcementModel = announcementDto.ToAnnouncementFromCreateDto();
        _context.Announcements.Add(announcementModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAnnouncement), new { id = announcementModel.AnnouncementId }, announcementModel.ToAnnouncementDto());
    }

    //Update Announcement
    [HttpPut]
    [Route("{id}")]
    public IActionResult Update([FromRoute] int id, [FromBody] UpdateAnnouncementRequestDto updateDto)
    {
        var announcementModel = _context.Announcements.FirstOrDefault(x => x.AnnouncementId == id);
        if (announcementModel == null)
        {
            return NotFound();
        }
        announcementModel.Title = updateDto.Title;
        announcementModel.Description = updateDto.Description;
        announcementModel.ImagesUrls = updateDto.ImagesUrls;
        announcementModel.Space = (Models.HouseSpace)updateDto.Space;
        announcementModel.Address = updateDto.Address;
        announcementModel.AmountPerMonth = updateDto.AmountPerMonth;
        announcementModel.UserId = updateDto.UserId;
        _context.Announcements.Update(announcementModel);
        _context.SaveChanges();
        return Ok(announcementModel.ToAnnouncementDto());
    }

    //Delete Announcement
    [HttpDelete]
    [Route("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        var announcementModel = _context.Announcements.FirstOrDefault(x => x.AnnouncementId == id);
        if (announcementModel == null)
        {
            return NotFound();
        }
        _context.Announcements.Remove(announcementModel);
        _context.SaveChanges();
        return NoContent();
    }



}
