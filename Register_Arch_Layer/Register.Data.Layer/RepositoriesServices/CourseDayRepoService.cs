using System.Data.Entity;
using System.Linq;
using Register.Data.Layer.Models;
using Register.Data.Layer.UoW;

namespace Register.Data.Layer.RepositoriesServices
{
    public class CourseDayRepoService : ICourseDayRepoService
    {

        public CourseDay GetCourseDayFromD(int idStudent, int idCourse)
        {
            var unitOfWork = new RegisterArchLayerUoW();
            var courseDay = unitOfWork.GetRepository<CourseDay>();
            return courseDay.GetAll()
                .Include(c => c.Course) //Dodaje obiekt klasy Course ktory jest w relacji z CourseDay
                .Include(c => c.Student) //Dodaje obiekt klasy Student ktory jest w realcji z CourseDay
                .Single(c => c.Course.Id == idCourse &&
                             c.Student.Id ==
                             idStudent); //wybiera dokladnie jeden obiekt, ktory ma id kursu i studenta zgodne z podanym jako parametry wywolania metody w ktorej jestesmy

        }

        public bool AddNewCourseDay(CourseDay courseDayToData)
        {
            var rowsAffected = 0;
            var unitOfWork = new RegisterArchLayerUoW();
            var courseDayRepository = unitOfWork.GetRepository<CourseDay>();
            var findRekordStudentByIds = courseDayRepository.GetAll()
                .Where(x => x.Student.Id == courseDayToData.Student.Id && x.Course.Id == courseDayToData.Course.Id)
                .ToList();

            if (findRekordStudentByIds.Count != 0) //Czy lista nie jest pusta
            {
                //jesli tak, update rekordu

                foreach (var d in findRekordStudentByIds)
                {
                    d.Absent += courseDayToData.Absent;
                    d.Allpresence += courseDayToData.Allpresence;
                    d.Present += courseDayToData.Present;
                }

                unitOfWork.SaveChanges();
            }
            else
            {
                //jesli nie, dodaj nowy rekord z obecnoscia
                var student = unitOfWork.GetRepository<Student>();
                var course = unitOfWork.GetRepository<Course>();

                student.Update(courseDayToData.Student);
                course.Update(courseDayToData.Course);
                courseDayRepository.Add(courseDayToData);

                unitOfWork.SaveChanges();
            }
            return rowsAffected == 1;

        }
    }
}

