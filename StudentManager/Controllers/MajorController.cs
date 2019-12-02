using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManager.Controllers
{
    public class MajorController : Controller
    {
        private readonly AppDBContext _context;

        public MajorController(AppDBContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> IndexAsync()
        {
            return View(await _context.Majors.ToListAsync());
        }

        public IActionResult AddOrEditMajor(int id=0)
        {
            if (id == 0)
                return View(new Major());
            else
                return View(_context.Majors.Find(id));
        }
    }
}
