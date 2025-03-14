using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSR.Domain.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Email { get; set; } = string.Empty;
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Password { get; set; } = string.Empty;
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Role { get; set; } = string.Empty;

    }
}
