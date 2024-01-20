using CursosRDApi.Models.CourseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CursosRDApi.Models.StudentModels
{
    [Table("course_enroll")]
    public class CourseSubscription
    {
        [Column("enroll_id")]
        [Key]
        public int Id { get; set; }

        [Column("enroll_course_id")]
        [Required]
        public int CourseId { get; set; }


        //Foreign key for course Id
        [NotMapped]
        [ForeignKey(nameof(CourseId))]
        public Course? Curso{ get; set; }

        [Column("enroll_student_id")]
        [Required]
        public int StudentId { get; set; }


        //Foreign Key for StudentId
        [NotMapped]
        [ForeignKey(nameof(StudentId))]
        public Student? Student { get; set; }

        [Column("enroll_is_active")]
        public bool IsActive { get; set; }

        [Column("enroll_date")]
        [Required]
        public DateTime EnrollDate { get; set; }

        [Column("enroll_course_price")]
        [Required]
        public decimal CoursePrice { get; set; }

        [Column("enroll_discount")]
        public decimal Discount { get; set; }

        [Column("enroll_coupon")]
        [AllowNull]
        public string Coupon {  get; set; }

        [Column("enroll_total")]
        [Required]
        public decimal Total { get; set; }

       

    }
}
