using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
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
        private static ClientUpdateUserService _instance;
        public static ClientUpdateUserService Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new ClientUpdateUserService();
                }
                return _instance;
            }
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
                    var UserInfo = await ServiceManager.GetInstance().UserDetailsUpdate()
                        .BusinessUpdateUserInformation(userDetails);
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
