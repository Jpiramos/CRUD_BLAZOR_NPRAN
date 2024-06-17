using ClinicFlow_Blazor.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicFlow_Blazor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<MedicalAppointment> MedicalAppointments { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MedicalAppointment>()
                .HasKey(ma => ma.AppointmentId); // Define uma chave primária composta

            modelBuilder.Entity<MedicalAppointment>()
                .HasOne(ma => ma.Doctor)
                .WithMany(d => d.Appointments)
                .HasForeignKey(ma => ma.DoctorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<MedicalAppointment>()
                .HasOne(ma => ma.Patient)
                .WithMany(p => p.Appointments)
                .HasForeignKey(ma => ma.PatientId)
                .OnDelete(DeleteBehavior.Cascade);
        }


    }
}
