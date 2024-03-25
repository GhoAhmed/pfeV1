using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC.Data;

namespace MVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _context;

        public CategoryController(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.categories.ToListAsync();
            return View(categories);
        }

        public async Task<IActionResult> CategoryDetails(int id)
        {
            var category = await _context.categories.FirstOrDefaultAsync(a => a.CategoryId == id);
            return View(category);
        }

    }
}