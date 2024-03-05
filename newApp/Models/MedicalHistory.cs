using System.ComponentModel.DataAnnotations;

namespace newApp.Models
{
    public class MedicalHistory
    {
        public int Id { get; set; }
        public string NameDiagnosis { get; set; } = "";
        public DateTime DateIllness { get; set; }

        public int PatientsId { get; set; }
        public virtual Patients Patients { get; set; }
    }
}
