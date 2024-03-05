namespace newApp.Models
{
    public class TreatmentDiagnosticActivities
    {
        public int Id { get; set; }
        public int PatientsId { get; set; }
        public virtual Patients Patients { get; set; }
        public DateTime DateActivities { get; set; }
        public int TypeEventId { get; set; }
        public virtual TypeEvent TypeEvent { get; set; }
        public string NameActivities { get; set; }
        public string Result { get; set; }
        public string Recommendations { get; set; }
    }
}
