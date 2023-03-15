using Microsoft.EntityFrameworkCore;
using admissionapi.services.Entities;

namespace admissionapi.services.Data;

    public class AppDbContext: DbContext
    {
        public virtual DbSet<Admission> Admission { get; set; }
        public virtual DbSet<GardianInfo> GardianInfos { get; set; }
        public virtual DbSet<FatherInfo> FatherInfos { get; set; }
        public virtual DbSet<MotherInfo> MotherInfos { get; set; }
        public virtual DbSet<MariageStatus> MariageStatuses { get; set; }
        public virtual DbSet<EmergencyInfo> EmergencyInfos { get; set; }
        public virtual DbSet<StudentInfo> StudentInfos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
           builder.Entity<Admission>()
            .HasIndex(p => new { p.AdmissionIndex })
            .IsUnique(true);
            
            builder.Entity<GardianInfo>()
            .HasIndex(p => new { p.FirstName, p.SecondName, p.MiddleName, p.Surname })
            .IsUnique(true);

            builder.Entity<GardianInfo>()
            .HasIndex(p => new { p.Email })
            .IsUnique(true);

             builder.Entity<GardianInfo>()
            .HasIndex(p => new { p.PhoneOne })
            .IsUnique(true);

              builder.Entity<GardianInfo>()
            .HasIndex(p => new { p.PhoneTwo })
            .IsUnique(true);


             builder.Entity<FatherInfo>()
            .HasIndex(p => new { p.FirstName, p.SecondName, p.MiddleName, p.Surname })
            .IsUnique(true);

            builder.Entity<FatherInfo>()
            .HasIndex(p => new { p.Email })
            .IsUnique(true);

             builder.Entity<FatherInfo>()
            .HasIndex(p => new { p.PhoneOne })
            .IsUnique(true);

              builder.Entity<FatherInfo>()
            .HasIndex(p => new { p.PhoneTwo })
            .IsUnique(true);

            builder.Entity<MotherInfo>()
            .HasIndex(p => new { p.FullName })
            .IsUnique(true);

             builder.Entity<StudentInfo>()
            .HasIndex(p => new { p.Name, p.AdmId })
            .IsUnique(true);

            base.OnModelCreating(builder);
        }
    }

