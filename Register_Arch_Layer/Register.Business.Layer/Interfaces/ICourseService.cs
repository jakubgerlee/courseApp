using System.Collections.Generic;
using Register.Business.Layer.Dto;

namespace Register.Business.Layer.Service
{
    public interface ICourseService
    {
        List<StudentDto> GetStudentListFromDl(int id); //test
            
        CourseDto GetCourseById(int selectedCourse); //wyciagnij kurs po id //test
            
        bool RemoveStudentFromCourses(int courseId, long studentPesel);

        bool CheckIfCourseExistss(int id);

        bool ChangeCourseInfo(CourseDto courseDto);

        bool AddCourse(CourseDto course);

        bool CheckIfStudentExists(long pesel);

        StudentDto GetStudentFromDl(long pesel);
    }
}