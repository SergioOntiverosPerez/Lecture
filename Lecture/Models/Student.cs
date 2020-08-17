using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Student
    {
        public int Id { get; set; }

        public int StudentCode { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public Course Course { get; set; }

        public int CourseId { get; set; }

    }
}
