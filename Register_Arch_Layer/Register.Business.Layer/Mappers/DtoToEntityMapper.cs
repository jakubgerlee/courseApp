using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Register.Business.Layer.Dto;
using Register.Data.Layer.Models;

namespace Register.Business.Layer.Mappers
{
    public class DtoToEntityMapper : IDtoToEntityMapper
    {
        public static Student StudentDtoModelToEntity(StudentDto studentDto)
        {

            var student = new Student();
            student.Id = studentDto.Id;
            student.Pesel = studentDto.Pesel;
            student.Name = studentDto.Name;
            student.Surname = studentDto.Surname;
            student.DateOfBirth = studentDto.DateOfBirth;
            student.Sex = studentDto.Sex;

            return student;

        }

        public static List<Student> StudentDtoListToStudentList(List<StudentDto> studentDtos)
        {
            List<Student> studentList = new List<Student>();
            foreach (var studentD in studentDtos)
            {
                studentList.Add(StudentDtoModelToEntity(studentD));
            }

            return studentList;
        }

        public static Course CourseDtoToModelToEntity(CourseDto courseDto)
        {
            var course = new Course();
            {
                course.Id = courseDto.Id;
                course.CourseTitle = courseDto.CourseTitle;
                course.Teacher = courseDto.Teacher;
                course.DateStart = courseDto.DateStart;
                course.HomeworkThreshold = courseDto.HomeworkThreshold;
                course.PresenceThreshold = courseDto.PresenceThreshold;
                if(courseDto.StudentDtosList != null)
                course.StudentList = StudentDtoListToStudentList(courseDto.StudentDtosList);


                
                return course;
            }
            
        }

        public static CourseDay CourseDayDtoToModelEntity(CourseDayDto courseDayDto)
        {

            var courseDay = new CourseDay();
            courseDay.Student = StudentDtoModelToEntity(courseDayDto.Student);
            courseDay.Absent = courseDayDto.Absent;
            courseDay.Present = courseDayDto.Present;
            courseDay.Allpresence = courseDayDto.Allpresence;
            courseDay.Course = CourseDtoToModelToEntity(courseDayDto.Course);
            
            return courseDay;
        }

        public static long PeselDtoToEntityModel(long pesel)
        {
            var student = new Student();
            student.Pesel = pesel;

            return student.Pesel;
        }

        public Homework HomeworkDtoToModelEntity(HomeworkDto homeworkDto)
        {
            Homework homework = new Homework();
            homework.StudentPoints = homeworkDto.StudentPoints;
            homework.MaxPoints = homeworkDto.MaxPoints;
            homework.Course = CourseDtoToModelToEntity(homeworkDto.Course);
            homework.Student = StudentDtoModelToEntity(homeworkDto.Student);



            return homework;
        }


    }
}
