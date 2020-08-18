using Lecture.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.ViewModels
{
    public class ProfessorViewModel
    {
        public Professor Professor { get; set; }
        public string Title 
        { 
            get
            {
                if (Professor != null && Professor.Id != 0)
                    return "Edit Professor";

                return "New Professor";
            }
        
        }
    }
}
