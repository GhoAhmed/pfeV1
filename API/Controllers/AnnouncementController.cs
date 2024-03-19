using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
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

    [HttpGet]
    public IActionResult GetAnnouncements()
    {
        var announcements = _context.Announcements.ToList();
        return Ok(announcements);
    }

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

}
