using Register.Data.Layer.Models;

namespace Register.Data.Layer.Repositories
{
    public interface IStudentRepo
    {
        Student GetStudentByPesel(long pesel);
        bool CheckIfStudentExists(long pesel);
        bool CheckIfPeselExists(long pesel);
        bool AddStudent(Student student);
        bool ChangeStudentPersonalData(Student student);
    }
}