using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRS.Domain.Entities
{
    public class Table
    {
        [Key]
        public Guid Id { get; set; }
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Name { get; set; } = string.Empty;
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Capacity { get; set; } = string.Empty;
        [Required, Column(TypeName = "VARCHAR(100)")]
        public string Status { get; set; } = string.Empty;
    }
}
