using Lecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class NewStudentViewModel
    {
        public IEnumerable<Course> Courses { get; set; }

        public Student Student { get; set; }
    }
}
