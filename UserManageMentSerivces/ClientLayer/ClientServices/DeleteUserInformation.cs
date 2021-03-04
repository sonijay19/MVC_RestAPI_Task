using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.ClientServices
{
    public class DeleteUserInformation : IDeleteUserInformation
    {
        private static DeleteUserInformation _instance;
        public static DeleteUserInformation Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DeleteUserInformation();
                }
                return _instance;
            }
        }

        public async Task<UserUpdateResponseMessage> DeleteUserDetailsAsync(string UserId)
        {
            UserUpdateResponseMessage responseUser = new UserUpdateResponseMessage();
            try
            {
                    var UserInfo = await ServiceManager.GetInstance().DeleteUserDetails()
                        .DeleteUserInformation(UserId);
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
