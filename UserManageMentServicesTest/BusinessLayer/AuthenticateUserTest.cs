using System;
using System.Collections.Generic;
using System.Text;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.ClientLayer.RequestMessages;
using UserManageMentSerivces.DAO;
using Xunit;
using Moq;
using UserManageMentSerivces.DAO.Interface;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;

namespace UserManageMentServicesTest.BusinessLayer
{
    public class AuthenticateUserTest
    {
        // interface mock
        /*private AuthenticateUser getUserDetails;
        public AuthenticateUserTest()
        {
            getUserDetails = new AuthenticateUser();
        }*/

        [Theory]
        [InlineData("soni1@gmail.com")]
        public async void USER_AUTHENTICATE_SUCCESSFULLY(string userEmail)
        {
            // Arrange
            var userDetails = new Mock<IGetUserLoginAuthenticate>();
            AuthenticateUser getUserDetails = new AuthenticateUser(userDetails.Object);
            UserLoginRequestMessages userInfo = new UserLoginRequestMessages();
            UserLoginRequestDTO userInformation = new UserLoginRequestDTO();
            userInfo.UserEmail = userEmail;
            userInformation.UserEmail = userEmail;
            var UserResponse = new UserInformation();
            UserResponse.FirstName = "CJay2";
            UserResponse.LastName = "BJay1";
            UserResponse.PhoneNumber = "2222222222";
            UserResponse.UserEmail = userEmail;
            UserResponse.UserStatus = "FullAccess";
            UserResponse.UserType = "Acitved";
            userDetails.Setup(user => user.GetUserAuthenticate(userInformation)).ReturnsAsync(UserResponse);

            // Act
            var actualUser = await getUserDetails.AuthenticateUserAsync(userInfo);

            // Assert
            Assert.Equal(UserResponse.UserEmail,actualUser.UserEmail);
            //Assert.Equal(UserResponse.FirstName, actualUser.FirstName);
            //Assert.Equal(UserResponse.LastName, actualUser.LastName);
            //Assert.Equal(UserResponse.PhoneNumber, actualUser.PhoneNumber);
            //Assert.Equal(UserResponse.UserStatus, actualUser.UserStatus);
            //Assert.Equal(UserResponse.UserType, actualUser.UserType);
        }
    }
}
