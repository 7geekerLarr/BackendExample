using FluentValidation;
using GyfBackendApiAplicacion.ManejadorError;
using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using System.Net;

namespace GyfBackendApiAplicacion.System
{
    public class Qry_System
    {
        #region Execute
        public class Execute : IRequest<GyfSistemaModels>
        {
            public int Id { get; set; }
        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<Execute>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        #endregion
        #region HandlerClass
        public class HandlerClass : IRequestHandler<Execute, GyfSistemaModels>
        {
            private readonly IGyf_Sistemas _Gyf_SistemasRepository;
            public HandlerClass(IGyf_Sistemas Gyf_SistemasRepository)
            {
                _Gyf_SistemasRepository = Gyf_SistemasRepository;
            }
            public async Task<GyfSistemaModels> Handle(Execute request, CancellationToken cancellationToken)
            {
                if (request.Id == 0)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.BadRequest, new { GySistemas = "Id del sistema no es valido, no puede ser (0)" });
                }
                var resultado = await _Gyf_SistemasRepository.Get_All();
                resultado = resultado?.ToList() ?? new List<GyfSistemaModels>();

                var result = resultado.FirstOrDefault(s => s.Id == request.Id);
                if (result == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { GySistemas = "No se encontro el id del sistema, por favor revise el id correcto y mande de nuevo (Id:" + request.Id +")" });
                }                
                return result;
            }


        }
        #endregion
    }
}
