using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendRS.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        [Required]
        public Guid TableId { get; set; }

        [ForeignKey("TableId")]
        public Table Table { get; set; } = null!;

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string dateReservation { get; set; } = string.Empty;

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string status { get; set; } = string.Empty;
    }
}
