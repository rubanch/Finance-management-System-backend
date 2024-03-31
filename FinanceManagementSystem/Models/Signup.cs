using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Signup
    {
        [Key]
        public int Id {get;set;}
        public string?  Firstname { get; set; }
        [Required]
        public string? Lastname {get; set;}
          [Required]
        public string? Email{ get; set; }
        [Required]
        public string? Password{get; set;}
    }
}