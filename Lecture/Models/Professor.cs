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
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }
        
        [Display(Name = "Formação")]
        public DegreeTypes Degree { get; set; }
        
        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Data de nascimento")]
        public DateTime? Birthdate { get; set; }
    }
}
