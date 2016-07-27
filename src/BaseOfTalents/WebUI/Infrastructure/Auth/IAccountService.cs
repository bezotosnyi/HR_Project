﻿using DAL.DTO;
using System;
using System.Threading.Tasks;

namespace WebUI.Infrastructure.Auth
{
    /// <summary>
    /// Service of controlling user actions, such as login (signin), registration and logout
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Performs first authentification of user
        /// </summary>
        /// <param name="login">The login user provided in form</param>
        /// <param name="password">User's password</param>
        /// <returns>The user and some kind of credentials as the second part</returns>
        Task<Tuple<UserDTO, string>> LogInAsync(string login, string password);

        /// <summary>
        /// Takes user data and perfroms action of registration into the system
        /// </summary>
        /// <param name="model">User data</param>
        /// <returns>Updated user data</returns>
        UserDTO Register(UserDTO model);

        /// <summary>
        /// Performs a logout - the action opposite to login
        /// </summary>
        /// <returns>True if action finished successfully. Else false.</returns>
        bool LogOut(string token);

        UserDTO GetUser(string token);
    }
}
