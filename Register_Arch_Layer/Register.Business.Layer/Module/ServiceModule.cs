using Ninject.Modules;
using Register.Business.Layer.Mappers;
using Register.Business.Layer.Service;
using Register.Data.Layer.Repositories;


namespace Register.Business.Layer.Module
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICourseDayService>().To<CourseDayService>();
            Bind<ICourseService>().To<CourseService>();
            Bind<IHomeworkService>().To<HomeworkService>();
            Bind<IRaportService>().To<RaportService>();
            Bind<IEntityToDtoMapper>().To<EntityToDtoMapper>();
            Bind<IDtoToEntityMapper>().To<DtoToEntityMapper>();
            Bind<IStudentService>().To<StudentService>();


        }
    }
}
