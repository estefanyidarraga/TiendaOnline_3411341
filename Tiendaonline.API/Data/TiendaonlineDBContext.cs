using Microsoft.EntityFrameworkCore;
using Tiendaonline.API.Models;

namespace Tiendaonline.API.Data
{
    public class TiendaonlineDBContext : DbContext
    {
        public TiendaonlineDBContext(DbContextOptions<TiendaonlineDBContext> options) 
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Metodospago> Metodospago { get; set; }
    }
}