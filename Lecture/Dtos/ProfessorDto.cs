using Lecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Dtos
{
    public class ProfessorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter professor's name")]
        [StringLength(255)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter professor's surname")]
        [StringLength(255)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter professor's e-mail")]
        public string Email { get; set; }
    }
}
