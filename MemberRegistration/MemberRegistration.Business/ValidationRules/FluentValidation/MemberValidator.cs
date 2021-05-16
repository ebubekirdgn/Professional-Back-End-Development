using FluentValidation;
using MemberRegistration.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemberRegistration.Business.ValidationRules.FluentValidation
{
    public class MemberValidator : AbstractValidator<Member>
    {
        public MemberValidator()
        {
            RuleFor(m=> m.FirstName).NotEmpty();
            RuleFor(m=> m.LastName).NotEmpty();
            RuleFor(m=> m.DateOfBirth).NotEmpty();
            RuleFor(m=> m.EmailAddress).NotEmpty();
            RuleFor(m=> m.TcIdentityNo).NotEmpty();
            RuleFor(m=> m.DateOfBirth).LessThan(DateTime.Now);
            RuleFor(m => m.EmailAddress).EmailAddress();
            RuleFor(m => m.TcIdentityNo).Length(11);

        }

    }
}
