using NzApp.Model.Domain;
using System.ComponentModel.DataAnnotations;

namespace NzApp.Model.Dtos
{
    public class AddWalkRequestDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public double LengthInKm { get; set; }
        [Required]
        [Range(0, 50)]
        public string walkImageUrl { get; set; }
        [Required]

        public Guid DifficultyId { get; set; }
        [Required]
        public Guid RegionId { get; set; }
       
    }
}
