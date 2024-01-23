using System.ComponentModel.DataAnnotations;

namespace BookApi.Dtos
{
    public class ComentarioCrearDto
    {
        [Required]
        public string? Contenido { get; set; }
    }
}
