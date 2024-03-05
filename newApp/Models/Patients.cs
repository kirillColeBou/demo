using QRCoder;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace newApp.Models
{
    public class Patients
    {
        public int Id { get; set; }
        [Required]
        [Display(Name ="Изображение")]
        public byte[] Photo { get; set; }
        [Required]
        public string Firstname { get; set; } = "";
        [Required]
        public string Lastname { get; set; } = "";
        [Required]
        public string Surname { get; set; } = "";
        [Required]
        [MaxLength(12)]
        public string NumberPassport { get; set; } = "";
        [Required]
        public DateTime DateBirth { get; set; }
        [Required]
        public bool Female { get; set; } = false;
        [Required]
        public string Address { get; set; } = "";
        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; } = "";
        [Required]
        public string Email { get; set; } = "";

        public Guid NumberMedicalCard { get; set; } =Guid.NewGuid();
        [Required]
        public DateTime DateIssueMedicalCard { get; set; }
        [Required]
        public DateTime DateAppeal { get; set; }
        [Required]
        public DateTime DateNextVisit { get; set; }
        [Required]
        [MaxLength(30)]
        public string NumberPolicy { get; set; } = "";
        [Required]
        public DateTime DateExpiration { get; set; }
        [Required]
        public string Diagnosis { get; set; } = "";
        private IFormFile? formFile;
        [NotMapped]
        public IFormFile? ImageFile
        {
            get {
                return formFile;
            }
            set
            {
                formFile = value;
                MemoryStream stream = new MemoryStream();
                formFile.CopyTo(stream);
                Photo = stream.ToArray();

            }
        }
        [NotMapped]
        public byte[]? QrCode { get; set; }


        public void CreateQr()
        {
            QRCoder.QRCodeGenerator generator = new QRCoder.QRCodeGenerator();
            var data = generator.CreateQrCode(Encoding.UTF8.GetBytes((NumberMedicalCard.ToString())), QRCodeGenerator.ECCLevel.L);
            QRCoder.BitmapByteQRCode abstractQRCode = new QRCoder.BitmapByteQRCode(data);
            QrCode = abstractQRCode.GetGraphic(20);
        }
        public string GetFullName() => $"{Lastname} {Firstname} {Surname}";
        
        public virtual List<MedicalHistory> MedicalHistory { get; set; } = new();
    }
}
