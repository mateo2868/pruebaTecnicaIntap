using Microsoft.AspNetCore.Mvc;
using pruebaIntap2.Applications;
using pruebaIntap2.Models;

namespace pruebaIntap2.Controllers
{
    [ApiController]
    [Route("api/actividades")]
    public class ActividadController : ControllerBase
    {
        private readonly ActividadService _service;

        public ActividadController(ActividadService service)
        {
            _service = service;
        }

        [HttpPost("actividad")]
        public async Task<IActionResult> AgregarActividad([FromBody] Activity Actividad)
        {
            try
            {
                Actividad.Id = 0; // Forzar a 0 para que EF lo trate como nuevo
                await _service.AgregarActividadAsync(Actividad);
                return Ok(new { mensaje = "Actividad Agregada" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("{id}/tiempos")]
        public async Task<IActionResult> AgregarTiempo(int id, [FromBody] TiempoActividad tiempo)
        {
            try
            {
                await _service.AgregarTiempoAsync(id, tiempo);
                return Ok(new { mensaje = "Tiempo agregado" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("usuario/{usuarioId}")]
        public async Task<IActionResult> ObtenerPorUsuario(int usuarioId)
        {
            try
            {
                var actividades = await _service.ObtenerActividadesPorUsuarioAsync(usuarioId);
                return Ok(actividades);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/tiempos")]
        public async Task<IActionResult> ObtenerTiempos(int id)
        {
            try
            {
                var tiempos = await _service.ObtenerTiemposPorActividadAsync(id);
                return Ok(tiempos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

}
