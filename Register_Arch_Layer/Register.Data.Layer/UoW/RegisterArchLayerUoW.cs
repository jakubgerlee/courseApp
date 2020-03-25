using System;
using System.Collections.Generic;
using Register.Data.Layer.DbContexts;
using Register.Data.Layer.Interfaces;
using Register.Data.Layer.Models;

namespace Register.Data.Layer.UoW
{
    public class RegisterArchLayerUoW
    {
        private RegisterDbContext _dbContext;
        private Dictionary<Type, object> _repositories;
        private static RegisterArchLayerUoW _instance;

        public static RegisterArchLayerUoW GetInstance()
        {
            if (_instance == null)
            {
                _instance = new RegisterArchLayerUoW();
            }
            return _instance;

        }

        public RegisterArchLayerUoW()
        {
            _dbContext = new RegisterDbContext();

            RegisterRepository();
        }

        private void Register(Type type, object repository)
        {
            if (_repositories.ContainsKey(type))
            {
                throw new Exception("Istnieje repozytorium " + type.Name + "zostalo wlasnie zdefiniowane");
            }
            _repositories.Add(type, repository);

        }

        private void RegisterRepository()
        {
            _repositories = new Dictionary<Type, object>();
            Register(typeof(Course), new GenericRepository<Course>(_dbContext));
            Register(typeof(CourseDay), new GenericRepository<CourseDay>(_dbContext));
            Register(typeof(Homework), new GenericRepository<Homework>(_dbContext));
            Register(typeof(Student), new GenericRepository<Student>(_dbContext));

        }

        public GenericRepository<T> GetRepository<T>() where T : class, IEntity
        {
            return _repositories[typeof(T)] as GenericRepository<T>;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }


        public int Id { get; }
    }
}
