using DevFramework.Core.Entities;
using System.Linq;

namespace DevFramework.Core.DataAccess.NHibernate
{
    internal class NhQueryableRepository<T> : IQueryableRepository<T> where T : class, IEntity, new()
    {
        private NHibernateHelper _nhibernateHelper;
        private IQueryable<T> _entities;

        public NhQueryableRepository(NHibernateHelper nhibernateHelper)
        {
            _nhibernateHelper = nhibernateHelper;
        }

        public IQueryable<T> Table
        {
            get { return this.Entities; }
        }

        public virtual IQueryable<T> Entities
        {
            get
            {
                if (_entities == null)
                {
                    _entities = _nhibernateHelper.OpenSession().Query<T>();
                }
                return _entities;
            }
        }
    }
}