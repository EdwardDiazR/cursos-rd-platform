using CursosRDApi.Models.DTO.CourseDTOs;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CursosRDApi.Models.TeacherModels;
using CursosRDApi.Models.StudentModels;

namespace CursosRDApi.Models.CourseModels
{
    [Table("course")]
    public class Course
    {
        [Key]
        [Column("course_id")]
        public int Id { get; set; }

        [Column("course_name")]
        [Required]

        public string Name { get; set; }

        [Column("course_descrption")]
        public string Description { get; set; }

        [Column("course_url_title")]
        [MaxLength(150)]
        public string UrlTitle { get; set; }

        [Column("course_price")]
        [Required]
        public decimal Price { get; set; }

        [Column("course_creation_date")]
        public DateTime CreationDate { get; set; }

        [Column("course_published_date")]
        public DateTime PublishedDate { get; set; }

        [Column("course_last_updated_date")]
        public DateTime LastUpdateDate { get; set; }

        [Column("course_has_been_published")]
        public bool HasBeenPublished { get; set; }

        [Column("course_enrolled_students")]
        public int EnrolledStudents { get; set; }

        [Column("course_is_public")]
        public bool IsPublic { get; set; }
        [Column("course_language")]
        public string Language { get; set; }

        [Column("course_teacher_id")]
        public int TeacherId { get; set; }

        [Column("thumbnail_image_url")]
        public string? ThumbnailImageUrl { get; set; }

    }
}
