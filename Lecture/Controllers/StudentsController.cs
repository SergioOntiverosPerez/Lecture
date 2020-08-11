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

            return View(student);
        }
    }
}
