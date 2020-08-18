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

        // CREATE PROFESSOR 
        public IActionResult New()
        {
            var professorModel = new ProfessorViewModel();
           
            return View("ProfessorForm", professorModel);
        }


        // GET: Professors/Edit/id
        public IActionResult Edit(int id)
        {
           
            var professor = _context.Professors.SingleOrDefault( p => p.Id == id);
            
            if (professor == null)
                return NotFound();

            var professorModel = new ProfessorViewModel
            {
                Professor = professor
            };

            return View("ProfessorForm", professorModel);
        }

        // POST: 
       [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult Save(Professor professor)
        {
            if(!ModelState.IsValid)
            {
                var professorModel = new ProfessorViewModel
                {
                    Professor = professor
                };
                return View("ProfessorForm", professorModel);
            }

            if (professor.Id == 0)
                _context.Professors.Add(professor);
            else
            {
                var professorInDb = _context.Professors.Single(p => p.Id == professor.Id);
                professorInDb.Name = professor.Name;
                professorInDb.Surname = professor.Surname;
                professorInDb.Degree = professor.Degree;
                professorInDb.Email = professor.Email;
                professorInDb.Birthdate = professor.Birthdate;
            }
                
            _context.SaveChanges();

            return RedirectToAction("Index", "Professors");
        }
        
    }
}
