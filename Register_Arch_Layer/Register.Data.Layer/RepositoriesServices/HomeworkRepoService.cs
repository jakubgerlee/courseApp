using System.Data.Entity;
using System.Linq;
using Register.Data.Layer.Models;
using Register.Data.Layer.UoW;

namespace Register.Data.Layer.RepositoriesServices
{
    public class HomeworkRepoService : IHomeworkRepoService
    {

        //TODO: To co wyciagamy z bazy
        public Homework GetHomeworkByIds(int idStudent, int idCourse)
        {
            Homework homework = null;
            var unitOfWork = new RegisterArchLayerUoW();
            var homeworkRepository = unitOfWork.GetRepository<Homework>();
                
            return homeworkRepository.GetAll().Include(c => c.Course) //Dodaje obiekt klasy Course ktory jest w relacji z CourseDay
                .Include(c => c.Student) //Dodaje obiekt klasy Student ktory jest w realcji z CourseDay
                .Single(c => c.Course.Id == idCourse && c.Student.Id == idStudent); //wybiera dokladnie jeden obiekt, ktory ma id kursu i studenta zgodne z podanym jako parametry wywolania metody w ktorej jestesmy
            ;
        } //Pobranie pracy domowej po id

        //TODO: To co dajemy do bazy
        public bool AddNewHomework(Homework homework)
        {
            var rowsAffected = 0;
            var unitOfWork = new RegisterArchLayerUoW();
            var homeworkRepository =  unitOfWork.GetRepository<Homework>();
            var findRekordStudentByIds = homeworkRepository.GetAll().Where(x => x.Student.Id == homework.Student.Id && x.Course.Id == homework.Course.Id)
                    .ToList();


                if (findRekordStudentByIds.Count != 0)//lista nie jest pusta
                {

                    foreach (var student in findRekordStudentByIds)
                    {

                        student.StudentPoints += homework.StudentPoints;
                        student.MaxPoints += homework.MaxPoints;

                    }

                    unitOfWork.SaveChanges();
                }
                else
                {
                    var student = unitOfWork.GetRepository<Student>();
                    var course = unitOfWork.GetRepository<Course>();
                    student.Update(homework.Student);
                    course.Update(homework.Course);
                    homeworkRepository.Add(homework);
                    unitOfWork.SaveChanges();
                }
            return rowsAffected == 1;

        }


    } //Dodawnia pracy domowej, lub update
}

