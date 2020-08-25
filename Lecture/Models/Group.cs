using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Group
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Group code")]
        public int GroupCode { get; set; }

        [Required]
        [Display(Name = "Group name")]
        public string Name { get; set; }

        public Subject Subject { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        public Professor Professor { get; set; }

        [Required]
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        public DateTime DateAdded { get; set; }

    }
}
