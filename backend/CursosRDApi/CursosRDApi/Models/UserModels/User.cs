using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosRDApi.Models.UserModels
{
    [Table("user")]
    public class User
    {
        [Key]
        [Column("user_key")]
        public int Id { get; set; }

        [Required]
        [Column("user_password")]
        public string Password { get; set; }

        [Required]
        [Column("user_email")]
        public string Email { get; set; }

        [Required]
        [Column("user_role")]

        public int RoleId { get; set; }

        [Required]
        [Column("user_profile_id")]
        public int ProfileId { get; set; }

    }
}
