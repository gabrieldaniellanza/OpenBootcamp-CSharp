using Microsoft.EntityFrameworkCore;
using UniversityApiBachend.Models.DataModels;

namespace UniversityApiBachend.DataAccess
{
    public class UniversityDBContext : DbContext
    {
        public UniversityDBContext(DbContextOptions<UniversityDBContext> options) : base(options) { 
        
        }

        // TODO: agregar DBSETs (tablas de nuestra base de datos)
        public DbSet<User>? Users { get; set; }

        public DbSet<Curso>? Cursos { get; set; }
    }
}
