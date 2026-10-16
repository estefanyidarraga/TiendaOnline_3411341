using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tiendaonline.API.Data;
using Tiendaonline.API.Models;

namespace Tiendaonline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetodoPagoController : ControllerBase
    {
        private readonly TiendaonlineDBContext _context;

        public MetodoPagoController(TiendaonlineDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Metodospago>>> GetMetodosPago()
        {
            return await _context.Metodospago.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Metodospago>> GetMetodoPago(int id)
        {
            var metodo = await _context.Metodospago.FindAsync(id);

            if (metodo == null)
                return NotFound();

            return metodo;
        }

        [HttpPost]
        public async Task<ActionResult<Metodospago>> PostMetodoPago(Metodospago metodo)
        {
            _context.Metodospago.Add(metodo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetMetodoPago),
                new { id = metodo.IdMetodospago },
                metodo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMetodoPago(int id, Metodospago metodo)
        {
            if (id != metodo.IdMetodospago)
                return BadRequest();

            _context.Entry(metodo).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMetodoPago(int id)
        {
            var metodo = await _context.Metodospago.FindAsync(id);

            if (metodo == null)
                return NotFound();

            _context.Metodospago.Remove(metodo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}