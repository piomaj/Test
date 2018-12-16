using ShopMVC.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _entities;

        public Repository(DbContext dbContext)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");

            _dbContext = dbContext;
            _entities = _dbContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {            
            return _entities.Find(id);
        }

        public List<TEntity> GetAll()
        {
            return _entities.ToList();            
        }
    }
}
