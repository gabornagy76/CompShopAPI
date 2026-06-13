using CompShopAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CompShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComputersController : ControllerBase
    {

        // Hogy tudjunk a végpontjainkon csatlakozni az adatbázishoz és a táblákon múűveleteket végezni:
        CompShopDBContext context = new CompShopDBContext();

        // Post végpont
        [HttpPost]
        public ActionResult AddNewComputer(AddComputerDTO dto)
        {
            try
            {
                var computerEgyed = new Computers
                {
                    Brand = dto.Brand,
                    Type = dto.Type,
                    Display = dto.Display,

                    // Meg kell adni ezesetben a timestamp mezőket is, hiszen azt most már nem az adatbázis kezeli.
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                // LINQ segítségével gyorsabban végezhetünk műveleteket bármilyen kollekción (listán):
                context.computers.Add(computerEgyed);

                context.SaveChanges();

                return StatusCode(201, new
                {
                    message = "Sikeres adatfelvitel!",
                    result = computerEgyed
                });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message,
                    belsoHiba = ex.InnerException?.Message
                });
            }
        }

        [HttpGet]
        public ActionResult GetAllComputers()
        {
            try
            {
                return StatusCode(200, new
                {
                    message = "Sikeres lekérdezés!",
                    // LINQ segítségével egy listává alakítva kérdezünk le:
                    result = context.computers.ToList()
                });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message,
                    belsoHiba = ex.InnerException?.Message
                });
            }
        }


        [HttpGet("{id}")]
        public ActionResult GetComputerById(int id)
        {
            try
            {
                // Az elsődleges kulcs keresésére szolgáló metódus a Find().
                var computer = context.computers.Find(id);

                if (computer == null)
                {
                    return NotFound(new
                    {
                        message = "A számítógép nem található!"
                    });
                }

                return Ok(new
                {
                    message = "Sikeres lekérdezés!",
                    result = computer
                });
            }
            catch (Exception ex)
            {
                return StatusCode(400, new
                {
                    message = ex.Message,
                    belsoHiba = ex.InnerException?.Message
                });
            }
        }

    }
}
