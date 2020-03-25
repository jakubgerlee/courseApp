using System.Collections.Generic;
using Register.Data.Layer.Models;

namespace Register.Data.Layer.Interfaces
{
    public interface ICourseRepo
    {
        Course GetCourse(int selectedCourse);

        bool AddCourse(Course course);

        bool CheckIfCourseExists(int id);

        List<Student> GetStudentsListFromCourse(int id);

        bool ChangeCourseInformation(Course course);

        bool RemoveStudentFromCourse(int courseId, long studentPesel);
    }
}