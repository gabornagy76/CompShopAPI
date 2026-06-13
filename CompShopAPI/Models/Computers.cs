using System.ComponentModel.DataAnnotations;

namespace CompShopAPI.Models
{
    public class Computers
    {
        // Elsődleges kulcs, kell hozzá a DataAnnotations névtér. Nem kötelező, az EF automatikusan kikövetkezteti (ID névből, vagy az osztály nevével egyező mezőnévből)
        [Key]
        public int Id {  get; set; }

        // VARCHAR(50) - gyártó
        [MaxLength(50)]
        public string Brand { get; set; }

        // Típus
        [MaxLength(150)]
        public string Type { get; set; }

        // Képátló
        public double Display {  get; set; }

        // A rekord kreálásának ideje
        public DateTime CreatedAt { get; set; }

        // A rekord módosításának ideje
        public DateTime UpdatedAt { get; set; }
    }
}
