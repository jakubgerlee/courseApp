using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Register.Business.Layer.Dto;
using Register.Data.Layer.Models;

namespace Register.Business.Layer.Test
{
    [TestClass]
    public class DtoToEntityMapperTests
    {
        //TEST STUDENTA
        [TestMethod] //mapowanie studenta
        public void StudentDtoMapping_ProvideValidStudentDto_ReciveProperlyMappedStudent()
        {
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


            var resultOfMapping = Register.Business.Layer.Mappers.EntityToDtoMapper.StudentEntityModelToDto(student);
            Assert.AreEqual(studentDto.Id, resultOfMapping.Id);
            Assert.AreEqual(studentDto.Name, resultOfMapping.Name);
            Assert.AreEqual(studentDto.Surname, resultOfMapping.Surname);
            Assert.AreEqual(studentDto.Pesel, resultOfMapping.Pesel);
            Assert.AreEqual(studentDto.DateOfBirth, resultOfMapping.DateOfBirth);
            Assert.AreEqual(studentDto.Sex, resultOfMapping.Sex);




        }

        //TEST KURSU
        [TestMethod] //mapowanie kursu
        public void CourseDtoMapping_ProvideValidCourseDto_RecieveProperlyMappedCourse()
        {

            /*Co ma być na wyjściu*/

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

            CourseDto courseDto = new CourseDto();
            courseDto.Id = 1;
            courseDto.CourseTitle = "Matematyka";
            courseDto.DateStart = new DateTime(2017 / 10 / 10);
            courseDto.PresenceThreshold = 70;
            courseDto.HomeworkThreshold = 70;
            courseDto.Teacher = "Kasia Gerlee";
            courseDto.StudentDtosList = studentDtoList;



            var resultOfMapping = Register.Business.Layer.Mappers.DtoToEntityMapper.CourseDtoToModelToEntity(courseDto);
            Assert.AreEqual(course.Id, resultOfMapping.Id);
            Assert.AreEqual(course.CourseTitle, resultOfMapping.CourseTitle);
            Assert.AreEqual(course.DateStart, resultOfMapping.DateStart);
            Assert.AreEqual(course.HomeworkThreshold, resultOfMapping.HomeworkThreshold);
            Assert.AreEqual(course.PresenceThreshold, resultOfMapping.PresenceThreshold);
            Assert.AreEqual(course.Teacher, resultOfMapping.Teacher);
            CollectionAssert.Equals(course.StudentList, resultOfMapping.StudentList);




        }

        //TEST STUDENTA
        [TestMethod] //mapowanie listy studentow
        public void StudentDtoListMapping_ProvideValidStudentDtoList_RecieveProperlyMappedStudentList()
        {

            /*Co ma być na wyjściu*/
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
                Register.Business.Layer.Mappers.DtoToEntityMapper.StudentDtoListToStudentList(studentDtoList);
            CollectionAssert.Equals(studentList, resultOfMapping);
        }

        //TEST RAPORT
        [TestMethod] //testowanie dnia obecnosci
        public void CourseDayDtoMapping_ProvideValidCourseDayDto_ReciveProperlyMappedCourseDay()
        {
            CourseDayDto courseDayDto = new CourseDayDto();
            courseDayDto.Present = 1;
            courseDayDto.Absent = 1;
            courseDayDto.Allpresence = 2;
            

            StudentDto studentDto = new StudentDto();
            studentDto.Id = 1;
            studentDto.Name = "Kuba";
            studentDto.Surname = "Gerlee";
            studentDto.Pesel = 94;
            studentDto.DateOfBirth = new DateTime(09 / 03 / 1994);
            studentDto.Sex = 1;

            courseDayDto.Student = studentDto;

            CourseDto courseDto = new CourseDto();
            courseDto.Id = 1;
            courseDto.CourseTitle = "Matematyka";
            courseDto.DateStart = new DateTime(2017 / 10 / 10);
            courseDto.PresenceThreshold = 70;
            courseDto.HomeworkThreshold = 70;
            courseDto.Teacher = "Kasia Gerlee";

            courseDayDto.Course = courseDto;

            CourseDay courseDay = new CourseDay();
            courseDay.Present = 1;
            courseDay.Absent = 1;
            courseDay.Allpresence = 2;
            

            Student student = new Student();
            student.Id = 1;
            student.Name = "Kuba";
            student.Surname = "Gerlee";
            student.Pesel = 94;
            student.DateOfBirth = new DateTime(09 / 03 / 1994);
            student.Sex = 1;

            courseDay.Student = student;

            Course course = new Course();
            course.Id = 1;
            course.CourseTitle = "Matematyka";
            course.DateStart = new DateTime(2017 / 10 / 10);
            course.HomeworkThreshold = 70;
            course.PresenceThreshold = 70;
            course.Teacher = "Kasia Gerlee";

            courseDay.Course = course;

            var resultOfMapping = Register.Business.Layer.Mappers.DtoToEntityMapper.CourseDayDtoToModelEntity(courseDayDto);

            Assert.AreEqual(courseDay.Present, resultOfMapping.Present);
            Assert.AreEqual(courseDay.Absent, resultOfMapping.Absent);
            Assert.AreEqual(courseDay.Allpresence, resultOfMapping.Allpresence);
            Assert.AreEqual(courseDay.Id, resultOfMapping.Id);



            Equals(courseDay, resultOfMapping);

        }

        //TEST RAPORT
        [TestMethod] //testowanie mapowania peselu
        public void PeselDtoMapping_ProvideValidPeselDto_ReciveProperlyMappedPesel()
        {
            var studentDto = new StudentDto();
            studentDto.Pesel = 1;

            var student = new Student();
            student.Pesel = 1;

            var resultOfMapping = Register.Business.Layer.Mappers.DtoToEntityMapper.PeselDtoToEntityModel(studentDto.Pesel);
            Assert.AreEqual(student.Pesel, resultOfMapping);

        }
    
   
    }
}
