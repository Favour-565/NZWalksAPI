using System.ComponentModel.DataAnnotations;

namespace NzApp.Model.Dtos
{
    public class AddRegionRequestDto
    {
        [Required]
        [MaxLength(3, ErrorMessage = "Code has to be a maximum of 3 characters")]
        [MinLength(3, ErrorMessage = "Code has to be a minimum of 3 characters")]
        public string Code { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Code has to be a maximum of 100 characters")]
      
        public string Name { get; set; }
        public string? Image { get; set; }
    }
}
