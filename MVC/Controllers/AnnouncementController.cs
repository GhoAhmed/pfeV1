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



    }
}