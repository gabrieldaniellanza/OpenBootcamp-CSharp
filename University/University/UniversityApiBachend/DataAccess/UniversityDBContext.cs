using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
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

        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Student>? Students { get; set; }

        public DbSet<Charpter>? Charpters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Course>()
                .HasOne(course => course.Charpter)
                .WithOne(charpter => charpter.course)
                .HasForeignKey<Charpter>(charpter => charpter.CurseId);*/
        }

    }
}
