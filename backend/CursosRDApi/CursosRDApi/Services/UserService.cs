using CursosRDApi.Data;
using CursosRDApi.Exceptions;
using CursosRDApi.Interfaces;
using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.UserDTOs;
using CursosRDApi.Models.StudentModels;
using CursosRDApi.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Services
{
    public class UserService : IUserService
    {
        private ApplicationDbContext _db;
        public UserService(ApplicationDbContext db)
        {
            _db = db;
        }

        public UserDAO Login(LoginDto loginDto)
        {

            User ? user = _db.User.FirstOrDefault(user => user.Email == loginDto.Email && user.Password == loginDto.Password);
            if (user != null)
            {
                UserDAO userDAO = new UserDAO()
                {
                    ProfileId = user.ProfileId,
                    RoleId = user.RoleId,
                 

                };
                return userDAO;

            }
            else
            {
                throw new UserNotFoundException("Usuario o contrasena invalidas");
            }

        }

        //TODO: Create method for registering new users 

        //TODO: Create method for user change password

        //TODO: Method for recovering password sending code 

        //TODO: Method for user delete account 
        
        //TODO: Method for user 
    }
}
