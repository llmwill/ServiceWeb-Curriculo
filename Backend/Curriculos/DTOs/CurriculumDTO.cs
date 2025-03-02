using System.ComponentModel.DataAnnotations;

namespace Curriculos.DTOs
{
    public class CurriculumDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Formation { get; set; } = string.Empty;
        [Required]
        public int PhoneNumber { get; set; } = 0;
    }
}
