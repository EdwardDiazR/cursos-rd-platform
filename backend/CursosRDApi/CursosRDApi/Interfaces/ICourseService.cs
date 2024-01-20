using CursosRDApi.Models.CourseModels;
using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.CourseDTOs;
using Microsoft.AspNetCore.Mvc;

namespace CursosRDApi.Interfaces
{
    public interface ICourseService
    {
        public List<Course> GetAllCourses();
        public Task CreateCourse(CreateCourseDto courseDto);
        public bool CheckIfUrlTitleExists(string url);
        public Task UpdateCourseInformation(UpdateCourseDto updateCourseDto);
        public Task<List<CourseDAO>> GetCoursesByTeacherId(int TeacherId);
        public Task<List<Lesson>> GetCourseLessons(int CourseId);
        public  Task<CourseDAO> GetCourseById(int CourseId);
        public Task<CourseDAO> GetCourseByUrlTitle(string CourseUrlTitle);
    }
}
