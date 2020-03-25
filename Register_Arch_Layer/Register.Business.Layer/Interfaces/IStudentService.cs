namespace Register.Business.Layer.Service
{
    public interface IStudentService
    {
        bool  AddStudents(StudentDto studentDto); //Przekaz do mappowania
        bool CheckIfClientPeselExists(long pesel);
        StudentDto GetStudentByPesel(long pesel);
        bool ChangePersonalDataStudent(StudentDto studentDto);
    }
}