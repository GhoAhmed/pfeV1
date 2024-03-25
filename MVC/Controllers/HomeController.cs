using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;
using MVC.Models;

namespace MVC.Controllers;

public class HomeController : Controller
{
    //private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDBContext _context;

    public HomeController(ApplicationDBContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var announcements = await _context.announcements
        .Include(a => a.AppUser)
        .Include(a => a.Category)
        .ToListAsync();
        return View(announcements);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    //Announcement Details
    public async Task<IActionResult> AnnouncementDetails(int id)
    {
        var announcement = await _context.announcements
            .Include(a => a.AppUser)
            .Include(a => a.Category)
            .FirstOrDefaultAsync(a => a.AnnouncementId == id);

        if (announcement == null)
        {
            return NotFound();
        }

        return View(announcement);
    }

}
