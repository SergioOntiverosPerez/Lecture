using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Subject
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter subjects's code")]
        [Display(Name = "Code")]
        public int SubjectCode { get; set; }

        [Required(ErrorMessage = "Please enter subjects's name")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

    }
}
