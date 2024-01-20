using CursosRDApi.Models.DTO.TeacherDTOs;
using CursosRDApi.Models.TeacherModels;

namespace CursosRDApi.Interfaces
{
    public interface ITeacherService
    {
        public bool CheckIfTeacherExists(int TeacherId);
        public Teacher GetTeacherInformation(int TeacherId);
        public Task CreateTeacherProfile(CreateTeacherDto createTeacherDto);
        public void UploadTeacherProfileImage(int TeacherId, IFormFile Image);
        public void UpdateTeacherProfileImage(int TeacherId, IFormFile Image);

    }
}
