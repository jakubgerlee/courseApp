using System.Collections.Generic;
using Register.Data.Layer.Models;

namespace Register.Data.Layer.Interfaces
{
    public interface ICourseRepoService
    {
        bool AddCourse(Course course);
        bool CheckIfCourseExists(int id);
        List<Student> GetStudentsListFromCourse(int id);
        Course GetCourse(int selectedCourse);
        bool ChangeCourseInformation(Course course);
        bool RemoveStudentFromCourse(int courseId, long studentPesel);
    }
}