using Microsoft.AspNetCore.Http;
using Serilog;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Gyf_BackEnd_Api.Middleware
{
    public class TraceMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            // Aquí implementarás el código para hacer el seguimiento de la transacción
            // antes de pasar la petición al siguiente middleware
           // Log.Information($"[{DateTime.UtcNow}] Request from {context.Connection.RemoteIpAddress} to {context.Request.Path}");
            Log.Information($"[{DateTime.UtcNow}] Request from {context.Connection.RemoteIpAddress} to {context.Request.Path} with method {context.Request.Method}");
            await next(context);
        }
        private async Task<string> GetRequestBodyAsync(HttpRequest request)
        {
            // Verificar si el cuerpo (body) de la solicitud es nulo o si la longitud es cero
            if (request.Body == null || !request.Body.CanRead || request.ContentLength == 0)
            {
                return string.Empty;
            }

            // Leer el cuerpo (body) de la solicitud utilizando un StreamReader
            using var reader = new StreamReader(request.Body, Encoding.UTF8, true, 1024, true);
            var requestBody = await reader.ReadToEndAsync();

            // Verificar si el cuerpo de la solicitud es un objeto JSON válido
            try
            {
                var json = JsonSerializer.Deserialize<object>(requestBody);
                return requestBody;
            }
            catch (JsonException ex)
            {
                Log.Warning($"Failed to parse request body as JSON: {ex.Message}");
                return string.Empty;
            }
        }

    }
}
