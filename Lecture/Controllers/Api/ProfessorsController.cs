using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Lecture.Data;
using Lecture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Lecture.Controllers.Api
{
    [Route("api/Professors")]
    [ApiController]
    public class ProfessorsController : ControllerBase
    {

        private readonly LectureContext _context;

        public ProfessorsController(LectureContext context)
        {
            _context = context;
        }

        // GET: api/professors
        [HttpGet]
        public IEnumerable<Professor> GetProfessors()
        {
            return _context.Professors.ToList();
        }

        // GET api/professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Professor>> GetProfessor(int id)
        {
            var professor = await _context.Professors.SingleOrDefaultAsync(p => p.Id == id);

            if (professor == null)
                return NotFound();

            return professor;
        }

        // POST api/professors
        [HttpPost]
        public async Task<ActionResult<Professor>> PostProfessor(Professor professor)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, professor);
        }

        // PUT api/professor/5
        [HttpPut("{id}")]
        public void UpdateProfessor(int id, Professor professor)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Professor Badrequest");

            var professorInDb = _context.Professors.SingleOrDefault(p => p.Id == id);

            if (professorInDb == null)
                throw new ArgumentException("Professor Not Found");

            professorInDb.Name = professor.Name;
            professorInDb.Surname = professor.Surname;
            professorInDb.Degree = professor.Degree;
            professorInDb.Email = professor.Email;
            professorInDb.Birthdate = professor.Birthdate;

            _context.SaveChanges();
        }

        // DELETE api/<ProfessorsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var professorInDb = _context.Professors.SingleOrDefault(p => p.Id == id);
            if (professorInDb == null)
                throw new ArgumentException("Professor Not Found");

            _context.Professors.Remove(professorInDb);
            _context.SaveChanges();
        }
    }
}
