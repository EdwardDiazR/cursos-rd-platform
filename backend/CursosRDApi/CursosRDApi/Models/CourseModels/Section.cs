using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosRDApi.Models.CourseModels
{
    [Table("course_lessons_section")]
    public class Section
    {
        [Column("section_id")]
        [Key]
        public int Id { get; set; }

        [Column("section_name")]
        public string Name { get; set; }

        [Column("section_description")]
        public string Description { get; set; }

        [Column("section_lessons_qty")]
        public int SectionLessons { get; set; }
    }
}
