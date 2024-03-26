using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Controllers
{
    public class AnnouncementController : Controller
    {
        private readonly ApplicationDBContext _context;

        public AnnouncementController(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var announcements = await _context.announcements.ToListAsync();
            return View(announcements);
        }

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
}