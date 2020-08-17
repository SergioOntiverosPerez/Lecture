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
        public int StudentCode { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

    }
}
