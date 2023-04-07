using GyfBackendApiAplicacion.System;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Gyf_BackEnd_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GyfController : ControllerBase
    {
        #region IDependencies
        private readonly IMediator _mediator;              
        private readonly ILogger<GyfController> _logger;
        #endregion
        #region [GyfController]       
        public GyfController(IMediator mediator, ILogger<GyfController> logger)
        {
            _logger = logger;
            _mediator = mediator;
        }
        #endregion
        #region [Get] 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Get()
        {
            // Serilog.ILogger logger = new LoggerConfiguration().WriteTo.GrafanaLoki("http://20.127.17.88:3100").CreateLogger();
            /*
            _logger.LogInformation("Consulta de todos los sistemas:" + System.DateTime.Today.ToString("dd/MM/yyyy HH:mm:ss"));
            var thor = new { Id = 1, Name = "Thor" };
            _logger.LogInformation("El dios del Rayo! {@God}", thor);
            _logger.LogInformation("NUEVO MENSAJE!", thor);
            */
            var resultado = await _mediator.Send(new Qry_System_List.ExecuteList());
            return Ok(resultado);
        }
        #endregion        
        #region [GetOne] 
        [HttpGet("id", Name = "Get")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<IActionResult> GetOne(int id)
        {            
            var resultado = await _mediator.Send(new Qry_System.Execute { Id = id});
            return Ok(resultado);
        }
        #endregion        
        #region [Add]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Add(Qry_System_Add.ExecuteAdd data)
        {
            return Ok(await _mediator.Send(data));
        }
        #endregion
        #region [Upd]
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Upd([FromBody] Qry_System_Upd.ExecuteUpd data)
        {
            return Ok(await _mediator.Send(data));
           
        }
        #endregion        
        #region [Del]
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Del(int id)
        {   
            
            var resultado = await _mediator.Send(new Qry_System_Del.ExecuteDel { Id = id });
            //return Ok(resultado);
            _logger.LogTrace("Datos han sido borrados ---> " + id.ToString());
            _logger.LogInformation("Datos han sido borrados ---> " + id.ToString());
            return NoContent();
        }
        #endregion
       
        
    }
}
