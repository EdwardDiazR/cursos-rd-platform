using CursosRDApi.Interfaces;
using CursosRDApi.Models.DTO.TeacherDTOs;
using CursosRDApi.Models.TeacherModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Controllers
{
    [Route("api/v2/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ITeacherService _teacherService;
        public TeacherController(ITeacherService teacherService)
        {
            this._teacherService = teacherService;
        }


        [HttpGet("{TeacherId}/profile")]
        public ActionResult GetTeacherProfile(int TeacherId)
        {
            Teacher teacher = _teacherService.GetTeacherInformation(TeacherId);
            if (teacher !=null)
            {
                return Ok(teacher);
            }
            else
            {
                return BadRequest("Teacher not found with that ID");
            }
          
        }


        [HttpPost("create-profile")]
        public async Task<ActionResult> CreateTeacherProfile(CreateTeacherDto createTeacherDto)
        {

            try
            {
                await _teacherService.CreateTeacherProfile(createTeacherDto);
                return Ok("Teacher profile has been created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        

        //[HttpPost]
        //public async Task<ActionResult> ConfirmateAccount(int TeacherId, string TeacherEmail)
        //{
        //    try
        //    {
        //        return Ok("Confirmation code has been submitted to your email!");
        //    }
        //    catch (Exception ex) { }

        //}

        //public void UpdateTeacherProfile() { }
        //public void DeleteTeacherProfile() { }  
        //public void VerifyAccount(){ }
        //public void CheckIfAccountVerified() { }
        //public void GetCoursesByTeacher() { }
        //public void GetCourseById() { }

    }
}
