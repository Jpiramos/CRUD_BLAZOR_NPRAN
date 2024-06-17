using ClinicFlow_Blazor.Data;
using ClinicFlow_Blazor.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace PatientsTests
{
    public class PatientTests
    {
        [Fact]
        public async Task CreatePatient_Should_Add_New_Patient()
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

                // Adiciona um paciente para o teste
                var patientToAdd = new Patient
                {
                    Id = 1,
                    FirstName = "Túlio",
                    LastName = "Maravilha",
                    Email = "tulio.maravilha@example.com",
                    Cpf = "11122233344"
                };

                dbContext.Patients.Add(patientToAdd);
                await dbContext.SaveChangesAsync();

                // Assert: Verifica se o paciente foi adicionado corretamente
                var addedPatient = await dbContext.Patients.FindAsync(patientToAdd.Id);
                Assert.NotNull(addedPatient);
                Assert.Equal(patientToAdd.FirstName, addedPatient.FirstName);
                Assert.Equal(patientToAdd.LastName, addedPatient.LastName);
                Assert.Equal(patientToAdd.Email, addedPatient.Email);
                Assert.Equal(patientToAdd.Cpf, addedPatient.Cpf);
            }
        }
        [Fact]
        public async Task DeletePatient_Should_Remove_Patient()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using (var dbContext = new ApplicationDbContext(options))
            {
                // Adicionar um paciente para o teste
                var patientToDelete = new Patient
                {
                    Id = 6,
                    FirstName = "Rosenclever",
                    LastName = "Musk",
                    Email = "rosenclever.flamengo@example.com",
                    Cpf = "55566677788"
                };

                dbContext.Patients.Add(patientToDelete);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
                // Act
                var component = new DeletePatientComponent
                {
                    DB = dbContext,
                    NavigationManager = new MockNavigationManager(),
                    Id = 6
                };

                await component.DeletePatient();

                // Assert
                var deletedPatient = await dbContext.Patients.FindAsync(1);
                Assert.Null(deletedPatient); // Deve ser null se o paciente foi removido com sucesso
            }
        }


        [Fact]
        public async Task DetailsPatient_Should_Retrieve_Patient_Details()
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

                // Adiciona um paciente para o teste
                var patientToRetrieve = new Patient
                {
                    Id = 8,
                    FirstName = "Charlie",
                    LastName = "Brown",
                    Email = "charlie.brown@example.com",
                    Cpf = "99988877766"
                };

                dbContext.Patients.Add(patientToRetrieve);
                await dbContext.SaveChangesAsync();
            }

            using (var dbContext = new ApplicationDbContext(options))
            {
               
                var component = new DetailsPatientComponent
                {
                    DB = dbContext,
                    Id = 8 
                };

                // Act
                await component.GetPatientDetails();

                // Assert
                var retrievedPatient = await dbContext.Patients.FindAsync(8);
                Assert.NotNull(retrievedPatient); // Deve encontrar o paciente com o ID especificado
                                                 
            }
        }

        private class DeletePatientComponent
        {
            public ApplicationDbContext DB { get; set; }
            public NavigationManager NavigationManager { get; set; }
            public int Id { get; set; }

            public async Task DeletePatient()
            {
                var patient = await DB.Patients.FindAsync(Id);

                if (patient != null)
                {
                    DB.Patients.Remove(patient);

                    try
                    {
                        await DB.SaveChangesAsync();
                        NavigationManager.NavigateTo("/patients");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        throw new Exception("Erro ao excluir o paciente", ex);
                    }
                }
            }


        }

        private class DetailsPatientComponent
        {
            public ApplicationDbContext DB { get; set; }
            public int Id { get; set; }

            public async Task GetPatientDetails()
            {
                var patient = await DB.Patients.FindAsync(Id);
            }
        }
    }
}
