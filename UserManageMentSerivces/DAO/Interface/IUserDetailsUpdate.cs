using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer.Entities.DTO.ReuestMessages;

namespace UserManageMentSerivces.DAO.Interface
{
    public interface IUserDetailsUpdate
    {
        Task<bool> UpdateUserDetailAsync(BusinessUpdateUserRequestMessage user);
    }
}
