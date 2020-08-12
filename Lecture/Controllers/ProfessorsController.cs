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
            

            return View();
        }
    }
}
