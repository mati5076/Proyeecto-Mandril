using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using especiemandril.models;
using especiemandril.patron_repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace especiemandril.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EspecieController : ControllerBase
    {
        private readonly IEspeciesRepository _rep;

        public EspecieController(IEspeciesRepository rep){
            _rep = rep;
        }

        [HttpPost]
        public async Task<IActionResult> PostEspecie([FromBody] Especie e){
            if(e is null){
                return BadRequest("Dato invalido");
            }
            try{
                var crear = await _rep.Postasync(e);
                return CreatedAtAction(nameof(GetForId) , new {id = crear.Id} , crear);
            }
             catch (DbUpdateException ex){
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.InnerException?.Message ?? ex.Message}");
            }
            catch (Exception ex){
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetEspecie(){
            var especie = await _rep.Getasync();
            return Ok(especie);
        }

        [HttpGet("(id:int)")]
        public async Task<IActionResult> GetForId(int id){
            var mandril = await _rep.GetIdasync(id);

            if(mandril == null) return NotFound();

            return Ok(mandril);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandril(int id, [FromBody] Especie e){
            if(e.Id != id) return BadRequest();

            var update = await _rep.Postasync(e);

            if(update == null) return NotFound();

            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMandril(int id){
            var success = await _rep.DeleteIdasync(id);
            if(!success) return NotFound("Mandril no encontrado");
            
            return Ok("Mandril eliminado correctamente");
        }
    }
}