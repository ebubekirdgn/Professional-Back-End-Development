using DevFramework.Core.DataAccess;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using System.Collections.Generic;

namespace DevFramework.Nortwind.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UserRoleItem> GetUserRoles(User user);
    }
}