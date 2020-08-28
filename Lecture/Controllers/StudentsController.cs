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
    public class StudentsController : Controller
    {
        private readonly LectureContext _context;

        public StudentsController(LectureContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var student = await _context.Students.Include(s => s.Course).SingleOrDefaultAsync(s => s.Id == id);

            if (student == null)
                return NotFound();

            return View(student);
        }


        public IActionResult Edit(int id)
        {
            var student = _context.Students.SingleOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound();

            var viewModel = new StudentViewModel(student)
            {
                Courses = _context.Courses.ToList()
            };

            return View("StudentForm", viewModel);
        }

        // CREATE NEW STUDENT

        public IActionResult New()
        {
            var courses = _context.Courses.ToList();

            var studentModel = new StudentViewModel
            {
                Courses = courses
            };

            return View("StudentForm", studentModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Student student)
        {
            if(!ModelState.IsValid)
            {
                var studentModel = new StudentViewModel(student)
                {
                    Courses = _context.Courses.ToList()
                };

                return View("StudentForm", studentModel);
            }

            if (student.Id == 0)
                _context.Students.Add(student);
            else
            {
                var studentInDb = _context.Students.Single(s => s.Id == student.Id);
                studentInDb.StudentCode = student.StudentCode;
                studentInDb.StudentName = student.StudentName;
                studentInDb.Email = student.Email;
                studentInDb.CourseId = student.CourseId;
            }

            _context.SaveChanges();


            return RedirectToAction("List","Students");
        }
    }
}
