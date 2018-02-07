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
using NHibernate.Tool.hbm2ddl;

namespace TweetsStructure.Common.Nhibernate.Classes
{
    public class SessionBuilder<T> : ISessionBuilder where T : IMappingProvider
    {

        private static ISessionFactory _sessionFactory = null;
        private IConfiguration _configuration;

        public SessionBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                  _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(_configuration.ConnectionString))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<T>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .BuildSessionFactory();
                }
                return _sessionFactory; 
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }

        public void CreateSession()
        {
            CurrentSessionContext.Bind(OpenSession());
        }

        public void CloseSession()
        {
            if (CurrentSessionContext.HasBind(SessionFactory))
            {
                CurrentSessionContext.Unbind(SessionFactory).Dispose();
            }
        }

        public ISession GetCurrentSession()
        {
            return OpenSession();
        }

    }
}
