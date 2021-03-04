using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.Entites.Validation
{
    public class UserInformationValidation : AbstractValidator<UserUpdateRequestMessage>
    {
        public UserInformationValidation()
        {//^[A-Za-z0-9 ]+$

            RuleFor(user => user.UserEmail).NotEmpty().NotNull()
                .Matches(@"^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$")
                .OnAnyFailure(x => {
                    throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_EMAILID);
                });

            RuleFor(person => person.FirstName).NotNull().NotEmpty()
                .Matches(@"^[A-Za-z0-9]+$")
                .OnAnyFailure(parameter =>{
                    throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                }); 

            RuleFor(person => person.LastName).NotNull().NotEmpty()
                .Matches(@"^[A-Za-z0-9]+$")
                .OnAnyFailure(parameter => {
                    throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                });

            RuleFor(person => person.UserStatus).NotNull().NotEmpty()
                .Custom((parameter, context) =>
                {
                    if (parameter != UserAccessType.FullAccess.ToString()
                        && parameter != UserAccessType.StandardAccess.ToString()
                        && parameter != UserAccessType.ViewOnlyAccess.ToString())
                    {
                        throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_ACCESSTYPE);
                    }
                });
            RuleFor(person => person.PhoneNumber).NotNull().NotEmpty()
                .Matches("^\\d{10}$")
                .OnAnyFailure(parameter => {
                    throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_FIRSTORLASTNAME);
                });
                /*.Custom((parameter, context) =>
                {
                    if (parameter != UserAccessType.FullAccess.ToString()
                        && parameter != UserAccessType.StandardAccess.ToString()
                        && parameter != UserAccessType.ViewOnlyAccess.ToString())
                    {
                        throw new UpdateUserDetailsExceptions(ErrorCodes.INVALID_USER_ACCESSTYPE);
                    }
                });*/
        }
    }
}
