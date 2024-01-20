using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosRDApi.Models.TeacherModels
{
    [Table("teacher")]
    public class Teacher
    {
        [Column("teacher_id")]
        [Key]
        public int Id { get; set; }

        [Column("teacher_first_name")]
        [Required]
        public string FirstName { get; set; }

        [Column("teacher_middle_name")]
        public string? MiddleName { get; set; }

        [Column("teacher_last_name")]
        [Required]
        public string LastName { get; set; }

        [Column("teacher_second_last_name")]
        public string? SecondLastName { get; set; }

        [Column("teacher_display_name")]

        public string DisplayName { get; set; }

        [Column("teacher_email")]
        [Required]
        public string Email { get; set; }

        [Column("is_email_confirmed")]
        public bool IsEmailConfirmed { get; set; }

        [Column("is_active")]
        [Required]
        public bool IsActive { get; set; }

        [Column("is_banned")]
        public bool IsBanned { get; set; }
        public string Phone { get; set; }

        [Column("teacher_dob")]
        [Required]
        public DateTime Dob { get; set; }

        [Column("teacher_profile_image_url")]
        public string? ProfileImageUrl { get; set; }

        [Column("teacher_role_id")]
        public int? RoleId { get; set; }

        [NotMapped]
        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }



    }
}
