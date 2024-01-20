using CursosRDApi.Data;
using CursosRDApi.Exceptions;
using CursosRDApi.Interfaces;

using CursosRDApi.Models.CourseModels;
using CursosRDApi.Models.DAO;
using CursosRDApi.Models.DTO.CourseDTOs;
using CursosRDApi.Models.TeacherModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CursosRDApi.Services
{
    public class CourseService : ICourseService
    {
        private ApplicationDbContext _db;
        private ITeacherService _teacherService;
        private DateTime TodaysDate = DateTime.Now;

        public CourseService(ITeacherService teacherService, ApplicationDbContext db)
        {
            this._db = db;
            this._teacherService = teacherService;
        }

        public List<Course> GetAllCourses()
        {
            //List<Course> courses = _db.Course.FromSqlRaw("SELECT course_name,course_price FROM course").ToList();
            List<Course> courses = _db.Course.ToList();
            return courses;
        }

        public async Task<CourseDAO> GetCourseByUrlTitle(string CourseUrlTitle)
        {
            CourseDAO? CourseByTitle = await _db.Course.Select(course => new CourseDAO()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Price = course.Price,
                PublishedDate = course.PublishedDate,
                EnrolledStudents = course.EnrolledStudents,
                Language = course.Language,
                Teacher = _teacherService.GetTeacherInformation(course.TeacherId),
                UrlTitle = course.UrlTitle,


            }).FirstOrDefaultAsync(course => course.UrlTitle == CourseUrlTitle);

            if (CourseByTitle != null)
            {
                CourseByTitle.Lessons = await GetCourseLessons(CourseByTitle.Id);
                return CourseByTitle;
            }
            else
            {
                throw new Exception("Course not found");
            }
        }


        public async Task<CourseDAO> GetCourseById(int CourseId)
        {
            CourseDAO? courseById = await _db.Course.Select(course => new CourseDAO()
            {
                Id = course.Id,
                Name = course.Name,
                Description = course.Description,
                Price = course.Price,
                PublishedDate = course.PublishedDate,
                EnrolledStudents = course.EnrolledStudents,
                Language = course.Language,
                Teacher = _teacherService.GetTeacherInformation(course.TeacherId),
                UrlTitle = course.UrlTitle


            }).FirstOrDefaultAsync(course => course.Id == CourseId);

            if (courseById != null)
            {
                courseById.Lessons = await GetCourseLessons(courseById.Id);
                return courseById;
            }
            else
            {
                throw new Exception("Course not found");
            }
        }



        //Get courses by teacher
        public async Task<List<CourseDAO>> GetCoursesByTeacherId(int TeacherId)
        {
            string CourseSqlQuery = $"SELECT course_id,course_name,course_descrption,course_price,course_published_date,course_enrolled_students,course_language,course_is_public,course_url_title,course_teacher_id,course_creation_date FROM course WHERE course_teacher_id = {TeacherId}";
            Teacher teacher = _teacherService.GetTeacherInformation(TeacherId);

            if (teacher != null)
            {
                //var a = _db.Course.FromSql(new SqlQuery( "SELECT * FROM course")).Where(a => a.Id == teacher.Id);
                List<CourseDAO> courses = _db.Course.Where(course => course.TeacherId == TeacherId /*&& course.IsPublic && course.HasBeenPublished*/)
                    .Select(course => new CourseDAO()
                    {
                        Id = course.Id,
                        Name = course.Name,
                        Description = course.Description,
                        Price = course.Price,
                        PublishedDate = course.PublishedDate,
                        EnrolledStudents = course.EnrolledStudents,
                        Language = course.Language,
                        Teacher = teacher,
                        IsPublic = course.IsPublic,
                        UrlTitle = course.UrlTitle
                    })
                    .ToList();

                foreach (var item in courses)
                {
                    item.Lessons = await GetCourseLessons(item.Id);

                }

                return courses;
            }
            else
            {
                throw new TeacherNotFoundException("No se ha encontrado ningun teacher con ese id");
            }

        }

        public bool CheckIfUrlTitleExists(string url)
        {

            return _db.Course.Any(course => course.UrlTitle == url);

        }


        //Method for creating a new Course 
        public async Task CreateCourse(CreateCourseDto courseDto)
        {

            bool TeacherExists = _teacherService.CheckIfTeacherExists(courseDto.TeacherId);

            if (TeacherExists)
            {
                try
                {
                    string UrlTitle;
                    StringBuilder sb = new StringBuilder();
                    Guid guid = Guid.NewGuid();
                    foreach (var i in courseDto.TitleKeywords)
                    {
                        sb.Append(i.ToLower() + ' ');
                    }

                   /* sb.Append(' ' + guid.ToString())*/;


                    UrlTitle = sb.ToString().TrimEnd(' ').Replace(' ', '-');

                    //UrlTitle = guid.ToString();
                    //If publish date is a past date, throw error of past date
                    if (courseDto.PublishedDate.Date < TodaysDate.Date)
                    {
                        //Throw Exception if publish date is a past date
                        throw new OutOfDateException("La fecha de publicacion no puede ser menor a la fecha actual");
                    }
                        
                    if (CheckIfUrlTitleExists(UrlTitle))
                    {
                        throw new Exception("Ya existe un curso con esta url");
                    }


                    if (string.IsNullOrEmpty(courseDto.Description))
                    {
                        courseDto.Description = string.Empty;
                    }


                    Course Course = new Course()
                    {
                        Name = courseDto.Name,
                        Price = courseDto.Price,
                        CreationDate = TodaysDate,
                        PublishedDate = courseDto.PublishedDate,
                        LastUpdateDate = TodaysDate,
                        HasBeenPublished = false,
                        EnrolledStudents = 0,
                        IsPublic = false,
                        Language = courseDto.Language,
                        TeacherId = courseDto.TeacherId,
                        ThumbnailImageUrl = null,
                        Description = courseDto.Description,
                        UrlTitle = UrlTitle,

                    };

                    await _db.Course.AddAsync(Course);
                    await _db.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                //Throw exception if Teacher doesn't exists
                throw new TeacherNotFoundException("No se encuentra ningun profesor con ese ID");

            }

        }


        public async Task UpdateCourseInformation(UpdateCourseDto updateCourseDto)
        {
            Course? course = await _db.Course.FindAsync(updateCourseDto.Id);

            bool HasChanges = true;

            if (course != null)

                if (HasChanges)
                {
                    course.Id = course.Id;
                    course.Name = updateCourseDto.Name;
                    course.Price = updateCourseDto.Price;
                    course.Description = updateCourseDto.Description;
                    course.CreationDate = course.CreationDate;
                    course.EnrolledStudents = course.EnrolledStudents;
                    course.HasBeenPublished = course.HasBeenPublished;
                    course.IsPublic = course.IsPublic;
                    course.Language = updateCourseDto.Language;
                    course.LastUpdateDate = TodaysDate;
                    course.PublishedDate = updateCourseDto.PublishedDate;
                    course.TeacherId = course.TeacherId;
                    course.ThumbnailImageUrl = course.ThumbnailImageUrl;


                    _db.Course.Update(course);
                    _db.SaveChanges();

                }
        }


        //Get course lesson
        public async Task<List<Lesson>> GetCourseLessons(int CourseId)
        {
            List<Lesson> lessons = await _db.Lesson.Where(lesson => lesson.CourseId == CourseId).ToListAsync();
            return lessons;
        }
    }
}

