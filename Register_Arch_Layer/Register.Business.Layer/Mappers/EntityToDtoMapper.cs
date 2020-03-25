using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using Register.Business.Layer.Dto;
using Register.Data.Layer.Models;


namespace Register.Business.Layer.Mappers
{
    public class EntityToDtoMapper : IEntityToDtoMapper
    {
        public static StudentDto StudentEntityModelToDto(Student student)
        {
            if (student == null)
            {
                return null;
            }

            var studentDto = new StudentDto();

            studentDto.Id = student.Id;
            studentDto.Name = student.Name;
            studentDto.Surname = student.Surname;
            studentDto.Pesel = student.Pesel;
            studentDto.DateOfBirth = student.DateOfBirth;
            studentDto.Sex = student.Sex;
            

            return studentDto;
        }

        public static List<StudentDto> StudentListToStudentDtoList(List<Student> studentList)
        {
            List<StudentDto> studentListFomCourse = new List<StudentDto>();
            foreach (var studentD in studentList)
            {
                studentListFomCourse.Add(StudentEntityModelToDto(studentD));
            }

            return studentListFomCourse;
        }

        public  CourseDayDto CourseDayModelToDto(CourseDay courseDay)
        {
            if (courseDay == null)
            {
                return null;
            }
            CourseDayDto courseDayDto = new CourseDayDto();
            courseDayDto.Id = courseDay.Id;
            courseDayDto.Present = courseDay.Present;
            courseDayDto.Absent = courseDay.Absent;
            courseDayDto.Allpresence = courseDay.Allpresence;
            if (courseDayDto.Student != null)
            {
            courseDayDto.Student.Id = courseDay.Student.Id;
            }
            if (courseDayDto.Course != null)
            {
                courseDayDto.Course.Id = courseDay.Course.Id;
            }

            return courseDayDto;
        }

        public HomeworkDto HomeworkModelToDto(Homework homework)
        {
            if (homework == null)
            {
                return null;
            }
            HomeworkDto homeworkDto = new HomeworkDto();
            homeworkDto.Id = homework.Id;
            homeworkDto.MaxPoints = homework.MaxPoints;
            homeworkDto.StudentPoints = homework.StudentPoints;
            if (homeworkDto.Student != null) //bardzo ryzykownie //usun
            {
                homeworkDto.Student.Id = homework.Student.Id;
            }
            if (homeworkDto.Student != null)//bardzo ryzykownie // usun
            {
                homeworkDto.Course.Id = homework.Course.Id;
            }

            return homeworkDto;
        }

        public  CourseDto CourseModelToDto(Course course)
        {
            if (course == null)
            {
                return null;
            }
            CourseDto courseDto = new CourseDto();
            courseDto.Id = course.Id;
            courseDto.CourseTitle = course.CourseTitle;
            courseDto.Teacher = course.Teacher;
            courseDto.DateStart = course.DateStart;
            courseDto.HomeworkThreshold = course.HomeworkThreshold;
            courseDto.PresenceThreshold = course.PresenceThreshold;

            return courseDto;
        }



     

    }
}
