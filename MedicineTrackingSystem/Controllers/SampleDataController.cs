using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalTrackingSystemProviders;
using Microsoft.AspNetCore.Mvc;

namespace MedicineTrackingSystem.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private static string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
        }

        private readonly ApiContext _context;

        public SampleDataController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Get()
        {
            var users =  _context.Medicines;
               

            var response = users.Select(u => new Medicine
            {
                Brand = u.Brand,
                ExpirayDate = u.ExpirayDate,
                MedicineName = u.MedicineName,
                Notes = u.Notes,
                Price = u.Price,
                Quantity = u.Quantity
            });

            return Ok(response);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> GetSelected(string MedicineName)
        {
            var users = _context.Medicines;


            var response = users.Select(u => new Medicine
            {
                Brand = u.Brand,
                ExpirayDate = u.ExpirayDate,
                MedicineName = u.MedicineName,
                Notes = u.Notes,
                Price = u.Price,
                Quantity = u.Quantity
            });

            var response1 = response.Where(medicine => medicine.MedicineName == MedicineName);

            return Ok(response1);
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
