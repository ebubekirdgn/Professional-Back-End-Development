using MemberRegistration.Business.DependecyResolver.Ninject;
using Ninject;

namespace MemberRegistration.Business.DependecyResolver
{
    public class InstanceFactory
    {
        public static T GetInstance<T>()
        {
            var kernel = new StandardKernel(new BusinessModule());
            return kernel.Get<T>();
        }
    }
}