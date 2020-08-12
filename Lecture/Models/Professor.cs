using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class Professor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DegreeTypes Degree { get; set; }
        public string Email { get; set; }

    }
}
