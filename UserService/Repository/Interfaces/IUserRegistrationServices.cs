using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserService.DTO.Request;

namespace UserService.Repository.Interfaces
{
    public interface IUserRegistrationServices
    {
        /// <summary>
        /// Add User Registrations
        /// </summary>
        /// <param name="userRegistrationRequest"></param>
        /// <returns></returns>
        Task<bool> RegisterUser(UserRegistrationRequest userRegistrationRequest);

        Task<string> Login(string username, string password);
    }
}
