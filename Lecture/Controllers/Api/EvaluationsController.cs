using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Data;
using Lecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lecture.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationsController : ControllerBase
    {
        private readonly LectureContext _context;

        public EvaluationsController(LectureContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<IEnumerable<Evaluation>>> GetEvaluations()
        {
            return await _context.Evaluations
                .Include(ev => ev.Group)
                .Include(ev => ev.Student)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Evaluation>> GetEvalByGroup(int id)
        {
            return await _context.Evaluations
                .Include(ev => ev.Group.Professor)
                .Include(ev => ev.Group.Subject)
                .Include(ev => ev.Student.Course)
                .SingleAsync(ev => ev.Id == id);

            
        }
    }
}
