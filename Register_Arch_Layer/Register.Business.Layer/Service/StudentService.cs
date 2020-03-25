using System.Linq;
using Register.Data.Layer;
using Register.Data.Layer.Models;
using Register.Data.Layer.Repositories;
using Register.Data.Layer.RepositoriesServices;
using Register.Data.Layer.UoW;

namespace Register.Business.Layer.Service
{
    public class StudentService : IStudentService
    {
        private IStudentRepoService _studentRepoService;

        private GenericRepository<Student> _studentRepository;

        public StudentService()
        {
           _studentRepoService = new StudentRepoService();
            _studentRepository = RegisterArchLayerUoW
                .GetInstance()
                .GetRepository<Student>();
        }

        public bool  AddStudents(StudentDto studentDto) //Przekaz do mappowania
        {
                var person = Mappers.DtoToEntityMapper.StudentDtoModelToEntity(studentDto); //mapuje studenta do modelu dostepnego bazie danych
                    _studentRepository.Add(person); //dodaje studenta do bazy
                return false;
            
        }

        public bool CheckIfClientPeselExists(long pesel)
        {
            //var checkPesel = Mappers.DtoToEntityMapper.PeselDtoToEntityModel(pesel); - nie musze mapowac peselu
            //if (_studentRepo.CheckIfPeselExists(checkPesel))
            var countStudentWithThisPesel = _studentRepoService.GetStudentByPesel(pesel);
            if (countStudentWithThisPesel != null)
            {
                return true;//istnieje
            }
            else
            {
                return false;//nie istnieje
            }

        } //Sprawdz czy pesel istnieje

        public bool ChangePersonalDataStudent(StudentDto studentDto)
        {
            var student = Mappers.DtoToEntityMapper.StudentDtoModelToEntity(studentDto);
            if (_studentRepoService.ChangeStudentPersonalData(student))

            {
                return true;//zmieniono dane klienta 
            }
            else
            {
                return false;//zmieniono dane klienta
            }
        } //zmien dane personalne studenta

        public StudentDto GetStudentByPesel(long pesel)
        {
            Student student = new Student();
            StudentDto studentDto = new StudentDto();
            var studentRepoService = new StudentRepoService();
            student = studentRepoService.GetStudentByPesel(pesel); //znajdz studenta po peselu
            studentDto = Mappers.EntityToDtoMapper.StudentEntityModelToDto(student); //mapuj studenta na studentDto


            return studentDto;
        }



    }
}