namespace ClinicFlow_Blazor.Models
{
    public class Patient : Person
    {
        public ICollection<MedicalAppointment>? Appointments {  get; set; } 
    }
}
