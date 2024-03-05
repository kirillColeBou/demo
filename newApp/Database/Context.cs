using Microsoft.EntityFrameworkCore;
using newApp.Models;

namespace newApp.Database
{
    public class Context : DbContext
    {
        public DbSet<Patients> Patients { get; set; }
        public DbSet<MedicalHistory> MedicalHistory { get; set; }
        public DbSet<TypeEvent> TypeEvent { get; set; }
        public DbSet<TreatmentDiagnosticActivities> TreatmentDiagnosticActivities { get; set; }
        public DbSet<Gospitalization> Gospitalization { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseSqlServer("server=student.permaviat.ru;Trusted_Connection=No;DataBase=base1_ISP_21_2_23;User=ISP_21_2_23;PWD=3frQxZ83o#;");

        }
    }
}
