
using System;
using System.Collections.Generic;
using System.Linq;
using Register.Data.Layer.DbContexts;
using Register.Data.Layer.Models;
using Register.Data.Layer.UoW;

namespace Register.Data.Layer.RepositoriesServices
{
    public class StudentRepoService : IStudentRepoService
    {
        public Student GetStudentByPesel(long pesel)
        {
            Student studentfromDL = null;
            var unitOfWork = new RegisterArchLayerUoW();
            var studentRepository = unitOfWork.GetRepository<Student>();
            return studentRepository.GetAll().FirstOrDefault(x => x.Pesel == pesel);

        }

        public bool ChangeStudentPersonalData(Student student)
        {
            int rowsAffected = 0;
            List<Student> studentList = null;
            var unitOfWork = new RegisterArchLayerUoW();
            var studentRepository = unitOfWork.GetRepository<Student>();


            studentList = studentRepository.GetAll().Where(a => a.Pesel == student.Pesel).ToList();

            foreach (var students in studentList)
            {
                if (!String.IsNullOrEmpty(student.Name))
                {
                    students.Name = student.Name;
                }
                if (!String.IsNullOrEmpty(student.Surname))
                {
                    students.Surname = student.Surname;
                }

                students.DateOfBirth = student.DateOfBirth;

            }
            unitOfWork.SaveChanges();

            return (rowsAffected == 1);

        }

        public bool CheckIfStudentExists(long pesel)
        {
            var unitOfWork = new RegisterArchLayerUoW();
            var studentRepository = unitOfWork.GetRepository<Student>();

            var checkPeselExists = studentRepository.GetAll().FirstOrDefault(x => x.Pesel == pesel);
                unitOfWork.SaveChanges();
                if (checkPeselExists == null)
                    return false;//pesel nie istnieje w bazie
                return true;//pesel istnieje w bazie

            

        }



    }
}
