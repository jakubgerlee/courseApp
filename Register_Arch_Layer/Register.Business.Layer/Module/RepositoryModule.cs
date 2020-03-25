using Ninject.Modules;
using Register.Data.Layer.Interfaces;
using Register.Data.Layer.RepositoriesServices;

namespace Register.Business.Layer.Module
{
    public class RepositoryModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IEntity>().To<RegisterArchLayerUoW>(); //dodaj entity do uOW
            Bind<ICourseDayRepoService>().To<CourseDayRepoService>();
            Bind<IHomeworkRepoService>().To<HomeworkRepoService>();
            Bind<IStudentRepoService>().To<StudentRepoService>();
            Bind<ICourseRepoService>().To<CourseRepoService>();



        }
    }
}
