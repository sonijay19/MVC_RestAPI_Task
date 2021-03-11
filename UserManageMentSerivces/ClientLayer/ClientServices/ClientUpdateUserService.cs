using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.Entites.Validation;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.ClientLayer.Validation;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.ClientServices
{
    public class ClientUpdateUserService : IClientUserUpdateServices
    {
        private static IUserUpdateInformationServices userUpdateService;
        public ClientUpdateUserService(IUserUpdateInformationServices updateInformationServices)
        {
            userUpdateService = updateInformationServices;
        }

        async public Task<UserUpdateResponseMessage> UpdateUserDetailsAsync(UserUpdateRequestMessage userDetails)
        {
            UserUpdateResponseMessage responseUser = new UserUpdateResponseMessage();
            try
            {
                UserInformationValidation validator = new UserInformationValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    /*var UserInfo = await ServiceManager.GetInstance().UserDetailsUpdate()
                        .BusinessUpdateUserInformation(userDetails);*/
                    var UserInfo = await userUpdateService.BusinessUpdateUserInformation(userDetails);
                    if (UserInfo)
                    {
                        responseUser.Success = UserInfo;
                        return responseUser;
                    }
                    throw new UpdateUserDetailsExceptions(ErrorCodes.USER_NOT_FOUND);
                }
                throw new UpdateUserDetailsExceptions(ErrorCodes.ERROR_FROM_VALIDATE);
            }
            catch (UpdateUserDetailsExceptions e)
            {
                responseUser.ErrorCode = e._errorConstants.ToString();
                return responseUser;
            }
        }
    }
}
