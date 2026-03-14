using Microsoft.AspNetCore.Mvc;
using SistemaNotificacaoEscolarBack.Models.DTOs;
using SistemaNotificacaoEscolarBack.Models.Interfaces.IBoletimService;

namespace SistemaNotificacaoEscolarBack.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletimController(IBoletimService boletimService) : ControllerBase
    {
        private readonly IBoletimService _boletimService = boletimService;

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] List<BoletimRequest> request)
        {
            var sucesso = await _boletimService.SaveAsync(request);
            if (!sucesso) return BadRequest("Erro ao salvar boletim.");
            return Ok(new { message = "Boletim salvo com sucesso!" });
        }

        [HttpGet("{studentId}")]
        public async Task<IActionResult> GetByStudent(Guid studentId)
        {
            var boletim = await _boletimService.GetByStudentAsync(studentId);
            return Ok(boletim);
        }
    }
}