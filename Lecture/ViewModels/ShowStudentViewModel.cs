using Lecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class ShowStudentViewModel
    {
        public List<Student> Students { get; set; }
        public Professor Professor { get; set; }
    }
}
