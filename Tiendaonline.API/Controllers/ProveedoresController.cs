using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tiendaonline.API.Data;
using Tiendaonline.API.Models;

namespace Tiendaonline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProveedoresController : ControllerBase
    {
        private readonly TiendaonlineDBContext _context;

        public ProveedoresController(TiendaonlineDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Proveedores>>> GetProveedores()
        {
            return await _context.Proveedores.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Proveedores>> GetProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
                return NotFound();

            return proveedor;
        }

        [HttpPost]
        public async Task<ActionResult<Proveedores>> PostProveedor(Proveedores proveedor)
        {
            _context.Proveedores.Add(proveedor);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetProveedor),
                new { id = proveedor.IdProveedor },
                proveedor);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProveedor(int id, Proveedores proveedor)
        {
            if (id != proveedor.IdProveedor)
                return BadRequest();

            _context.Entry(proveedor).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProveedor(int id)
        {
            var proveedor = await _context.Proveedores.FindAsync(id);

            if (proveedor == null)
                return NotFound();

            _context.Proveedores.Remove(proveedor);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}