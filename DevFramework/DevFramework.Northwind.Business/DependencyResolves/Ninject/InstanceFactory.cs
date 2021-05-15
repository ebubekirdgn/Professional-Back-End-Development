using DevFramework.Nortwind.Business.DependencyResolvers.Ninject;
using Ninject;

namespace DevFramework.Northwind.Business.DependencyResolves.Ninject
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