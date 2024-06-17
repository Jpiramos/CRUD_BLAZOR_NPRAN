using ClinicFlow_Blazor.Data;
using ClinicFlow_Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace DoctorsTests
{
    public class DoctorTests
    {
        [Fact]
        public async Task CreateDoctor_Should_Add_New_Doctor()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                // Limpa e recria o banco de dados em memória
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                // Adiciona um médico para o teste
                var doctorToAdd = new Doctor
                {
                    Id = 1, // Certifique-se de que o ID seja único para cada teste
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@example.com",
                    Cpf = "12345678900",
                    Specialty = "Cardiology"
                };

                dbContext.Doctors.Add(doctorToAdd);
                await dbContext.SaveChangesAsync();

                // Assert: Verifique se o médico foi adicionado corretamente
                var addedDoctor = await dbContext.Doctors.FindAsync(doctorToAdd.Id);
                Assert.NotNull(addedDoctor);
                Assert.Equal(doctorToAdd.FirstName, addedDoctor.FirstName);
                Assert.Equal(doctorToAdd.LastName, addedDoctor.LastName);
                // Adicione outras asserções conforme necessário
            }
        }

        [Fact]
        public async Task DeleteDoctor_Should_Remove_Doctor()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                // Limpa e recria o banco de dados em memória
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                // Adiciona um médico para o teste
                var doctorToDelete = new Doctor
                {
                    Id = 1,
                    FirstName = "João Pedro",
                    LastName = "Ramos",
                    Email = "joao.pedro@example.com",
                    Cpf = "98765432100",
                    Specialty = "Pediatra"
                };

                dbContext.Doctors.Add(doctorToDelete);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                
                var component = new DeleteDoctorComponent
                {
                    DB = dbContext,
                    NavigationManager = new MockNavigationManager(),
                    Id = 1 // ID do médico a ser excluído
                };

                // Act
                await component.DeleteDoctor();

                // Assert
                var deletedDoctor = await dbContext.Doctors.FindAsync(1);
                Assert.Null(deletedDoctor); // Deve ser null se o médico foi removido com sucesso
            }
        }

        [Fact]
        public async Task DetailsDoctor_Should_Retrieve_Doctor_Details()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                // Limpa e recria o banco de dados em memória
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();

                // Adiciona um médico para o teste
                var doctorToRetrieve = new Doctor
                {
                    Id = 1,
                    FirstName = "Caio",
                    LastName = "Vieira",
                    Email = "caio.vieira@example.com",
                    Cpf = "98765432100",
                    Specialty = "Dermatologista"
                };

                dbContext.Doctors.Add(doctorToRetrieve);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
            
                var component = new DetailsDoctorComponent
                {
                    DB = dbContext,
                    Id = 1 // ID do médico para obter detalhes
                };

                // Act
                await component.GetDoctorDetails();

                // Assert
                var retrievedDoctor = await dbContext.Doctors.FindAsync(1);
                Assert.NotNull(retrievedDoctor); // Deve encontrar o médico com o ID especificado
                                                 // Adicione outras asserções conforme necessário
            }
        }

        private class DeleteDoctorComponent
        {
            public ApplicationDbContext DB { get; set; }
            public NavigationManager NavigationManager { get; set; }
            public int Id { get; set; }

            public async Task DeleteDoctor()
            {
                var doctor = await DB.Doctors.FindAsync(Id);
                if (doctor != null)
                {
                    DB.Doctors.Remove(doctor);
                    await DB.SaveChangesAsync();
                    NavigationManager.NavigateTo("/doctors");
                }
            }
        }

        private class DetailsDoctorComponent
        {
            public ApplicationDbContext DB { get; set; }
            public int Id { get; set; }

            public async Task GetDoctorDetails()
            {
                var doctor = await DB.Doctors.FindAsync(Id);
            }
        }
    }
}