using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Data;
using Lecture.Models;
using Lecture.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Controllers
{
    public class SubjectsController : Controller
    {

        private readonly LectureContext _context;

        public SubjectsController(LectureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var subjects = from s in _context.Subjects
                           select s;

            if (!String.IsNullOrEmpty(searchString))
                subjects = subjects.Where(s => s.Name.Contains(searchString)); 

            return View(await subjects.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var subject = await _context.Subjects
                .FirstOrDefaultAsync(s => s.Id == id);

            if (subject == null)
                return NotFound();

            return View(subject);
        }

        public IActionResult New()
        {
            var subject = new SubjectViewModel();

            return View("SubjectForm", subject);
        }
    }
}
