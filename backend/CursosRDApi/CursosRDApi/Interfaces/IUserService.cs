using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.UserDTOs;
using CursosRDApi.Models.UserModels;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Interfaces
{
    public interface IUserService
    {
        public UserDAO Login(LoginDto loginDto);
    }
}
