using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackendSR.Domain.Entities
{
    public class Reservation
    {
        [Key]
        public Guid Id { get; set; }

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string userId { get; set; } = string.Empty;

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string tableId { get; set; } = string.Empty;

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string dateReservation { get; set; } = string.Empty;

        [Required, Column(TypeName = "VARCHAR(100)")]
        public string status { get; set; } = string.Empty;
    }
}
