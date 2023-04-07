using FluentValidation;
using GyfBackendApiAplicacion.ManejadorError;
using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using System.Net;

namespace GyfBackendApiAplicacion.System
{
    public class Qry_System_Upd
    {
        #region ExecuteUpd
        public class ExecuteUpd : IRequest<GyfSistemaModels>
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Descripcion { get; set; }
            public string? Usuario { get; set; }
            public string? TipoLicencia { get; set; }
        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<ExecuteUpd>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Id).NotEmpty();                
                RuleFor(x => x.Nombre).NotEmpty();
                RuleFor(x => x.Descripcion).NotEmpty();                
            }
        }

        #endregion
        #region HandlerClass
        public class HandlerClass : IRequestHandler<ExecuteUpd, GyfSistemaModels>
        {
            private readonly IGyf_Sistemas _Gyf_SistemasRepository;
            public HandlerClass(IGyf_Sistemas Gyf_SistemasRepository)
            {
                _Gyf_SistemasRepository = Gyf_SistemasRepository;
            }
            public async Task<GyfSistemaModels> Handle(ExecuteUpd request, CancellationToken cancellationToken)
            {
                GyfSistemaModels entity = new GyfSistemaModels();
                entity.Id = request.Id;
                entity.Nombre = request.Nombre;
                entity.Descripcion = request.Descripcion;
                entity.TipoLicencia = request.TipoLicencia;
                entity.Usuario = request.Usuario;

                if (entity == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { GySistemas = "La estructura no es correcta!" });
                }
                if (request.Id == 0)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { GySistemas = "Id del sistema no es valido, no puede ser 0!" });
                }

                var resultado = await _Gyf_SistemasRepository.Get_All();
                resultado = resultado?.ToList() ?? new List<GyfSistemaModels>();

                var sistema1 = resultado.FirstOrDefault(s => s.Id == entity.Id);
                if (sistema1 == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { GySistemas = "Error con el parametro id, no existe (Id:" + request.Id +")" });
                }

                var result = await _Gyf_SistemasRepository.Upd(entity);
                if (result)
                {
                    return entity;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }


        }
        #endregion
    }
}
