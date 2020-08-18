using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Código")]
        public int StudentCode { get; set; }


        [Required]
        [StringLength(255)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Sobrenome")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        
        public Course Course { get; set; }

        [Display(Name = "Curso")]
        public int CourseId { get; set; }

    }
}
