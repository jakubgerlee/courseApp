using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Data.Layer.Repositories;
using Register.Data.Layer.RepositoriesServices;

namespace Register.Business.Layer.Service
{
    public class HomeworkService : IHomeworkService
    {
       // private IHomeworkRepo _homeworkRepo;
        private IEntityToDtoMapper _entityToDtoMapper;

        private IHomeworkRepoService _homeworkRepoService;

        public HomeworkService()
        {
           //_homeworkRepo = new HomeworkRepo();
            _entityToDtoMapper = new EntityToDtoMapper();
            _homeworkRepoService = new HomeworkRepoService();
        }

        public HomeworkService(/*IHomeworkRepo homeworkRepo,*/ IEntityToDtoMapper entityToDtoMapper, IHomeworkRepoService homeworkRepoService)
        {
            //_homeworkRepo = homeworkRepo;
            _entityToDtoMapper = entityToDtoMapper;
            _homeworkRepoService = homeworkRepoService;
        }


        //TODO: wszystko co bierzmy z bazy

        public  HomeworkDto GetHomeworkByIds(int idStudent, int idCourse)
        {
            
            //Pytam o prace domowa kursanta o id idStudent z kursu idCourse
            var homework = _homeworkRepoService.GetHomeworkByIds(idStudent, idCourse);
            //Mapuje homework na homewordDto
            var homeworkDto = _entityToDtoMapper.HomeworkModelToDto(homework);
            //Zwracam homeworkDto
            return homeworkDto;
        }

        //TODO: wszystko co bierzmy do bazy

        public bool AddHomework(HomeworkDto homeworkDto)
        {
            DtoToEntityMapper dtoToEntityMapper = new DtoToEntityMapper();

            var homework = dtoToEntityMapper.HomeworkDtoToModelEntity(homeworkDto);
            var succes = _homeworkRepoService.AddNewHomework(homework);
            if (succes)
            {
                return true;
            }
            return false;

        }
    }
}
