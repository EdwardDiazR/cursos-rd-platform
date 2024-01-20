using CursosRDApi.Data;
using CursosRDApi.Interfaces;
using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.UserDTOs;
using CursosRDApi.Models.StudentModels;
using CursosRDApi.Models.TeacherModels;
using CursosRDApi.Models.UserModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Controllers
{
    [Route("api/v2/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ApplicationDbContext _db;
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("login")]
        public ActionResult Login(LoginDto loginDto)
        {
        
            try
            {
                UserDAO user = _userService.Login(loginDto);
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("No se pudo iniciar secion valide");
                }
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
