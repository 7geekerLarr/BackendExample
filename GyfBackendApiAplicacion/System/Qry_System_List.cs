using GyfBackendApiDominio.GyfSistemas;
using GyfBackendApiPersistencia.SISTEMAS;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GyfBackendApiAplicacion.System
{
    public class Qry_System_List
    {
        #region ExecuteList       
        public class ExecuteList : IRequest<List<GyfSistemaModels>>
        {

        }
        #endregion
        #region HandlerClass
        public class HandlerClass : IRequestHandler<ExecuteList, List<GyfSistemaModels>>
        {
            private readonly IGyf_Sistemas _Gyf_SistemasRepository;
            public HandlerClass(IGyf_Sistemas Gyf_SistemasRepository)
            {
                _Gyf_SistemasRepository = Gyf_SistemasRepository;
            }
            public async Task<List<GyfSistemaModels>> Handle(ExecuteList request, CancellationToken cancellationToken)
            {
                var resultado = await _Gyf_SistemasRepository.Get_All();
                return resultado?.OrderBy(x=>x.Id).ToList() ?? new List<GyfSistemaModels>();
            }
        }
        #endregion
    }
}
