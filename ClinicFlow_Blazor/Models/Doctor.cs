namespace ClinicFlow_Blazor.Models
{
    public class Doctor : Person
    {
        public string? Specialty {  get; set; }

        public ICollection<MedicalAppointment>? Appointments { get; set; }
    }
}
