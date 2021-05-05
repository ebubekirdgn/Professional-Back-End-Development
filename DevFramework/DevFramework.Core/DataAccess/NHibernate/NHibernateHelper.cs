using NHibernate;
using System;

namespace DevFramework.Core.DataAccess.NHibernate
{
    public abstract class NHibernateHelper : IDisposable
    {
        private static ISessionFactory _sessionFactor;

        public virtual ISessionFactory SessionFactory
        {
            get { return _sessionFactor ?? (_sessionFactor = InitializeFactory()); }
        }

        protected abstract ISessionFactory InitializeFactory();

        public virtual ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}