using Microsoft.AspNetCore.Mvc;
using SistemaNotificacaoEscolarBack.Interfaces.Dash;

namespace SistemaNotificacaoEscolarBack.Controllers
{
        [ApiController]
        [Route("api/[controller]")]
        public class EstatisticasController(IDashService DashService) : ControllerBase
        {
            private readonly IDashService _service = DashService;

            [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string? materia, [FromQuery] int? ano)
        {
            var resultado = await _service.GetEstatisticasAsync(materia, ano);
            return Ok(resultado);
        }
    }
}