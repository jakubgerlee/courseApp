using Register.Business.Layer.Dto;
using Register.Data.Layer.Models;

namespace Register.Business.Layer.Mappers
{
    public interface IEntityToDtoMapper
    {
        HomeworkDto HomeworkModelToDto(Homework homework);
        CourseDayDto CourseDayModelToDto(CourseDay courseDay);
        CourseDto CourseModelToDto(Course course);




    }
}