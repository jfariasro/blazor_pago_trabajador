using AppWebBlazor2.Server.Models;
using AppWebBlazor2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {

        private readonly Mydb2Context _context;

        public EmpleadoController(Mydb2Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = new List<EmpleadoDTO>();

            foreach (var item in await _context.Empleados.Include(e => e.IdcargoNavigation).ToListAsync())
            {
                lista.Add(new EmpleadoDTO
                {
                    Idempleado = item.Idempleado,
                    Cargo = new CargoDTO
                    {
                        Idcargo = item.IdcargoNavigation!.Idcargo,
                        Nombre = item.IdcargoNavigation!.Nombre,
                        Desripcion = item.IdcargoNavigation!.Desripcion,
                    },
                    Nombre = item.Nombre,
                    Edad = item.Edad,
                    Salario = item.Salario
                });
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] EmpleadoDTO empleadoDTO)
        {
            try
            {
                var cargo = await _context.Cargos.SingleOrDefaultAsync(c => c.Idcargo == empleadoDTO.Cargo!.Idcargo);
                var empleado = new Empleado()
                {
                    Idempleado = empleadoDTO.Idempleado,
                    IdcargoNavigation = cargo,
                    Nombre = empleadoDTO.Nombre,
                    Edad = empleadoDTO.Edad,
                    Salario = empleadoDTO.Salario
                };
                await _context.Empleados.AddAsync(empleado);
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
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] EmpleadoDTO empleadoDTO)
        {
            try
            {
                if (id != empleadoDTO.Idempleado)
                    return NotFound("No coincide");

                var empleado = await _context.Empleados.FindAsync(id);

                var cargo = await _context.Cargos.SingleOrDefaultAsync(c => c.Idcargo == empleadoDTO.Cargo!.Idcargo);

                if (empleado == null)
                    return NotFound("No encontrado");

                var model = new Empleado()
                {
                    Idempleado = empleadoDTO.Idempleado,
                    Idcargo = cargo!.Idcargo,
                    Nombre = empleadoDTO.Nombre,
                    Edad = empleadoDTO.Edad,
                    Salario = empleadoDTO.Salario
                };

                _context.Entry(empleado).CurrentValues.SetValues(model);

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
                var empleadoDTO = await _context.Empleados.FindAsync(id);

                if (empleadoDTO == null)
                    return NotFound("No encontrado");

                _context.Empleados.Remove(empleadoDTO);
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
