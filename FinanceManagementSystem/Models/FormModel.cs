using System.ComponentModel.DataAnnotations;

namespace Form3final.Models
{
    public class FormModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Fullname { get; set; }
        [Required]
        public string? Date_of_birth { get; set; }
        [Required]

        public string? ContactNumber {  get; set; }

        [Required]
        public string? Email_Address { get; set; }
        [Required]
        public string? Current_Address { get; set; }

        [Required]
        public string? Permanent_Address { get; set; }

        [Required]
        public string? Nationality {  get; set; }
        [Required]
        public string? Gender { get; set; }

        [Required]
        public string? Select_card_type { get; set; }
        [Required]

        public string? PAN { get; set; }
    }

}

