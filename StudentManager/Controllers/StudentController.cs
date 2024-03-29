﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManager.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentManager.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDBContext _context;

        public StudentController(AppDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> IndexAsync(int majorId = 0)
        {
            if (majorId == 0)
                return View(await _context.Students.ToListAsync());
            var studentsByMajor = _context.Students
                         .Where(s => s.MajorRefId == majorId);
            return View(await studentsByMajor.ToListAsync());
        }

        public IActionResult AddOrEditStudent(int id = 0)
        {
            if (id == 0)
                return View(new Student());
            else
                return View(_context.Students.Find(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("StudentId,Name,SchoolYear,MajorRefId")] Student student)
        {
            if (ModelState.IsValid)
            {
                if (student.StudentId == 0)
                    _context.Add(student);
                else
                    _context.Update(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        [Route("/[controller]/Delete")]
        public async Task<IActionResult> Delete(int id)
        {
            var student = await _context.Students.FindAsync(id);
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
