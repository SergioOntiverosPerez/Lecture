using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Data;
using Lecture.Models;
using Lecture.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Controllers
{
    public class EvaluationsController : Controller
    {

        private readonly LectureContext _context;

        public EvaluationsController(LectureContext context)
        {
            _context = context;
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult New()
        {
            var students = _context.Students.ToList();
            var groups = _context.Groups.ToList();

            var viewModel = new EvaluationViewModel
            {
                Students = students,
                Groups = groups
            };

            return View("EvaluationForm", viewModel);
        }


        public IActionResult Save(Evaluation evaluation)
        {
            if(!ModelState.IsValid)
            {
                var evalModel = new EvaluationViewModel(evaluation)
                {
                    Students = _context.Students.ToList(),
                    Groups = _context.Groups.ToList()
                };

                return View("EvaluationForm", evalModel);
            }

            if(evaluation.Id == 0)
            {
                _context.Evaluations.Add(evaluation);
            }
            else
            {
                var evaluationInDb = _context.Evaluations.Single(ev => ev.Id == evaluation.Id);
                evaluationInDb.Name = evaluation.Name;
                evaluationInDb.Score = evaluation.Score;
                evaluationInDb.GroupId = evaluation.GroupId;
                evaluationInDb.StudentId = evaluation.StudentId;
            }

            _context.SaveChanges();

            return RedirectToAction("List", "Evaluations");
        }
    }
}
