using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.db;
using WebApplication1.models;
using WebApplication1.Patron_Repository;



namespace WebApplication1.controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MandrillController : ControllerBase
    {
        private readonly IMandrilRepository _repository;

        public MandrillController(IMandrilRepository repository){
            _repository = repository;
        }
        
        [HttpPost]
        public async Task<IActionResult> PostMandril([FromBody] Mandril m){

            if(m is null){
                return BadRequest("Datos invalidos");
            }
            var crear = await _repository.Postasync(m);
            return CreatedAtAction(nameof(GetForId) , new {id = crear.Id} , crear);
        }

        [HttpGet]
        public async Task<IActionResult> Getcomplet(){
            var mandril = await _repository.Getasync();
            return Ok(mandril);
        }
        
        [HttpGet("{Id:int}")]
        public async Task<IActionResult> GetForId(int Id){
            var mandril = await _repository.GetIdasync(Id);

            if(mandril == null) return NotFound();

            return Ok(mandril);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMandril(int id, [FromBody] Mandril m){
            if(m.Id != id) return BadRequest();

            var update = await _repository.Postasync(m);

            if(update == null) return NotFound();

            return Ok(update);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMandril(int id){
            var success = await _repository.DeleteIdasync(id);
            if(!success) return NotFound("Mandril no encontrado");
            
            return Ok("Mandril eliminado correctamente");
        }
    }
}