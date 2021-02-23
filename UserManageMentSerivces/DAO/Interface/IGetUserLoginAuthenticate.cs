using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO;

namespace UserManageMentSerivces.DAO.Interface
{
    public interface IGetUserLoginAuthenticate
    {
        Task<UserInformation> GetUserAuthenticate(UserLoginRequestDTO UserEmail);

        Task<List<UserInformation>> GetAllUserInformations(UserLoginRequestDTO UserEmail);
    }
}
