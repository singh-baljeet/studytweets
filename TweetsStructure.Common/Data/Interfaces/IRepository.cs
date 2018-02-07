using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TweetsStructure.Common.Data.Base;

namespace TweetsStructure.Common.Data.Interfaces
{
    public interface IRepository<T> where T : BaseModel
    {
        T Create(T entity);
        IList<T> Find(Expression<Func<T, bool>> condition, bool includeDeleted = false);
        T FindOne(Expression<Func<T, bool>> condition, bool includeDeleted = false);
        T Update(T entity);

    }
}
