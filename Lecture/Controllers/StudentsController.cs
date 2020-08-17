using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Controllers
{
    public class StudentsController : Controller
    {
        private readonly LectureContext _context;

        public StudentsController(LectureContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var students = await _context.Students.ToListAsync();

            return View(students);
        }



        // CREATE NEW STUDENT

        public IActionResult New()
        {
            return View("StudentForm");
        }
    }
}
