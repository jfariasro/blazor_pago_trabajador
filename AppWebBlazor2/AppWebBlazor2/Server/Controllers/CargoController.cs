using AppWebBlazor2.Server.Models;
using AppWebBlazor2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        private readonly Mydb2Context _context;

        public CargoController(Mydb2Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = new List<CargoDTO>();

            foreach (var item in await _context.Cargos.ToListAsync())
            {
                lista.Add(new CargoDTO
                {
                    Idcargo = item.Idcargo,
                    Nombre = item.Nombre,
                    Desripcion = item.Desripcion
                });
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] CargoDTO cargoDTO)
        {
            try
            {
                var cargo = new Cargo()
                {
                    Idcargo = cargoDTO.Idcargo,
                    Nombre = cargoDTO.Nombre,
                    Desripcion = cargoDTO.Desripcion
                };
                await _context.Cargos.AddAsync(cargo);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Editar/{id:int}")]
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] CargoDTO cargoDTO)
        {
            try
            {
                if (id != cargoDTO.Idcargo)
                    return NotFound("No coincide");

                var cargo = await _context.Cargos.FindAsync(id);

                if (cargo == null)
                    return NotFound("No encontrado");


                _context.Entry(cargo).CurrentValues.SetValues(cargoDTO);

                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            try
            {
                var cargoDTO = await _context.Cargos.FindAsync(id);

                if (cargoDTO == null)
                    return NotFound("No encontrado");

                _context.Cargos.Remove(cargoDTO);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, new { Valor = true });
            }
            catch (Exception ex)
            {
                return BadRequest("Error: " + ex.Message);
            }
        }

    }
}
