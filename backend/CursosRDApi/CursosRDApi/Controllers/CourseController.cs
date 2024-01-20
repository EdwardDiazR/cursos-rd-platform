using CursosRDApi.Exceptions;
using CursosRDApi.Interfaces;
using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.CourseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Controllers
{
    [Route("api/v2/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            this._courseService = courseService;
        }

        [HttpGet("{teacherId}/courses")]
        public async Task<ActionResult<CourseDAO>> GetAllTeacherCourses(int teacherId)
        {
            try
            {
                List<CourseDAO> courses = await _courseService.GetCoursesByTeacherId(teacherId);
                return Ok(courses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("courses")]

        public ActionResult GetAll()
        {
            return Ok(_courseService.GetAllCourses());
        }


        [HttpPost("{teacherId}/create-course")]
        public async Task<ActionResult> CreateCourse([FromBody] CreateCourseDto courseDto)
        {
            string ResponseMessage;
            try
            {
                await _courseService.CreateCourse(courseDto);
                ResponseMessage = "Curso creado exitosamente";
                return Ok(ResponseMessage);
            }
            catch (Exception exx)
            {
                if (exx.InnerException is TeacherNotFoundException)
                {
                    return BadRequest(exx.Message);
                }
                else
                {
                    return BadRequest(exx.Message);
                }

            }
           

        }

        private static bool CheckIfNumeric(string Value)
        {
            try
            {
                int.Parse(Value);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        [HttpGet("{CourseId}/details")]
        public async Task<ActionResult<CourseDAO>> GetCourseById(string CourseId)
        {
            CourseDAO courseById;
            try
            {
                if (CheckIfNumeric(CourseId))
                {
                    //If id in parameter is numeric, get course details by ID
                    courseById = await _courseService.GetCourseById(int.Parse(CourseId));
                }
                else
                {
                    //Else get course details by url-title
                    courseById = await _courseService.GetCourseByUrlTitle(CourseId);

                }
                if (courseById != null)
                {
                    return Ok(courseById);
                }
                else
                {

                    return Ok(courseById);

                }
            }
            catch (Exception ex)
            {
                return BadRequest("Error" + ex);
            }
        }

        [HttpPut("{CourseId}/update")]
        public async Task<ActionResult> UpdateCourse(UpdateCourseDto courseDto)
        {
            try
            {
                await _courseService.UpdateCourseInformation(courseDto);
                return Ok("El curso se ha actualizado con exito");
            }
            catch (Exception ex)
            {

                return BadRequest(ex);

            }
        }

        [HttpGet("top-ten")]
        public async Task<ActionResult> GetTopTenCourses()
        {
            //TODO: Get most courses subscriptions in last week, then take the 10 first results
            try { return Ok(""); }
            catch (Exception ex)
            {
                return BadRequest("");
            }

        }



    }
}
