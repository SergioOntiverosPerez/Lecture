using Lecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class StudentViewModel
    {

        public IEnumerable<Course> Courses { get; set; }

        public int? Id { get; set; }

        [Required(ErrorMessage = "Please enter student's code")]
        [Display(Name = "Code")]
        public int StudentCode { get; set; }


        [Required(ErrorMessage = "Please enter student's name")]
        [StringLength(255)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter student's surname")]
        [StringLength(255)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please enter student's e-mail")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Course")]
        [Required(ErrorMessage = "Please select a course")]
        public int CourseId { get; set; }

        public string Title 
        {
            get 
            {
                return (Id != 0) ? "Edit Student" : "New Student";
            }
        }

        public StudentViewModel()
        {
            Id = 0;
        }

        public StudentViewModel(Student student)
        {
            Id = student.Id;
            StudentCode = student.StudentCode;
            Name = student.Name;
            Surname = student.Surname;
            Email = student.Email;
            CourseId = student.CourseId;
        }
    }
}
