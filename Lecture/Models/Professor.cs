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

        [Required(ErrorMessage = "Please enter professor's name")]
        [StringLength(255)]
        [Display(Name = "Professor's name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter professor's degree")]
        [Display(Name = "Professor's degree")]
        public DegreeTypes Degree { get; set; }
        
        [Required(ErrorMessage ="Please enter professor's e-mail")]
        [Display(Name = "Professor's e-mail")]
        public string Email { get; set; }

        [Display(Name = "Professor's birthdate")]
        public DateTime? Birthdate { get; set; }
    }
}
