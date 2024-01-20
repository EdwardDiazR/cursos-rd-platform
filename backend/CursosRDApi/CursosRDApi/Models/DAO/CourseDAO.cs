using CursosRDApi.Models.CourseModels;
using CursosRDApi.Models.TeacherModels;
using System.ComponentModel.DataAnnotations;

namespace CursosRDApi.Models.DAO
{
    public class CourseDAO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool IsPublic { get; set; }
        public decimal Price { get; set; }
        public DateTime PublishedDate { get; set; }
        public int EnrolledStudents { get; set; }

        public string UrlTitle { get; set; }
        public string Language { get; set; }
        [Required]
        public Teacher Teacher { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
