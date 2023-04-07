using FluentValidation;
using GyfBackendApiAplicacion.ManejadorError;
using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using System.Net;
namespace GyfBackendApiAplicacion.System
{
    public class Qry_System_Add
    {
        #region ExecuteAdd
        public class ExecuteAdd : IRequest<GyfSistemaModels>
        {
            
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public string? Usuario { get; set; }
            public string? TipoLicencia { get; set; }
        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<ExecuteAdd>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();
            }
        }

        #endregion
        #region HandlerClass
        public class HandlerClass : IRequestHandler<ExecuteAdd, GyfSistemaModels>
        {
            private readonly IGyf_Sistemas _Gyf_SistemasRepository;
            public HandlerClass(IGyf_Sistemas Gyf_SistemasRepository)
            {
                _Gyf_SistemasRepository = Gyf_SistemasRepository;
            }
            public async Task<GyfSistemaModels> Handle(ExecuteAdd request, CancellationToken cancellationToken)
            {
                GyfSistemaModels entity = new GyfSistemaModels();
                entity.Nombre = request.Nombre;
                entity.Descripcion = request.Descripcion;
                entity.TipoLicencia = request.TipoLicencia;
                entity.Usuario = request.Usuario;
               

                if (entity == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!" });                    
                }
               

                var resultado = await _Gyf_SistemasRepository.Get_All();
                resultado = resultado?.ToList() ?? new List<GyfSistemaModels>();

                var sistema1 = resultado.FirstOrDefault(s => s.Nombre?.ToUpper() == entity.Nombre?.ToUpper());
                if (sistema1 != null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { GySistemas = "NombreExiste, Sistema ya existe (Nombre:" + entity.Nombre + ")" });
                }

                var result = await _Gyf_SistemasRepository.Add(entity);
                if (result)
                {
                    return entity;
                }
                else
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotImplemented, new { GySistemas = "Error, Sistema no ha sido creado!" });
                }

            }


        }
        #endregion
    }
}
