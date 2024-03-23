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
        var announcementsWithUsers = await _context.announcements.Include(a => a.AppUser).ToListAsync();
        return View(announcementsWithUsers);
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
}
