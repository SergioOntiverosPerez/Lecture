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
    public class GroupsController : Controller
    {
        private readonly LectureContext _context;

        public GroupsController(LectureContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var groups = from g in _context.Groups.Include(g => g.Subject)
                         select g;

            if (!String.IsNullOrEmpty(searchString))
                groups = groups.Where(g => g.Name.Contains(searchString));

            return View(await groups.ToListAsync());
        }

        public IActionResult New()
        {
            var subjects = _context.Subjects.ToList();
            var professors = _context.Professors.ToList();

            var viewModel = new GroupViewModel
            { 
                Subjects = subjects,
                Professors = professors
            };

            return View("GroupForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Group group)
        {
            if(!ModelState.IsValid)
            {
                var groupModel = new GroupViewModel(group)
                {
                    Subjects = _context.Subjects.ToList(),
                    Professors = _context.Professors.ToList()
                };

                return View("GroupForm", groupModel);
            }

            if(group.Id == 0)
            {
                group.DateAdded = DateTime.Now;
                _context.Groups.Add(group);
            }
            else
            {
                var groupInDb = _context.Groups.Single(g => g.Id == group.Id);
                groupInDb.Name = group.Name;
                groupInDb.GroupCode = group.GroupCode;
                groupInDb.ProfessorId = group.ProfessorId;
                groupInDb.SubjectId = group.SubjectId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Groups");
        }
    }
}
