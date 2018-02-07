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
using System.Web;

namespace TweetsStructure.Common.Nhibernate.Classes
{
    public class SessionBuilder<T> : ISessionBuilder where T : IMappingProvider
    {
        private static ISession _currentSession;
        private static ISessionFactory _sessionFactory;
        private IConfiguration _configuration;

        public SessionBuilder(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private ISessionFactory getSessionFactory()
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = SessionFactory;
            }

            return _sessionFactory;
        }

        public ISessionFactory SessionFactory
        {
            get
            {
                ISessionFactory isessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(_configuration.ConnectionString))
                .Mappings(m => m
                .FluentMappings.AddFromAssemblyOf<T>())
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, false))
                .BuildSessionFactory();
                return isessionFactory;
            }
        }

        private ISession getExistingOrNewSession(ISessionFactory factory)
        {
            if (HttpContext.Current != null)
            {
                ISession session = GetExistingWebSession();
                if (session == null)
                {
                    session = openSessionAndAddToContext(factory);
                }
                else if (!session.IsOpen)
                {
                    session = openSessionAndAddToContext(factory);
                }

                return session;
            }

            if (_currentSession == null)
            {
                _currentSession = factory.OpenSession();
            }
            else if (!_currentSession.IsOpen)
            {
                _currentSession = factory.OpenSession();
            }

            return _currentSession;
        }
        public ISession GetExistingWebSession()
        {
            return HttpContext.Current.Items[this.GetType().FullName] as ISession;
        }
        private ISession openSessionAndAddToContext(ISessionFactory factory)
        {
            ISession session = factory.OpenSession();
            HttpContext.Current.Items.Remove(this.GetType().FullName);
            HttpContext.Current.Items.Add(this.GetType().FullName, session);
            return session;
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
            ISessionFactory factory = getSessionFactory();
            ISession session = factory.OpenSession();
            //ISession session = getExistingOrNewSession(factory);
            return session;
        }

    }
}
