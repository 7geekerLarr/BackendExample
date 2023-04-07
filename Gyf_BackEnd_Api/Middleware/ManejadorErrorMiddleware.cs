using GyfBackendApiAplicacion.ManejadorError;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net;


namespace Gyf_BackEnd_Api.Middleware
{
    public class ManejadorErrorMiddleware
    {
        #region IDependencies        
        private readonly RequestDelegate _next;    
        private readonly ILogger<ManejadorErrorMiddleware> _logger;
        #endregion
        #region ManejadorErrorMiddleware        
        public ManejadorErrorMiddleware(RequestDelegate next, ILogger<ManejadorErrorMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        #endregion
        #region Invocar       
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

               await ManejadorExcepcionAsincrono(context, ex, _logger);
            }
            
        }
        #endregion
        private async Task ManejadorExcepcionAsincrono(HttpContext context, Exception ex, ILogger<ManejadorErrorMiddleware> logger) 
        { 
            object errores = "";

            switch(ex)
            {
                case ManejadorExcepcion me:
                    
                    errores = me.Errores;
                    context.Response.StatusCode = (int)me.Codigo;
                    logger.LogError(context.Response.StatusCode + " - " + errores.ToString(), "Manejador Error");                    
                    break;
                case Exception e:
                    logger.LogError(ex, "Error de Servidor");
                    logger.LogError(ex.InnerException, "Error de Servidor");
                    errores = string.IsNullOrWhiteSpace(e.Message) ? "Error" : e.Message;
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;

            }
            context.Response.ContentType = "application/json";
            if(errores != null) 
            { 
                var resultados = JsonConvert.SerializeObject(new { errores });
                await context.Response.WriteAsync(resultados);
            }
        }
    }
}
