namespace ClinicFlow_Blazor.Models
{
    public class MedicalAppointment
    {

        public int AppointmentId { get; set; }
        public int DoctorId {  get; set; }
        public Doctor? Doctor { get; set; }

        public int PatientId { get; set; }
        public Patient? Patient { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public string? Diagnosis { get; set; }
    }
}
