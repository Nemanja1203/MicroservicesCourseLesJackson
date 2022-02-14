using System.ComponentModel.DataAnnotations;

namespace PlatformService.Models
{
    // TODO: (nm) Use FluentApi instead of DataAnnotations for describing DB model
    public class Platform
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Cost { get; set; }
    }
}
