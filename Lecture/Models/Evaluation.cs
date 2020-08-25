using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Evaluation
    {
        public int Id { get; set; }

        [Required]
        [Display (Name = "Evaluation's name")]
        public string Name { get; set; }

        [Required]
        [Display (Name = "Evaluation's score")]
        public float Score { get; set; }

        public Group Group { get; set; }

        [Required]
        [Display (Name = "Group")]
        public int GroupId { get; set; }

        public Student Student { get; set; }

        [Required]
        [Display (Name = "Student")]
        public int StudentId { get; set; }
    }
}
