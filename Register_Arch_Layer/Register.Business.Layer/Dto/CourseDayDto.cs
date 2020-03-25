using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Register.Business.Layer.Dto
{
    public class CourseDayDto
    {
        public int Id;
        public int Present;
        public int Absent;
        public int Allpresence;
        [Required]
        public CourseDto Course;
        [Required]
        public StudentDto Student;
    
    }
}
