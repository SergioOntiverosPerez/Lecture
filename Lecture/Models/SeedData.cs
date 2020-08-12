using Lecture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using(var context = new LectureContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<LectureContext>>()))
            {

                if (context.Professors.Any())
                {
                    return; // DB has been seeded
                }
                context.Professors.AddRange(
                    new Professor
                    {
                        Name = "Sergio",
                        Surname = "Ontiveros-Pérez",
                        Degree = DegreeTypes.PhD,
                        Email = "sergio.perez@fsg.edu.br"
                    },
                    new Professor
                    {
                        Name = "Jeferson",
                        Surname = "Diehl de Oliveira",
                        Degree = DegreeTypes.PhD,
                        Email = "jeferson.oliveira"
                    },
                    new Professor
                    {
                        Name = "Bruna",
                        Surname = "Brenner",
                        Degree = DegreeTypes.Master,
                        Email = "bruna.brenner@fsg.edu.br"
                    }
                 );


                //// Look for any course
                //if(context.Courses.Any())
                //{
                //    return; // Db has been seeded
                //}

                //context.Courses.AddRange(
                //    new Course
                //    {
                //        Name = "Mechanical Engineering"
                //    },
                //    new Course
                //    {
                //        Name = "ELectrical Engineering"
                //    },
                //    new Course
                //    {
                //        Name = "Computer Science"
                //    },
                //    new Course
                //    {
                //        Name = "Civil Engineering"
                //    },
                //    new Course
                //    {
                //        Name = "Industrial Engineering"
                //    }
                //);
                context.SaveChanges();
            }
        }
    }
}
