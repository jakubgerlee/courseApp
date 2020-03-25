using Register.Data.Layer.Models;

namespace Register.Data.Layer.RepositoriesServices
{
    public interface IStudentRepoService
    {
        Student GetStudentByPesel(long pesel);
        bool ChangeStudentPersonalData(Student student);
    }
}