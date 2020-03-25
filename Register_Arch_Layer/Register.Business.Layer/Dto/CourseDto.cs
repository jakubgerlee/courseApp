using System;
using System.Collections.Generic;

namespace Register.Business.Layer.Dto
{
    public class CourseDto
    {
        public int Id;
        public string CourseTitle;
        public string Teacher;
        public DateTime DateStart;
        public int HomeworkThreshold;
        public int PresenceThreshold;

        public List<StudentDto> StudentDtosList; //student do kursu kurs do studenta - polaczenie

        public List<CourseDayDto> CourseDayDto; //lista obecnosci
    
    }
}
