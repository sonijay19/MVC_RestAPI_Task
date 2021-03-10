using System.Threading.Tasks;
using System.Web;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.ClientLayer.ResponseMessages;
using UserManageMentSerivces.ClientLayer.Validation;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.Exceptions;
using UserManageMentSerivces.BusinessLayer.Entities.Enums;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using LightInject;
using UserManageMentSerivces.DAO;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using LightInject;

namespace DemoService.ClientLayer
{
    public class RequestProcessor : IUserUpdateAuthenticate
    {
        //AuthenticateUser : IUserGetdetailsServices
        private IUserGetdetailsServices userDetailServices;
        public RequestProcessor(IUserGetdetailsServices userDetails)
        {
            userDetailServices = userDetails;
        }
        public async Task<UserLoginResponseMessages> AuthenticateUser(UserLoginRequestMessages userDetails)
        {
            UserLoginResponseMessages responseUser = new UserLoginResponseMessages();
            try
            {
                LoginUserValidation validator = new LoginUserValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {

                    /*var UserInfo = await ServiceManager.GetInstance().GetUserLoginAuthentication()
                        .AuthenticateUserAsync(userDetails);*/
                    var UserInfo = await userDetailServices.AuthenticateUserAsync(userDetails);
                    if(UserInfo.UserEmail is null)
                    {       
                        throw new UserLoginException(ErrorCodes.USER_NOT_FOUND);
                    }
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

        public async Task<GetUserDetailsResponseMessage> GetUserInformationAsync(UserLoginRequestMessages userDetails)
        {
            GetUserDetailsResponseMessage responseUser = new GetUserDetailsResponseMessage();
            try
            {
                LoginUserValidation validator = new LoginUserValidation();
                var result = validator.Validate(userDetails);
                if (result.IsValid)
                {
                    var instance = new BuisnessConfig();
                    //BuisnessConfig.container.Register<IGetUserDetailsServices, GetUserDetails>();
                    var obj = instance.container.GetInstance<IGetUserDetailsServices>();
                    var UserInfo = await obj.GetUserInformation(userDetails);
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