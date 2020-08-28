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

        [Required(ErrorMessage ="Please enter student's code")]
        [Display(Name = "Code")]
        public int StudentCode { get; set; }

        [Required(ErrorMessage ="Please enter student's name")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string StudentName { get; set; }

        [Required(ErrorMessage ="Please enter student's e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        public Course Course { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage ="Please select a course")]
        public int CourseId { get; set; }

    }
}
