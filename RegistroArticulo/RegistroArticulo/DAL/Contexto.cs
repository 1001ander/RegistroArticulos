using Microsoft.EntityFrameworkCore;
using RegistroArticulo.Models;

namespace RegistroArticulo.DAL
{
    public class Contexto : DbContext { 
    
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }
        
        public DbSet<Articulos> Articulos { get; set; }
    }
}
