using CursosRDApi.Models.DTO.CourseDTOs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosRDApi.Models.CourseModels
{
    [Table("lesson")]
    public class Lesson
    {
        [Column("lesson_id")]
        [Key]

        //TODO: MAKE GUID 
        public int Id { get; set; }

        [Column("lesson_name")]
        [Required]
        public string Name { get; set; }

        [Column("lesson_description")]
        public string Description { get; set; }

        [Column("course_id")]
        [Required]
        public int CourseId { get; set; }

        [NotMapped]
        [ForeignKey(nameof(CourseId))]
        public Course Course { get; set; }

        [Column("section_id")]
        [Required]
        public int SectionId { get; set; }

        [NotMapped]
        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

        [Column("video_url")]
        [Required]
        public string VideoUrl { get; set; }

        [Column("is_visible")]
        [Required]
        public bool IsVisible { get; set; }

    }
}
