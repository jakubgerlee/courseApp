using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Register.Data.Layer.Interfaces;
using Register.Data.Layer.Models;
using Register.Data.Layer.UoW;

namespace Register.Data.Layer.RepositoriesServices
{
    public class CourseRepoService : ICourseRepoService
    {
        public bool AddCourse(Course course)
        {
            var rowsAffected = 0;
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();
            var studentRepository = unitOfWorks.GetRepository<Student>();

            List<Student> listOfStudents = new List<Student>();
            //myk, zamiana listy studentow na liste studentow wyciagnietych prosto z bazy
            foreach (var student in course.StudentList)
            {
                Student studentFromData = new Student();
                studentFromData =
                    studentRepository.GetAll()
                        .First(x => x.Pesel == student.Pesel); //First(p => p.Pesel == student.Pesel);
                listOfStudents.Add(studentFromData);
            }
            course.StudentList = listOfStudents; //zamiana list

            courseReposiotry.Add(course);
            unitOfWorks.SaveChanges();
            return rowsAffected == 1;
        } //dodaj kurs

        public bool CheckIfCourseExists(int id)
        {
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();

            var checkCourseExists = courseReposiotry.GetAll().FirstOrDefault(x => x.Id == id);
            unitOfWorks.SaveChanges();
            if (checkCourseExists == null)
                return false; //kurs nie istnieje w bazie
            return true; //kurs istnieje w bazie


        } //sprawdz czy kurs istnieje

        public List<Student> GetStudentsListFromCourse(int id)
        {
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();

            List<Student> studentListFromCourse = null;
            studentListFromCourse = courseReposiotry.GetAll().Include(x => x.StudentList).First(d => d.Id == id)
                .StudentList.ToList();


            return studentListFromCourse;
        } //wez liste studentow z kursu

        public Course GetCourse(int selectedCourse)
        {
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();
            Course course = null;

            var courseBySelectedCourse = courseReposiotry.GetAll()
                .Include("StudentList")
                .Include("CourseDay")
                .SingleOrDefault(a => a.Id == selectedCourse);

            return courseBySelectedCourse;

        } //pobranie kursu po id

        public bool ChangeCourseInformation(Course course)
        {
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();
            int rowsAffected = 0;
            List<Course> courseList = null;

            courseList = courseReposiotry.GetAll().Where(a => a.Id == course.Id).ToList();

            foreach (var courses in courseList)
            {
                if (!String.IsNullOrEmpty(course.CourseTitle))
                {
                    courses.CourseTitle = course.CourseTitle;
                }
                if (!String.IsNullOrEmpty(course.Teacher))
                {
                    courses.Teacher = course.Teacher;
                }

                courses.HomeworkThreshold = course.HomeworkThreshold;
                courses.PresenceThreshold = course.PresenceThreshold;

            }
            unitOfWorks.SaveChanges();
            return (rowsAffected == 1);
        } //zmien informacje o kursie

        public bool RemoveStudentFromCourse(int courseId, long studentPesel)
        {
            var unitOfWorks = new RegisterArchLayerUoW();
            var courseReposiotry = unitOfWorks.GetRepository<Course>();
            int rowsAffected = 0;
                List<Student> studentListFromCourse = null;

                var selectedCourse = courseReposiotry.GetAll().Include(a => a.StudentList).First(x => x.Id == courseId);
                studentListFromCourse = courseReposiotry.GetAll().Include(x => x.StudentList).First(d => d.Id == courseId)
                    .StudentList;
                foreach (var student in studentListFromCourse)
                {
                    if (student.Pesel == studentPesel)
                    {
                        studentListFromCourse.Remove(student);
                        break;
                    }

                }
                selectedCourse.StudentList = studentListFromCourse;
                courseReposiotry.Update(selectedCourse);
                unitOfWorks.SaveChanges();


            return (rowsAffected == 1);
        }//usuniecie studenta z kursu po id's


    }
}


