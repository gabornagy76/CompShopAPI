using System.ComponentModel.DataAnnotations;

namespace CompShopAPI.Models
{
    public class UpdateComputerDTO
    {
        // Adjunk hozzá egy ID mezőt a modellhez, hogy body-ban tudjuk küldeni az értékét (ne a linkben)
        public int Id { get; set; }
        
        [MaxLength(50)]
        public string Brand { get; set; }
       
        [MaxLength(150)]
        public string Type { get; set; }
        
        public double Display { get; set; }
    }
}
