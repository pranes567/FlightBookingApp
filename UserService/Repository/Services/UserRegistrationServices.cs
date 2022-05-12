using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using UserService.DataContext;
using UserService.DTO.Request;
using UserService.Models;
using UserService.Repository.Interfaces;

namespace UserService.Repository.Services
{
    public class UserRegistrationServices : IUserRegistrationServices
    {    
        #region

        private readonly UserServiceContext _userServiceContext;

        #endregion

        #region Constructor

        public UserRegistrationServices(UserServiceContext userServiceContext)
        {
            _userServiceContext = userServiceContext ?? throw new ArgumentNullException(nameof(userServiceContext));
        }
        #endregion
        public async Task<bool> RegisterUser(UserRegistrationRequest userRegistrationRequest)
        {
            if (userRegistrationRequest == null)
                throw new ArgumentNullException(nameof(userRegistrationRequest));

            bool result = false;
            UserRegistration userRegistration;

            var checkUserExists = await _userServiceContext.userRegistrations.Where(d => d.UserName == userRegistrationRequest.UserName).FirstOrDefaultAsync();
            if (checkUserExists == null)
            {
                userRegistration = new UserRegistration()
                {
                    UserName = userRegistrationRequest.UserName,
                    Password = userRegistrationRequest.PassWord,
                    Name = userRegistrationRequest.Name,
                    EmailId = userRegistrationRequest.EmailId,
                    InsertDate = DateTime.Now,
                    Flag = 0,
                    role = "user"
                };

                await _userServiceContext.AddAsync(userRegistration);
                await _userServiceContext.SaveChangesAsync();
                result = true;
            }


            return result;
        }

        public async Task<string> Login(string username,string password)
        {
            //if (loginRequest == null)
            //    throw new ArgumentNullException(nameof(loginRequest));

            string result = string.Empty;
            var checkUser = await _userServiceContext.userRegistrations.Where(d => d.UserName == username
                                                 && d.Password == password).FirstOrDefaultAsync();

            if (checkUser != null)
            {
                result = checkUser.role;
            }
            else
            {
                result = "usernotfound";
            }

            return result;
        }
    }
}
