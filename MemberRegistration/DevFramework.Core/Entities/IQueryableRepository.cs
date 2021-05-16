using DevFramework.Core.Entities;
using System.Linq;

namespace DevFramework.Core.DataAccess
{
    public interface IQueryableRepository<T> where T : IEntity, new()
    {
        IQueryable<T> Table { get; }
    }
}