using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Business.Layer.Dto
{
    class CourseDto
    {
        public string CourseTitle;
        public string Teacher;
        public DateTime DateStart;
        public int HomeworkThreshold;
        public int PresenceThreshold;
        public int NoStudent;
       // public List<StudentDto> UczestnicyStudentDtos;
        // public static Dictionary<long, Person> StudentLog = new Dictionary<long, Person>();

    }
}
