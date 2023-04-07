using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiDominio.GyfSistemas
{
    public class GyfSistemaModelsDto 
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
    }
}
