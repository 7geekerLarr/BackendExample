using System.ComponentModel.DataAnnotations;

namespace GyfBackendApiModels.GYFSISTEMAS
{
    public class GyfSistemasDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}