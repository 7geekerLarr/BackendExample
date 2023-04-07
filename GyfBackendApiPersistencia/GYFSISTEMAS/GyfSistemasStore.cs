using GyfBackendApiDominio.GyfSistemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiPersistencia.GYFSISTEMAS
{
    public static class GyfSistemasStore
    {
        public static List<GyfSistemaModels> GyfSistemas_List = new List<GyfSistemaModels>
        {
                new GyfSistemaModels{ Id=1 , Nombre="SuperApp", Descripcion = "Sistema que se encarga de la Fe de vida!", Usuario ="Admin", TipoLicencia="Anual"},
                new GyfSistemaModels{ Id=2 , Nombre="Adintar", Descripcion = "Solución para la gestión de tarjetas de crédito", Usuario ="Admin", TipoLicencia="Mensual"},
                new GyfSistemaModels{ Id=3 , Nombre="CashDispenser", Descripcion = "Cajero Automaticos", Usuario ="Admin", TipoLicencia="Anual"},
                new GyfSistemaModels{ Id=4 , Nombre="Cambio Divisas", Descripcion = "Aplicación mobile de cambio de divisas", Usuario ="Admin", TipoLicencia="Mensual"},
                new GyfSistemaModels{ Id=5 , Nombre="Modo", Descripcion = "Backend de Modo", Usuario ="Admin", TipoLicencia="Anual"}               
        };       
    }
}
