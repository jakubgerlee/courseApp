using Register.Data.Layer.Models;

namespace Register.Data.Layer.RepositoriesServices
{
    public interface IHomeworkRepoService
    {
        Homework GetHomeworkByIds(int idStudent, int idCourse);
        bool AddNewHomework(Homework homework);
    }
}