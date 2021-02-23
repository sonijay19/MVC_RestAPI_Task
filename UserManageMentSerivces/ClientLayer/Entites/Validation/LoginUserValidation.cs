using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.Validation
{
    public class LoginUserValidation : AbstractValidator<UserLoginRequestMessages>
    {
        public LoginUserValidation()
        {
            RuleFor(user => user.UserEmail).NotEmpty().NotNull()
                .Matches(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")
                .OnAnyFailure(x => {
                    throw new UserLoginException(ErrorCodes.INVALID_USER_EMAILID);
                });
        }
    }
}
