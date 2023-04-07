using FluentValidation;
using GyfBackendApiAplicacion.ManejadorError;
using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.GYFSISTEMAS;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using Microsoft.AspNetCore.Routing.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiAplicacion.System
{
    public class Qry_System_Del
    {
        #region ExecuteDel
        public class ExecuteDel : IRequest
        {
            public int Id { get; set; }
        }
        #endregion
        #region ExecuteValidator
        public class ExecuteValidator : AbstractValidator<ExecuteDel>
        {
            public ExecuteValidator()
            {
                RuleFor(x => x.Id).NotEmpty();
            }
        }

        #endregion
        #region HandlerClass
        public class HandlerClass : IRequestHandler<ExecuteDel>
        {
            private readonly IGyf_Sistemas _Gyf_SistemasRepository;
            public HandlerClass(IGyf_Sistemas Gyf_SistemasRepository)
            {
                _Gyf_SistemasRepository = Gyf_SistemasRepository;
            }
            public async Task<Unit> Handle(ExecuteDel request, CancellationToken cancellationToken)
            {
                if (request.Id == 0)
                {                    
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new {GySistemas = "Id del sistema no es valido, no puede ser 0!"});                    
                }
                var resultado = await _Gyf_SistemasRepository.Get_All();
                resultado = resultado?.ToList() ?? new List<GyfSistemaModels>();

                var sistema1 = resultado.FirstOrDefault(s => s.Id == request.Id);
                if (sistema1 == null)
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotFound, new { GySistemas = "No se encontro el id del sistema, por favor revise el id correcto y mande de nuevo (Id:" + request.Id + ")" });
                }
                var resul = await _Gyf_SistemasRepository.Del(request.Id);
                if (resul)
                {
                    return Unit.Value;
                }
                else
                {
                    throw new ManejadorExcepcion(HttpStatusCode.NotImplemented, new { GySistemas = "Error, Sistema no ha sido borrado  (Id: " + request.Id + ")" });
                    }

            }


        }
        #endregion
    }
}
