using Lecture.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class EvaluationViewModel
    {

        public IEnumerable<Group> Groups { get; set; }

        public IEnumerable<Student> Students { get; set; }

        public int? Id { get; set; }

        [Required]
        [Display(Name = "Evaluation's name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Evaluation's score")]
        public float Score { get; set; }

        [Required]
        [Display(Name = "Group")]
        public int GroupId { get; set; }

        [Required]
        [Display(Name = "Student")]
        public int StudentId { get; set; }

        public string Title 
        {
            get 
            {
                return (Id != 0) ? "Edit Evaluation" : "New Evaluation";
            }
        }

        public EvaluationViewModel()
        {
            Id = 0;
        }

        public EvaluationViewModel(Evaluation evaluation)
        {
            Id = evaluation.Id;
            Name = evaluation.Name;
            Score = evaluation.Score;
            GroupId = evaluation.GroupId;
            StudentId = evaluation.StudentId;
        }
    }
}
