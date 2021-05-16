using DevFramework.Core.Aspects.PostSharp.ValidationAspects;
using MemberRegistration.Business.Abstract;
using MemberRegistration.Business.ServiceAdapters;
using MemberRegistration.Business.ValidationRules.FluentValidation;
using MemberRegistration.DataAccess.Abstract;
using MemberRegistration.Entities.Concrete;
using System;

namespace MemberRegistration.Business.Concrete
{
    public class MemberManager : IMemberService
    {
        private IMemberDal _memberDal;
        private IKpsService _kpsService;

        //Dependect Injection yaptık.
        public MemberManager(IMemberDal memberDal, IKpsService kpsService)
        {
            _memberDal = memberDal;
            _kpsService = kpsService;
        }

        [FluentValidationAspect(typeof(MemberValidator))]
        public void Add(Member member)
        {
            if (_memberDal.Get(m => m.TcIdentityNo == member.TcIdentityNo) != null)
            {
                throw new Exception("Bu kullanıcı daha önce kayıt olmuştur.");
            }

            if (_kpsService.ValidateUser(member) == false)
            {
                throw new Exception("Kullanıcı doğrulaması geçerli değil.");
            }
            _memberDal.Add(member);
        }
    }
}