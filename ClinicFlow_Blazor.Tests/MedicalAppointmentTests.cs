
using ClinicFlow_Blazor.Data;
using ClinicFlow_Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace MedicalAppointmentsTests
{
    public class MedicalAppointmentTests
    {
        [Fact]
        public async Task AddMedicalAppointment_Should_Create_New_MedicalAppointment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var doctor = new Doctor { Id = 1, FirstName = "João Pedro", LastName = "Ramos" };
                var patient = new Patient { Id = 1, FirstName = "Lucas", LastName = "Andrade" };

                dbContext.Doctors.Add(doctor);
                dbContext.Patients.Add(patient);
                await dbContext.SaveChangesAsync();
            }

            var component = new MedicalAppointmentComponent
            {
                ApplicationDbContext = new ApplicationDbContext(options),
                NavigationManager = new MockNavigationManager(),
            };

            component.medicalappointment = new MedicalAppointment
            {
                DoctorId = 1,
                PatientId = 1,
                AppointmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                Diagnosis = "Virose",
            };

            // Act
            await component.AddMedicalAppointment();

            // Assert
            using (var assertContext = new ApplicationDbContext(options))
            {
                var savedAppointment = await assertContext.MedicalAppointments.FirstOrDefaultAsync();
                Assert.NotNull(savedAppointment);
                Assert.Equal(1, savedAppointment.DoctorId);
                Assert.Equal(1, savedAppointment.PatientId);
                Assert.Equal(component.medicalappointment.AppointmentDate, savedAppointment.AppointmentDate);
                Assert.Equal(component.medicalappointment.Diagnosis, savedAppointment.Diagnosis);
            }
        }

        [Fact]
        public async Task DeleteMedicalAppointment_Should_Remove_MedicalAppointment()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var doctor = new Doctor { Id = 1, FirstName = "Rosenclever", LastName = "Gazoni" };
                var patient = new Patient { Id = 1, FirstName = "Caio", LastName = "Vieira" };
                var appointment = new MedicalAppointment
                {
                    DoctorId = 1,
                    PatientId = 1,
                    AppointmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                    Diagnosis = "Dengue",
                };

                dbContext.Doctors.Add(doctor);
                dbContext.Patients.Add(patient);
                dbContext.MedicalAppointments.Add(appointment);
                await dbContext.SaveChangesAsync();
            }

            var component = new MedicalAppointmentComponent
            {
                ApplicationDbContext = new ApplicationDbContext(options),
                NavigationManager = new MockNavigationManager(),
            };

            component.DoctorId = 1;

            // Act
            await component.DeleteMedicalAppointment();

            // Assert
            using (var assertContext = new ApplicationDbContext(options))
            {
                var deletedAppointment = await assertContext.MedicalAppointments.FirstOrDefaultAsync();
                Assert.Null(deletedAppointment);
            }
        }

        [Fact]
        public async Task DetailsMedicalAppointment_Should_Retrieve_MedicalAppointment_Details()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                var doctor = new Doctor { Id = 1, FirstName = "Glauter", LastName = "Gates" };
                var patient = new Patient { Id = 1, FirstName = "Elon", LastName = "Mosquete" };
                var appointment = new MedicalAppointment
                {
                    DoctorId = 1,
                    PatientId = 1,
                    AppointmentDate = DateOnly.FromDateTime(DateTime.Now.AddDays(7)),
                    Diagnosis = "Consulta inicial",
                };

                dbContext.Doctors.Add(doctor);
                dbContext.Patients.Add(patient);
                dbContext.MedicalAppointments.Add(appointment);
                await dbContext.SaveChangesAsync();
            }

            var component = new MedicalAppointmentComponent
            {
                ApplicationDbContext = new ApplicationDbContext(options),
                NavigationManager = new MockNavigationManager(),
                DoctorId = 1,
            };

            // Act
            await component.OnInitializedAsync();

            // Assert
            Assert.NotNull(component.medicalappointment);
            Assert.Equal(1, component.DoctorId);
            Assert.Equal("Consulta inicial", component.medicalappointment.Diagnosis);
           

        }
    }

    public class MedicalAppointmentComponent
    {
        public ApplicationDbContext ApplicationDbContext { get; set; }
        public NavigationManager NavigationManager { get; set; }

        public MedicalAppointment medicalappointment { get; set; } = new MedicalAppointment();

        public int DoctorId { get; set; } // Parâmetro de consulta para detalhes

        public async Task AddMedicalAppointment()
        {
            ApplicationDbContext.MedicalAppointments.Add(medicalappointment);
            await ApplicationDbContext.SaveChangesAsync();
            NavigationManager.NavigateTo("/medicalappointments");
        }

        public async Task DeleteMedicalAppointment()
        {
            var appointmentToDelete = await ApplicationDbContext.MedicalAppointments.FindAsync(DoctorId);
            if (appointmentToDelete != null)
            {
                ApplicationDbContext.MedicalAppointments.Remove(appointmentToDelete);
                await ApplicationDbContext.SaveChangesAsync();
            }
            NavigationManager.NavigateTo("/medicalappointments");
        }

        public async Task OnInitializedAsync()
        {
            medicalappointment = await ApplicationDbContext.MedicalAppointments
                .Include(m => m.Doctor)
                .Include(m => m.Patient)
                .FirstOrDefaultAsync(m => m.DoctorId == DoctorId);
        }
    }

    public class MockNavigationManager : NavigationManager
    {
        public MockNavigationManager()
        {
            Initialize("http://localhost/", "http://localhost/");
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
           
        }
    }
}

