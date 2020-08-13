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
    public class ProfessorsController : Controller
    {
        private readonly LectureContext _context;

        public ProfessorsController(LectureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var professors = await _context.Professors.ToListAsync();
            return View(professors);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var professor = await _context.Professors
                .FirstOrDefaultAsync(p => p.Id == id);

            if (professor == null)
                return NotFound();

            return View(professor);
        }

        // GET: Professors/Edit/id
        public IActionResult Edit(int? id)
        {
            //if (id == null)
            //    return NotFound();

            //var professor = _context.Professors.FindAsync(id);
            var professor = from prof in _context.Professors
                            where prof.Id == id
                            select prof;
            
            //if (professor == null)
            //    return NotFound();

            return View(professor.SingleOrDefault());
        }

        // POST: Professor/Edit/id
       
        
    }
}
