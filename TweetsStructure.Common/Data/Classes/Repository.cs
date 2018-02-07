using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using TweetsStructure.Common.Data.Base;
using TweetsStructure.Common.Data.Interfaces;
using TweetsStructure.Common.Nhibernate.Interfaces;

namespace TweetsStructure.Common.Data.Classes
{
    public class Repository<T> : IRepository<T> where T : BaseModel
    {
        private readonly ISessionHelper _session;

        public Repository(ISessionHelper sessionHelper)
        {
            _session = sessionHelper;
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T Create(T entity)
        {
            entity.CreatedOn = DateTime.UtcNow;
            entity.UpdatedOn = DateTime.UtcNow;
            return _session.Current.Save(entity) as T;
        }


        public T Update(T entity)
        {
            using (TransactionScope _transactionScope = new TransactionScope())
            {
                entity.UpdatedOn = DateTime.UtcNow;
                _session.Current.Update(entity);
                _transactionScope.Complete();
            }
            return entity;
        }

        public void Execute(Action<ISession> action)
        {
            action(_session.Current);
        }


        public IList<T> Find(Expression<Func<T, bool>> condition, bool includeDeleted = false)
        {
            var query =  _session.Current.QueryOver<T>();
            query = query.Where(x => x.Deleted == 0);
            return query.List<T>();

        }

        public T FindOne(Expression<Func<T, bool>> condition, bool includeDeleted = false)
        {
            var query = _session.Current.QueryOver<T>();
            query = query.Where(x => x.Deleted == 0);
            return query.List<T>().FirstOrDefault();

        }
    }
}
