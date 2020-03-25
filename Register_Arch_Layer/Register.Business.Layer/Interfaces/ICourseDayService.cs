using Register.Business.Layer.Dto;

namespace Register.Business.Layer.Service
{
    public interface ICourseDayService
    {
        CourseDayDto GetCourseDayByIds (int idStudent, int idCourse);
        bool AddNewDay(CourseDayDto courseDayDto);
    }
}