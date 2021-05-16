using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Entities.Concrete;
using System;

namespace MemberRegistration.Business.KpsServiceReference
{
    public class KpsServiceAdapter : IKpsService
    {
        public bool ValidateUser(Member member)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();
            return client.TCKimlikNoDogrula(Convert.ToInt64(member.TcIdentityNo), member.FirstName.ToUpper(), member.LastName.ToUpper(), member.DateOfBirth.Year);
        }
    }
}