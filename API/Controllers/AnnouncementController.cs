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

    //Post Announcement
    [HttpPost]
    public IActionResult Create([FromBody] CreateAnnouncementRequestDto announcementDto)
    {
        var announcementModel = announcementDto.ToAnnouncementFromCreateDto();
        _context.Announcements.Add(announcementModel);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetAnnouncement), new { id = announcementModel.AnnouncementId }, announcementModel.ToAnnouncementDto());
    }


}
