using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicFlow_Blazor.Migrations
{
    /// <inheritdoc />
    public partial class CASCADEFIX : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Doctors_DoctorId",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Doctors_DoctorId",
                table: "MedicalAppointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Doctors_DoctorId",
                table: "MedicalAppointments");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Doctors_DoctorId",
                table: "MedicalAppointments",
                column: "DoctorId",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalAppointments_Patients_PatientId",
                table: "MedicalAppointments",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
