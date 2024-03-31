using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CartApi.Models
{
    public class CartDetails
    {
        [Key]
        public int id { get; set; }

        public string? title {  get; set; }

        public string? price {  get; set; }
        [NotMapped]
        public IFormFile? ProfileImage { get; set; }

        public string? UniqueFileName { get; set; } 

        public string? product_description {  get; set; }





    }
}
