using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Data;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Controllers
{
    public class StudentsController : Controller
    {
        private readonly LectureContext _context;

        public StudentsController(LectureContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
