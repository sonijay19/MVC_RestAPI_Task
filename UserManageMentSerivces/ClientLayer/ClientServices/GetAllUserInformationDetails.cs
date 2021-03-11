using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.ClientLayer.Validation;
using UserManageMentSerivces.Exceptions;

namespace UserManageMentSerivces.ClientLayer.ClientServices
{
    public class GetAllUserInformationDetails : IGetAllUserData
    {
        private IGetUserDetailsServices  getUserDetails;
        public GetAllUserInformationDetails(IGetUserDetailsServices userDetails)
        {
            getUserDetails = userDetails;
        }
        public async Task<GetUserDetailsResponseMessage> GetUserInformationAsync(UserLoginRequestMessages userDetails)
        {
            GetUserDetailsResponseMessage responseUser = new GetUserDetailsResponseMessage();
            try
            {
                LoginUserValidation validator = new LoginUserValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    //var instance = new BuisnessConfig();
                    //BuisnessConfig.container.Register<IGetUserDetailsServices, GetUserDetails>();
                    //var obj = instance.container.GetInstance<IGetUserDetailsServices>();
                    var UserInfo = await getUserDetails.GetUserInformation(userDetails);
                    /*var UserInfo = await ServiceManager.GetInstance().GetAllUserDetails()
                        .GetUserInformation(userDetails);*/
                    if (UserInfo[0].UserEmail is null)
                    {
                        throw new UserLoginException(ErrorCodes.USER_NOT_FOUND);
                    }
                    responseUser.Total_Count = UserInfo.Count;
                    responseUser.UserDetails = UserInfo;
                    return responseUser;
                }
                throw new UserLoginException(ErrorCodes.ERROR_FROM_VALIDATE);
            }
            catch (UserLoginException e)
            {
                responseUser.ErrorCodes = e._errorConstants.ToString();
                return responseUser;
            }
        }
    }
}
