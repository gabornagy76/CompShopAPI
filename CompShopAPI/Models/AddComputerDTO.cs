using System.ComponentModel.DataAnnotations;

namespace CompShopAPI.Models
{
    public class AddComputerDTO
    {
        // VARCHAR(50) - gyártó
        [MaxLength(50)]
        public string Brand { get; set; }

        // Típus
        [MaxLength(150)]
        public string Type { get; set; }

        // Képátló
        public double Display { get; set; }
    }
}
