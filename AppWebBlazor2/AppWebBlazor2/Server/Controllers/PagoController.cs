using AppWebBlazor2.Server.Models;
using AppWebBlazor2.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AppWebBlazor2.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {

        private readonly Mydb2Context _context;

        public PagoController(Mydb2Context context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Listar")]
        public async Task<IActionResult> Listar()
        {
            var lista = new List<PagoDTO>();

            foreach (var item in await _context.Pagos.Include(p => p.IdempleadoNavigation).ToListAsync())
            {
                lista.Add(new PagoDTO
                {
                    Idpago = item.Idpago,
                    Empleado = new EmpleadoDTO
                    {
                        Idempleado = item.IdempleadoNavigation!.Idempleado,
                        Nombre = item.IdempleadoNavigation!.Nombre
                    },
                    Fechapago = item.Fechapago,
                    Totalpago = item.Totalpago,
                });
            }

            return Ok(lista);
        }

        [HttpPost]
        [Route("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] PagoDTO pagoDTO)
        {
            try
            {
                var pago = new Pago()
                {
                    Idpago = pagoDTO.Idpago,
                    Idempleado = pagoDTO.Empleado!.Idempleado,
                    Fechapago = pagoDTO.Fechapago,
                    Totalpago = pagoDTO.Totalpago
                };
                await _context.Pagos.AddAsync(pago);
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
        public async Task<IActionResult> Editar([FromRoute] int id, [FromBody] PagoDTO pagoDTO)
        {
            try
            {
                if (id != pagoDTO.Idpago)
                    return NotFound("No coincide");

                var pago = await _context.Pagos.FindAsync(id);

                if (pago == null)
                    return NotFound("No encontrado");

                var model = new Pago()
                {
                    Idpago = pagoDTO.Idpago,
                    Idempleado = pagoDTO.Empleado!.Idempleado,
                    Fechapago = pagoDTO.Fechapago,
                    Totalpago = pagoDTO.Totalpago
                };

                _context.Entry(pago).CurrentValues.SetValues(model);

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
                var pago = await _context.Pagos.FindAsync(id);

                if (pago == null)
                    return NotFound("No encontrado");

                _context.Pagos.Remove(pago);
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
