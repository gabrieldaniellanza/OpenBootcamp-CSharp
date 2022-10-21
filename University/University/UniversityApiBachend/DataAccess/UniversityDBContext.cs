using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.DataAccess
{
    public class UniversityDBContext : DbContext
    {

        private readonly ILoggerFactory _loggerFactory;

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            _loggerFactory = loggerFactory;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<UniversityDBContext>();
            // optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            // optionsBuilder.EnableSensitiveDataLogging();

            //optionsBuilder.LogTo(
            //    d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
            //    .EnableSensitiveDataLogging()
            //    .EnableDetailedErrors();

            optionsBuilder
                .LogTo(d => logger.Log(LogLevel.Warning, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Warning)
                .LogTo(d => logger.Log(LogLevel.Critical, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Critical)
                .LogTo(d => logger.Log(LogLevel.Error, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Error)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        }

    }
}
