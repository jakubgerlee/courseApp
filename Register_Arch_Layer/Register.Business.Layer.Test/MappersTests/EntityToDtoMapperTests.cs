using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Register.Business.Layer.Dto;
using Register.Business.Layer.Mappers;
using Register.Data.Layer.Models;

namespace Register.Business.Layer.Test
{
    [TestClass]
    public class EntityToDtoMapperTests
    {
        //TEST STUDENT
        [TestMethod]
        public void StudentMapping_ProvideValidStudent_ReceiveProperlyMappedStudentDto()
        {

            //Przypadek 1
            Student student = new Student();
            student.Id = 1;
            student.Name = "Kuba";
            student.Surname = "Gerlee";
            student.Pesel = 94;
            student.DateOfBirth = new DateTime(09 / 03 / 1994);
            student.Sex = 1;

            StudentDto studentDto = new StudentDto();
            studentDto.Id = 1;
            studentDto.Name = "Kuba";
            studentDto.Surname = "Gerlee";
            studentDto.Pesel = 94;
            studentDto.DateOfBirth = new DateTime(09 / 03 / 1994);
            studentDto.Sex = 1;

            //Przypadek 2
            Student student1 = new Student();
            student1 = null;
            StudentDto studentDto1 = new StudentDto();
            studentDto1 = null;





            var resultOfMapping = Register.Business.Layer.Mappers.EntityToDtoMapper.StudentEntityModelToDto(student);
            var resultOfMapping1 = Register.Business.Layer.Mappers.EntityToDtoMapper.StudentEntityModelToDto(student1);
            Equals(studentDto1, resultOfMapping1);

            Equals(studentDto, resultOfMapping);
            //Assert.AreEqual(studentDto.Id, resultOfMapping.Id);
            //Assert.AreEqual(studentDto.Name, resultOfMapping.Name);
            //Assert.AreEqual(studentDto.Surname, resultOfMapping.Surname);
            //Assert.AreEqual(studentDto.Pesel, resultOfMapping.Pesel);
            //Assert.AreEqual(studentDto.DateOfBirth, resultOfMapping.DateOfBirth);
            //Assert.AreEqual(studentDto.Sex, resultOfMapping.Sex);

        }

        //TEST KURSU
        [TestMethod]
        public void CourseMapping_ProvideValidCourse_ReceiveProperlyMappedCourseDto()
        {
            //PRZYPADEK 1
            /*Co ma być na wejsciu*/

            Student student1 = new Student();
            student1.Id = 1;
            student1.Name = "Kuba";
            student1.Surname = "Gerlee";
            student1.Pesel = 94;
            student1.DateOfBirth = new DateTime(09 / 03 / 1994);
            student1.Sex = 1;
            Student student2 = new Student();
            student2.Id = 2;
            student2.Name = "Ela";
            student2.Surname = "Durek";
            student2.Pesel = 92;
            student2.DateOfBirth = new DateTime(17 / 01 / 1992);
            student2.Sex = 2;

            List<Student> studentList = new List<Student>();
            studentList.Add(student1);
            studentList.Add(student2);

            Course course = new Course();
            course.Id = 1;
            course.CourseTitle = "Matematyka";
            course.DateStart = new DateTime(2017 / 10 / 10);
            course.HomeworkThreshold = 70;
            course.PresenceThreshold = 70;
            course.Teacher = "Kasia Gerlee";
            course.StudentList = studentList;


            /*Co daje na wyjscie*/
            StudentDto studentDto1 = new StudentDto();
            studentDto1.Id = 1;
            studentDto1.Name = "Kuba";
            studentDto1.Surname = "Gerlee";
            studentDto1.Pesel = 94;
            studentDto1.DateOfBirth = new DateTime(09 / 03 / 1994);
            studentDto1.Sex = 1;
            StudentDto studentDto2 = new StudentDto();
            studentDto2.Id = 2;
            studentDto2.Name = "Ela";
            studentDto2.Surname = "Durek";
            studentDto2.Pesel = 92;
            studentDto2.DateOfBirth = new DateTime(17 / 01 / 1992);
            studentDto2.Sex = 2;

            List<StudentDto> studentDtoList = new List<StudentDto>();
            studentDtoList.Add(studentDto1);
            studentDtoList.Add(studentDto2);

            CourseDto courseDto = new CourseDto();
            courseDto.Id = 1;
            courseDto.CourseTitle = "Matematyka";
            courseDto.DateStart = new DateTime(2017 / 10 / 10);
            courseDto.PresenceThreshold = 70;
            courseDto.HomeworkThreshold = 70;
            courseDto.Teacher = "Kasia Gerlee";
            courseDto.StudentDtosList = studentDtoList;

            //PRZYPADEK2
            CourseDto courseDto1 = new CourseDto();
            courseDto1 = null;
            Course course1 = new Course();
            course1 = null;

            EntityToDtoMapper entityToDtoMapper = new EntityToDtoMapper();

            var resultOfMapping = entityToDtoMapper.CourseModelToDto(course);
            var resultOfMapping1 = entityToDtoMapper.CourseModelToDto(course1);
            Assert.AreEqual(courseDto1, resultOfMapping1);
            Assert.AreEqual(courseDto.Id, resultOfMapping.Id);
            Assert.AreEqual(courseDto.CourseTitle, resultOfMapping.CourseTitle);
            Assert.AreEqual(courseDto.DateStart, resultOfMapping.DateStart);
            Assert.AreEqual(courseDto.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(courseDto.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(courseDto.Teacher, resultOfMapping.Teacher);
            CollectionAssert.Equals(courseDto.StudentDtosList, resultOfMapping.StudentDtosList);




        }

        //TEST LISTA STUDENT
        [TestMethod]
        public void StudentListMapping_ProvideValidStudent_ReceiveProperlyMappedStudentDtoList()
        {
            Student student1 = new Student();
            student1.Id = 1;
            student1.Name = "Kuba";
            student1.Surname = "Gerlee";
            student1.Pesel = 94;
            student1.DateOfBirth = new DateTime(09 / 03 / 1994);
            student1.Sex = 1;
            Student student2 = new Student();
            student2.Id = 2;
            student2.Name = "Ela";
            student2.Surname = "Durek";
            student2.Pesel = 92;
            student2.DateOfBirth = new DateTime(17 / 01 / 1992);
            student2.Sex = 2;

            List<Student> studentList = new List<Student>();
            studentList.Add(student1);
            studentList.Add(student2);


            /*Co daje na wejscie*/
            StudentDto studentDto1 = new StudentDto();
            studentDto1.Id = 1;
            studentDto1.Name = "Kuba";
            studentDto1.Surname = "Gerlee";
            studentDto1.Pesel = 94;
            studentDto1.DateOfBirth = new DateTime(09 / 03 / 1994);
            studentDto1.Sex = 1;
            StudentDto studentDto2 = new StudentDto();
            studentDto2.Id = 2;
            studentDto2.Name = "Ela";
            studentDto2.Surname = "Durek";
            studentDto2.Pesel = 92;
            studentDto2.DateOfBirth = new DateTime(17 / 01 / 1992);
            studentDto2.Sex = 2;

            List<StudentDto> studentDtoList = new List<StudentDto>();
            studentDtoList.Add(studentDto1);
            studentDtoList.Add(studentDto2);

            var resultOfMapping =
                Register.Business.Layer.Mappers.EntityToDtoMapper.StudentListToStudentDtoList(studentList);
            CollectionAssert.Equals(studentDtoList, resultOfMapping);
        }


        //TEST RAPORT
        [TestMethod]
        public void CourseDayMapping_ProvideValidCourseDay_ReceiveProperlyMappedCourseDayDto()
        {

            //PRZYPADEK 1
            CourseDayDto courseDayDto = new CourseDayDto();
            courseDayDto.Present = 1;
            courseDayDto.Absent = 1;
            courseDayDto.Allpresence = 2;
            courseDayDto.Student = null;
            courseDayDto.Course = null;



            CourseDay courseDay = new CourseDay();
            courseDay.Present = 1;
            courseDay.Absent = 1;
            courseDay.Allpresence = 2;
            courseDay.Student = null;
            courseDay.Course = null;



            //PRZYPADEK 2
            CourseDayDto courseDayDto2 = new CourseDayDto();
            courseDayDto2.Present = 1;
            courseDayDto2.Absent = 1;
            courseDayDto2.Allpresence = 2;

            StudentDto studentDto2 = new StudentDto();
            studentDto2.Id = 1;
            studentDto2.Name = "Kuba";
            studentDto2.Surname = "Gerlee";
            studentDto2.Pesel = 94;
            studentDto2.DateOfBirth = new DateTime(09 / 03 / 1994);
            studentDto2.Sex = 1;

            courseDayDto2.Student = studentDto2;

            CourseDto courseDto = new CourseDto();
            courseDto.Id = 1;
            courseDto.CourseTitle = "Matematyka";
            courseDto.DateStart = new DateTime(2017 / 10 / 10);
            courseDto.PresenceThreshold = 70;
            courseDto.HomeworkThreshold = 70;
            courseDto.Teacher = "Kasia Gerlee";

            courseDayDto2.Course = courseDto;



            CourseDay courseDay2 = new CourseDay();
            courseDay2.Present = 1;
            courseDay2.Absent = 1;
            courseDay2.Allpresence = 2;

            Student student = new Student();
            student.Id = 1;
            student.Name = "Kuba";
            student.Surname = "Gerlee";
            student.Pesel = 94;
            student.DateOfBirth = new DateTime(09 / 03 / 1994);
            student.Sex = 1;

            courseDay2.Student = student;

            Course course = new Course();
            course.Id = 1;
            course.CourseTitle = "Matematyka";
            course.DateStart = new DateTime(2017 / 10 / 10);
            course.HomeworkThreshold = 70;
            course.PresenceThreshold = 70;
            course.Teacher = "Kasia Gerlee";

            courseDay2.Course = course;

            //Przypadek 3
            CourseDay courseDay3 = new CourseDay();
            courseDay3 = null;
            CourseDayDto courseDayDto3 = new CourseDayDto();
            courseDayDto3 = null;

            var entityToDtoMapper = new EntityToDtoMapper();
            var resultOfMapping = entityToDtoMapper.CourseDayModelToDto(courseDay);
            var resultOfMapping2 = entityToDtoMapper.CourseDayModelToDto(courseDay2);
            var resultOfMapping3 = entityToDtoMapper.CourseDayModelToDto(courseDay3);


            Equals(courseDayDto, resultOfMapping);
            Equals(courseDayDto2, resultOfMapping2);
            Assert.AreEqual(courseDayDto3, resultOfMapping3);
        }
    }




}
