using CursosRDApi.Data;
using CursosRDApi.Exceptions;
using CursosRDApi.Interfaces;
using CursosRDApi.Models.DTO.CourseDTOs;
using CursosRDApi.Models.DTO.TeacherDTOs;
using CursosRDApi.Models.TeacherModels;
using Microsoft.EntityFrameworkCore;

namespace CursosRDApi.Services
{
    public class TeacherService : ITeacherService
    {
        private ApplicationDbContext _db;
        public TeacherService(ApplicationDbContext db)
        {
            this._db = db;
        }

        public Teacher GetTeacherInformation(int TeacherId)
        {
            bool TeacherExists = CheckIfTeacherExists(TeacherId);

            if (TeacherExists)
            {
                Teacher? teacher = _db.Teacher.Where(teacher => teacher.Id == TeacherId && teacher.IsBanned == false).FirstOrDefault();
                return teacher;
            }
            else
            {
                 throw new TeacherNotFoundException("No se encontro ningun profesor con ese id");

            }

        }


        public async Task CreateTeacherProfile(CreateTeacherDto createTeacherDto)
        {

            Teacher teacher = new Teacher()
            {
                FirstName = createTeacherDto.FirstName,
                MiddleName = createTeacherDto.MiddleName,
                LastName = createTeacherDto.LastName,
                SecondLastName = createTeacherDto.SecondLastName,
                Email = createTeacherDto.Email,
                IsEmailConfirmed = false,
                IsActive = true,
                Phone = createTeacherDto.Phone,
                Dob = createTeacherDto.Dob,
                IsBanned = false,
                ProfileImageUrl = ""
            };

            _db.Teacher.Add(teacher);
            await _db.SaveChangesAsync();

        }

        public async void UploadTeacherProfileImage(int TeacherId, IFormFile Image)
        {
            Teacher teacher = await _db.Teacher.FirstAsync(teacher => teacher.Id == TeacherId);

            
        }
        public void UpdateTeacherProfileImage(int TeacherId, IFormFile Image)
        {

        }
        public bool CheckIfTeacherExists(int TeacherId)
        {
            bool TeacherExists = _db.Teacher.Any(teacher => teacher.Id == TeacherId);

            if (TeacherExists)
            {
                return true;

            }
            else
            {
                return false;
            }
        }
    }
}
