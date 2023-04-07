using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiDominio.GyfSistemas
{
    public class GyfSistemaModels: GyfSistemaModelsDto
    {       
        public string? Usuario { get; set; }
        public string? TipoLicencia { get; set; }
    }
}
