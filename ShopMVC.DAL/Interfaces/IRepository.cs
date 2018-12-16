using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopMVC.DAL.Interfaces
{   
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity Get(int id);
    }
}
