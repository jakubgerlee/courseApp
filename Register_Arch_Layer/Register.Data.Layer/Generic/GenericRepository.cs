using System.Data.Entity;
using System.Linq;
using Register.Data.Layer.DbContexts;
using Register.Data.Layer.Interfaces;

namespace Register.Data.Layer
{
    public class GenericRepository<T> where T : class, IEntity
    {
        private RegisterDbContext _dbContext;

        private DbSet<T> DataSet
        {
            get { return _dbContext.Set<T>(); }
        }

        public GenericRepository(RegisterDbContext registerDbContext)
        {
            _dbContext = registerDbContext;
        }


        public bool Add(T entity)
        {
            DataSet.Add(entity);
            var rowsAffected = _dbContext.SaveChanges();
            return rowsAffected > 0;
        }

        public IQueryable<T> GetAll()
        {
            return DataSet;
        }



        public T Get(int id)
        {
            return GetAll().Single(x => x.Id == id);
        }

        public T Get(long id)
        {
            return GetAll().Single(x => x.Id == id);
        }

        public void Remove(int id)
        {
            DataSet.Remove(Get(id));
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (!DataSet.Local.Contains(entity))
            {
                DataSet.Attach(entity);
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
           _dbContext.SaveChanges();
        }


    }
}
