using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Professor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Nome do Professor")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Sobrenome do Professor")]
        public string Surname { get; set; }
        
        [Display(Name = "Formação do Professor")]
        public DegreeTypes Degree { get; set; }
        
        [Required]
        [Display(Name = "E-mail do Professor")]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento do Professor")]
        public DateTime? Birthdate { get; set; }
    }
}
