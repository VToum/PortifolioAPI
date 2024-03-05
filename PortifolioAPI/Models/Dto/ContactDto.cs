using System.ComponentModel.DataAnnotations;

namespace PortifolioAPI.Models.Dto
{
    public class ContactDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Message { get; set; }
    }
}
