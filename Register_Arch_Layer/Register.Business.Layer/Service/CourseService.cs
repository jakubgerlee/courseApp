using System.Collections.Generic;
using System.Linq;
using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Data.Layer;
using Register.Data.Layer.Interfaces;
using Register.Data.Layer.Models;
using Register.Data.Layer.RepositoriesServices;
using Register.Data.Layer.UoW;


namespace Register.Business.Layer.Service
{
    public class CourseService : ICourseService
    {
        private IEntityToDtoMapper _entityToDtoMapper;
        private ICourseRepoService _courseRepoService;
        private GenericRepository<Student> _studentRepository;
        


        public CourseService()
        {
            _courseRepoService = new CourseRepoService();
            _entityToDtoMapper = new EntityToDtoMapper();
            _studentRepository = RegisterArchLayerUoW.GetInstance().GetRepository<Student>();
        }

        //TODO Wszystko co leci w dol do bazy

        public bool AddCourse(CourseDto course)
        {

            var newCourse = DtoToEntityMapper.CourseDtoToModelToEntity(course);
            _courseRepoService.AddCourse(newCourse);
            return true;
        }

        public bool CheckIfStudentExists(long pesel)
        {
            var countStudentWithThisPesel = _studentRepository.GetAll().Count(x => x.Pesel == pesel);
            if (countStudentWithThisPesel == 0)
            {
                return false; //nie ma takiego peselu w bazie
            }
            return true; //jest taki pesel w bazie

        }

        public bool ChangeCourseInfo(CourseDto courseDto)
        {


            var course = DtoToEntityMapper.CourseDtoToModelToEntity(courseDto);
                if (_courseRepoService.ChangeCourseInformation(course))

                {
                    return true;//zmieniono dane klienta 
                }
                else
                {
                    return false;//zmieniono dane klienta
                }
            
        }

        public bool RemoveStudentFromCourses(int courseId, long studentPesel)
        {
            var succes  = _courseRepoService.RemoveStudentFromCourse(courseId, studentPesel);
            return succes;
        }

//tutaj

        //TODO Wszystko co leci do gory

        public StudentDto GetStudentFromDl(long pesel)
        {
            var studentRepositories = new StudentRepoService();
            var student = studentRepositories.GetStudentByPesel(pesel);
            
           // var student = _studentRepo.GetStudentByPesel(pesel);
            return EntityToDtoMapper.StudentEntityModelToDto(student);
        }

        public bool CheckIfCourseExistss(int id)
        {
          var success = _courseRepoService.CheckIfCourseExists(id);
            return success;
        } //sprawdza czy kurs istnieje true = isntieje
        
        public List<StudentDto> GetStudentListFromDl(int id) //test
        {
            List<StudentDto> studentListFromCourse = null;
            
             var StudentListFromDl = _courseRepoService.GetStudentsListFromCourse(id);

            studentListFromCourse = EntityToDtoMapper.StudentListToStudentDtoList(StudentListFromDl);

            return studentListFromCourse;
        }//bierze liste uczestników kursu jeśli dostanie nazwe kursu

        public CourseDto GetCourseById(int selectedCourse) //wyciagnij kurs po id //test
        {
            CourseDto courseDto = new CourseDto();

            var course = _courseRepoService.GetCourse(selectedCourse);
            courseDto = _entityToDtoMapper.CourseModelToDto(course);

            return courseDto;
        }
    }

}
