using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsStructure.Common.Nhibernate.Interfaces
{
    public interface ISessionBuilder
    {
        ISession OpenSession();
        void CreateSession();
        void CloseSession();
        ISession GetCurrentSession();
    }
}
