using DevFramework.Core.DataAccess.EntityFramework;
using DevFramework.Northwind.DataAccess.Concrete.EntityFramework;
using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Nortwind.DataAccess.Abstract;
using System.Collections.Generic;

namespace DevFramework.Nortwind.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, NorthwindContext>, IUserDal
    {
        /*

        public List<UserRole> GetUserRoles(User user)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = context.Users;
            }
        }*/
        public List<UserRole> GetUserRoles(User user)
        {
            throw new System.NotImplementedException();
        }
    }
}