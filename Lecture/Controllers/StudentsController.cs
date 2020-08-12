using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Controllers
{
    public class StudentsController : Controller
    {
        public IActionResult showStudent()
        {
            var student = new Student()
            {
                Name = "Sergio",
                Surname = "Ontiveros",
                Email = "sergio@mail.com"
            };

            //return new EmptyResult();
            return View(student);
            //return NotFound();
            //return RedirectToAction("Privacy", "Home");
        }

        //public IActionResult Edit(int movieId)
        //{
        //    return Content("id=" + movieId);
        //}

        //public IActionResult SortStudents(string name)
        //{
        //    var student = new Student()
        //    {
        //        Name = name
        //    };

        //    return Content(student.Name);
        //}

        //public IActionResult Surname(string surname)
        //{
        //    var student = new Student()
        //    {
        //        Surname = surname

        //    };
        //    return Content(student.Surname);
        //}
    }
}
