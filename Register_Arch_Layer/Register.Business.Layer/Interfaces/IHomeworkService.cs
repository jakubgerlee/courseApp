using Register.Business.Layer.Dto;

namespace Register.Business.Layer.Service
{
    public interface IHomeworkService
    {
        HomeworkDto GetHomeworkByIds(int idStudent, int idCourse);
        bool AddHomework(HomeworkDto homeworkDto);
    }
}