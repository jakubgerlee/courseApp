using Register.Data.Layer.Models;

namespace Register.Data.Layer.RepositoriesServices
{
    public interface ICourseDayRepoService
    {
        CourseDay GetCourseDayFromD(int idStudent, int idCourse);
        bool AddNewCourseDay(CourseDay courseDayToData);
    }
}