using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Context
{
    public class LivrariaContext : DbContext
    {
        public LivrariaContext(DbContextOptions<LivrariaContext>options) : base(options) 
        {
            
      
        }
        public DbSet<Livros> Livros { get; set; }
    }
}
