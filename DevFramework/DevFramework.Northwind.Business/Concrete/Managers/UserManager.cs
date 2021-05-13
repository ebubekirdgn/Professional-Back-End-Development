using DevFramework.Northwind.Entities.ComplexTypes;
using DevFramework.Northwind.Entities.Concrete;
using DevFramework.Nortwind.Business.Abstract;
using DevFramework.Nortwind.DataAccess.Abstract;
using System.Collections.Generic;

namespace DevFramework.Northwind.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }


        public User GetByUserNameAndPassword(string userName, string password)
        {
            return _userDal.Get(u => u.UserName == userName & u.Password == password);
        }

        public List<UserRoleItem> GetUserRoles(User user)
        {
            return _userDal.GetUserRoles(user);
        }
    }
}
