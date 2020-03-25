using System;
using System.Collections.Generic;
using System.Linq;
using Register.Data.Layer.Interfaces;

namespace Register.Data.Layer.Models
{
    public class Student : IEntity
    {
        public int Id { get; set; }
        public long Pesel { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public long Sex { get; set; }

        public List<Course> Courses { get; set; }

        public List<CourseDay> CourseDays { get; set; }


        public override bool Equals(object obj)
        {
            if (obj == null || obj as Student == null)
            {
                return false;
            }

            var objAsBook = obj as Student;

            var areEqual = true;
            areEqual = areEqual && objAsBook.Id == Id;
            areEqual = areEqual && objAsBook.Pesel == Pesel;
            areEqual = areEqual && objAsBook.Name == Name;
            areEqual = areEqual && objAsBook.Surname == Surname;
            areEqual = areEqual && objAsBook.DateOfBirth == DateOfBirth;
            areEqual = areEqual && objAsBook.Sex == Sex;

            if (objAsBook.Courses != null)
            {
                areEqual = areEqual && objAsBook.Courses.Count == Courses.Count;
                foreach (var courses in Courses)
                {
                    areEqual = areEqual && objAsBook.Courses.Any(bs => bs.Equals(courses));
                }
            }
            //if (objAsBook.Courses != null)
            //{
            //    areEqual = areEqual && objAsBook.Courses.Count == CourseDays.Count;
            //    foreach (var courseDays in CourseDays)
            //    {
            //        areEqual = areEqual && objAsBook.CourseDays.Any(bs => bs.Equals(courseDays));
            //    }
            //}
            return areEqual;
        }


    }
}
