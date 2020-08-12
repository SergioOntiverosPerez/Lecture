using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Models;
using Lecture.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Controllers
{
    public class ProfessorsController : Controller
    {
        public IActionResult ShowProfessor()
        {
            var professor = new Professor()
            {
                Name = "Sergio",
                Surname = "Ontiveros",
                Degree = "Doctor of Engineering"
            };

            var students = new List<Student>
            {
                new Student { Name = "Carlos"},
                new Student { Name = "Julio" },
                new Student { Name = "Cesar" }
            };

            var viewModel = new ShowStudentViewModel
            {
                Professor = professor,
                Students = students
            };

            return View(viewModel);
        }
    }
}
