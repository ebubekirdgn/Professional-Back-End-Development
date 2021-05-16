using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.Concrete;
using MemberRegistration.Business.KpsServiceReference;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;

namespace MemberRegistration.Business.DependecyResolver.Ninject
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IMemberService>().To<MemberManager>().InSingletonScope();
            Bind<IMemberDal>().To<EfMemberDal>().InSingletonScope();

            Bind<IKpsService>().To<KpsServiceAdapter>().InSingletonScope();
        }
    }
}