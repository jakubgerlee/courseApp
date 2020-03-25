

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Register.Data.Layer.Interfaces;

namespace Register.Data.Layer.Models
{
    public class CourseDay : IEntity
    {
        public int Id { get; set; }
        public int Present { get; set; }
        public int Absent { get; set; }
        public int Allpresence { get; set; }

        public Course Course { get; set; } // bede mial id kursu w tabeli
        public Student Student { get; set; } // bede mial id studenta 



        public override bool Equals(object obj)
        {
            if (obj == null || obj as CourseDay == null)
            {
                return false;
            }

            var objAsBook = obj as CourseDay;

            var areEqual = true;

            areEqual = areEqual && objAsBook.Present == Present;
            areEqual = areEqual && objAsBook.Absent == Absent;
            areEqual = areEqual && objAsBook.Allpresence == Allpresence;
            areEqual = areEqual && objAsBook.Student.Equals(Student);
            areEqual = areEqual && objAsBook.Course.Equals(Course);


            return areEqual;
        }


    }
}