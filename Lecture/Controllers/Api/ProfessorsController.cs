using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Lecture.Data;
using Lecture.Dtos;
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
        public async Task<ActionResult<IEnumerable<ProfessorDto>>> GetProfessors()
        {
            return await _context.Professors.Select(p => ProfessorToDto(p) ).ToListAsync();
        }
        // GET api/professors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProfessorDto>> GetProfessor(int id)
        {
            var professor = await _context.Professors.SingleOrDefaultAsync(p => p.Id == id);

            if (professor == null)
                return NotFound();

            return ProfessorToDto(professor);
        }

        // POST api/professors
        [HttpPost]
        public async Task<ActionResult<ProfessorDto>> PostProfessor(ProfessorDto professorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var professor = new Professor
            {
                Name = professorDto.Name,
                Email = professorDto.Email
            };

            
            _context.Professors.Add(professor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProfessor), new { id = professor.Id }, ProfessorToDto(professor));
        }

        // PUT api/professor/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProfessor(int id, ProfessorDto professorDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var professorInDb = _context.Professors.SingleOrDefault(p => p.Id == id);

            if (professorInDb == null)
                return NotFound();

            professorInDb.Name = professorDto.Name;
            professorInDb.Email = professorDto.Email;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ProfessorExists(id))
            {
                return NotFound();
            }
            return NoContent();
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

        private bool ProfessorExists(int id) =>
            _context.Professors.Any(p => p.Id == id);

        private static ProfessorDto ProfessorToDto(Professor professor) =>
            new ProfessorDto
            {
                Id = professor.Id,
                Name = professor.Name,
                Email = professor.Email
            };
    }
}
