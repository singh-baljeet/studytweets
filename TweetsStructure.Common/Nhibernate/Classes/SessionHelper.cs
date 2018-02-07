using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using TweetsStructure.Common.Nhibernate.Interfaces;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using TweetsStructure.Common.Configuration.Interfaces;
using FluentNHibernate;
using NHibernate.Context;
using TweetsStructure.Common.Nhibernate.Classes;

namespace TweetsStructure.Common.Nhibernate.Classes
{
    public class SessionHelper<T> : ISessionHelper where T : IMappingProvider
    {
        private ISessionBuilder _sessionBuilder = null;

        public SessionHelper(ISessionBuilder sessionBuilder)
        {
            _sessionBuilder = sessionBuilder;
        }

        public ISession Current => _sessionBuilder.GetCurrentSession();
        
        public void ClearSession()
        {
            Current.Clear();
        }

        public void CloseSession()
        {
            _sessionBuilder.CloseSession();
        }

        public void CreateSession()
        {
            _sessionBuilder.CreateSession();
        }

        public void OpenSession()
        {
            _sessionBuilder.OpenSession();
        }
    }
}
