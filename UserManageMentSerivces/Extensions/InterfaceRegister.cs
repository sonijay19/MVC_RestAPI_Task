using DemoService.ClientLayer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManageMentSerivces.BusinessLayer;
using UserManageMentSerivces.BusinessLayer.BusinessServices;
using UserManageMentSerivces.BusinessLayer.Interfaces;
using UserManageMentSerivces.ClientLayer.ClientServices;
using UserManageMentSerivces.ClientLayer.Entites.Interfaces;
using UserManageMentSerivces.DAO;
using UserManageMentSerivces.DAO.DAOServices;
using UserManageMentSerivces.DAO.Interface;

namespace UserManageMentSerivces.Extensions
{
    public static class InterfaceRegister
    {
        public static void RegisterInterface(IServiceCollection services)
        {
            // UserLogin And UserDetails
            services.AddSingleton<IGetUserLoginAuthenticate, GetUserInformationDB>();
            services.AddSingleton<IUserUpdateAuthenticate, RequestProcessor>();
            services.AddSingleton<IUserGetdetailsServices, AuthenticateUser>();

            // Insert UserDetails
            services.AddSingleton<IUserDetailsInsert,InsertUserDetailsServices>();
            services.AddSingleton<IBusinessInsertUserDetails, BusinessInsertUserDetails>();
            services.AddSingleton<IUserInformationInsert,AddUserDetailsServices>();

            //GetUser Details
            services.AddSingleton<IGetAllUserData, GetAllUserInformationDetails>();
            services.AddSingleton<IGetUserDetailsServices,GetUserDetails>();

            //Delete User
            services.AddSingleton<IDeleteUserDetails, DeleteUserDetailsService>();
            services.AddSingleton<IUserDetailsRemoveService, RemoveUserInfo>();
            //RemoveUserInfo : IUserDetailsRemoveService
            //DeleteUserDetailsService : IDeleteUserDetails

        }
    }
}
