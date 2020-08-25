using Lecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class SubjectViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter subjects's code")]
        [Display(Name = "Code")]
        public int SubjectCode { get; set; }

        [Required(ErrorMessage = "Please enter subjects's name")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public string Title 
        { 
            get
            {
                return (Id != 0) ? "Edit Subject" : "New Subject";
            }
                
        }

        public SubjectViewModel()
        {
            Id = 0;
        }

        public SubjectViewModel(Subject subject)
        {
            Id = subject.Id;
            SubjectCode = subject.SubjectCode;
            Name = subject.Name;
        }
    }
}
