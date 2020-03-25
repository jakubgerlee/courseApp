using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Data.Layer;
using Register.Data.Layer.Models;
using Register.Data.Layer.Repositories;
using Register.Data.Layer.RepositoriesServices;
using Register.Data.Layer.UoW;

namespace Register.Business.Layer.Service
{
    public class CourseDayService : ICourseDayService
    {
        //private ICourseDayRepo _courseDayRepo;
        private IEntityToDtoMapper _entityToDtoMapper;

        private ICourseDayRepoService _courseDayRepoService;
        //private GenericRepository<CourseDay> _courseDayRepository;


        public CourseDayService(/*ICourseDayRepo courseDayRepo,*/ IEntityToDtoMapper entityToDtoMapper, ICourseDayRepoService courseDayRepoService)
        {
            //_courseDayRepo = courseDayRepo;
            _entityToDtoMapper = entityToDtoMapper;
            _courseDayRepoService = courseDayRepoService;
            
            //_courseDayRepository = RegisterArchLayerUoW.GetInstance().GetRepository<CourseDay>();
        }



        //TODO Wszystko co leci w dol do bazy

        public bool AddNewDay(CourseDayDto courseDayDto)
        {
            var courseDay = new CourseDay();
            courseDay = DtoToEntityMapper.CourseDayDtoToModelEntity(courseDayDto);
            //var  succes =  _courseDayRepo.AddNewCourseDay(courseDay);
            var succes = _courseDayRepoService.AddNewCourseDay(courseDay);
            if (succes)
            {
                return true;
            }
            return false;
        }
        
       
        //TODO Wszystko co leci do gory z bazy

        public CourseDayDto GetCourseDayByIds (int idStudent, int idCourse)
        {   
            
            var courseDay = _courseDayRepoService.GetCourseDayFromD(idStudent, idCourse);
            var courseDayDto = _entityToDtoMapper.CourseDayModelToDto(courseDay);
            return courseDayDto; 
        }
       


    }
       




    
}
