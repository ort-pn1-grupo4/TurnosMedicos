using Microsoft.EntityFrameworkCore;
using Turnos.Models;

namespace Turnos.Context
{
    public class TurnosDbContext: DbContext
    {
        public TurnosDbContext(DbContextOptions<TurnosDbContext> options) : base(options)
        {

        }

        public DbSet<Medico> Medicos { get; set; } 
    }
}
