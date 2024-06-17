namespace ClinicFlow_Blazor.DTO
{
    public class MedicalAppointmentDTO
    {
        public int DoctorId { get; set; }

        public int PacientId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public string? Diagnosis { get; set; }
    }
}
