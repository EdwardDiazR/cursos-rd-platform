using CursosRDApi.Models.CourseModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace CursosRDApi.Models.StudentModels
{
    [Table("student")]
    public class Student
    {
        [Column("student_id")]
        [Key]
        public int Id { get; set; }

        [Column("student_first_name")]
        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Column("student_middle_name")]
        [AllowNull]
        public string MiddleName { get; set; }

        [Column("student_last_name")]
        [Required]
        [MaxLength(200)]
        public string LastName { get; set; }

        [Column("student_second_last_name")]
        [AllowNull]
        public string SecondLastName { get; set; }

        [Column("student_email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Column("is_email_confirmed")]
        public bool IsEmailConfirmed { get; set; }

        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; }

        [Column("is_banned")]
        public bool IsBanned { get; set; }

        [Column("student_phone_number")]
        public string Phone { get; set; }

        [Column("student_country")]
        [Required]
        public string Country { get; set; }

        [Column("student_gender")]
        [Required]
        public Genders Gender { get; set; }
        public enum Genders
        {
            M = 'M',
            F = 'F'
        }


        [Column("student_role_id")]
        public int? RoleId { get; set; }

        [NotMapped]
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
