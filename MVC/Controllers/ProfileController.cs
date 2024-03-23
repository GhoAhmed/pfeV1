using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext _context;

        public ProfileController(ApplicationDBContext context)
        {
            _context = context;
        }
        // GET: Profile/Index
        public async Task<IActionResult> Index()
        {
            // Get the logged-in user's information
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity!.Name);

            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }

    }
}