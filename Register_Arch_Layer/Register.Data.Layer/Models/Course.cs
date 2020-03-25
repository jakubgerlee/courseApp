using System;
using System.Collections.Generic;
using Register.Data.Layer.Interfaces;

namespace Register.Data.Layer.Models
{
    public class Course : IEntity
    {
        public int Id { get; set; }
        public string CourseTitle { get; set; }
        public string Teacher { get; set; }
        public DateTime DateStart { get; set; }
        public int HomeworkThreshold { get; set; }
        public int PresenceThreshold { get; set; }

        public virtual List<Student> StudentList { get; set; }
        public virtual List<CourseDay> CourseDay { get; set; }

       


    }
}
