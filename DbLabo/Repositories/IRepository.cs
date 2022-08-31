using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbLabo.Repositories
{
    internal interface IRepository<TEntity>
    {

        public TEntity Create(TEntity entity);
        public TEntity Update(TEntity entity);
        public TEntity GetOne(string str);
        public IEnumerable<TEntity> GetAll();
        public TEntity Delete(string str);
    }
}
