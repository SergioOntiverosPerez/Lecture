using Lecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class GroupViewModel
    {

        public IEnumerable<Subject> Subjects { get; set; }

        public IEnumerable<Professor> Professors { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Group code")]
        public int GroupCode { get; set; }

        [Required]
        [Display(Name = "Group name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Subject")]
        public int SubjectId { get; set; }

        [Required]
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        public string Title 
        {    
            get
            {
                return (Id != 0) ? "Edit Group" : "New Group";
            }
                
        }

        public GroupViewModel()
        {
            Id = 0;
        }

        public GroupViewModel(Group group)
        {
            Id = group.Id;
            Name = group.Name;
            GroupCode = group.GroupCode;
            ProfessorId = group.ProfessorId;
            SubjectId = group.SubjectId;
        }
    }
}
