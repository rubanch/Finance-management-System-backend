using System.ComponentModel.DataAnnotations;

namespace EMI_cards_2.Models
{
    public class EMIcardModels
    {
        [Key]
        public int Id { get; set; }
        public string number { get; set; }
        public string expiry {  get; set; }
        public string CVC {  get; set; }
        public string name {  get; set; }
        public string card_Amount {  get; set; }

    }
}
