using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.ClientServices
{
    public class DeleteUserInformation : IDeleteUserInformation
    {
        private static IUserDetailsRemoveService removeUser;
        public DeleteUserInformation(IUserDetailsRemoveService removeUserDetails)
        {
            removeUser = removeUserDetails;
        }

        public async Task<UserUpdateResponseMessage> DeleteUserDetailsAsync(string UserId)
        {
            UserUpdateResponseMessage responseUser = new UserUpdateResponseMessage();
            try
            {
                    var UserInfo = await removeUser.DeleteUserInformation(UserId);
                    if (UserInfo)
                    {
                        responseUser.Success = UserInfo;
                        return responseUser;
                    }
                    throw new UpdateUserDetailsExceptions(ErrorCodes.USER_NOT_FOUND);
            }
            catch (UpdateUserDetailsExceptions e)
            {
                responseUser.ErrorCode = e._errorConstants.ToString();
                return responseUser;
            }
        }
    }
}
