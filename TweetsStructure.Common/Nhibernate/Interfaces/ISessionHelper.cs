using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsStructure.Common.Nhibernate.Interfaces
{
    public interface ISessionHelper
    {
        ISession Current { get; }
        void CreateSession();
        void ClearSession();
        void OpenSession();
        void CloseSession();

    }
}
