using System;
using System.Collections.Generic;
using Register.Business.Layer.Dto;

namespace Register.Business.Layer
{
    public class StudentDto 
    {
        public int Id;
        public long Pesel;
        public string Name;
        public string Surname;
        public DateTime DateOfBirth;
        public long Sex;

        public List<CourseDto> CourseDtosList; //student do kursu kurs do studenta

        public List<CourseDayDto> CourseDayDtosLinst;



    }
}
