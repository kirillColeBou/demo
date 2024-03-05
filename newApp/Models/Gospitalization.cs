using System.ComponentModel.DataAnnotations.Schema;

namespace newApp.Models
{
    public class Gospitalization
    {
        public int Id { get; set; }
        public int PatientsId { get; set; }
        public virtual Patients Patients { get; set; }
        public int CodeGospitalization { get; set; }
        public DateTime DateGospitalization { get; set; }
        public string Diagnosis { get; set; }
        public string PurposeGospitalization { get; set; }
        public string Department { get; set; }
        public bool Conditions { get; set; }
        public string TermGospitalization { get; set; }
        public string AdditionalInformation { get; set; }
      
        [NotMapped]
        public List<Patients> PatientsIds { get; set; }
    }
}
