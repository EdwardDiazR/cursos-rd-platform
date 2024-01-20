using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosRDApi.Models
{
    [Table("role")]
    public class Role
    {
        [Column("role_id")]
        [Key]
        public int Id { get; set; }

        [Column("role_name")]
        public string Name { get; set; }

    }
}
