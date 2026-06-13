using Microsoft.EntityFrameworkCore;

namespace CompShopAPI.Models
{
    public class CompShopDBContext : DbContext
    {
        // Hozzunk létre egy paraméterek nélküli kontruktort
        public CompShopDBContext()
        {
        }

        // Konstruktor a lekédezésekhez
        public CompShopDBContext(DbContextOptions options) : base(options)
        { 
        }

        // Függvény a kapcsolat létrehozásához
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("SERVER=localhost;DATABASE=CompShop;Uid=root;PWD=");
        }
    }
}
