using Cebolla.Application.DTOs;
using Cebolla.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cebolla.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _service;

        public PersonaController(IPersonaService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var personas = await _service.ObtenerTodasAsync();
            return Ok(personas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var persona = await _service.ObtenerPorIdAsync(id);
            if (persona == null) return NotFound();
            return Ok(persona);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PersonaDto dto)
        {
            await _service.CrearAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PersonaDto dto)
        {
            if (id != dto.Id) return BadRequest("IDs no coinciden");
            await _service.ActualizarAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.EliminarAsync(id);
            return NoContent();
        }
    }
}
