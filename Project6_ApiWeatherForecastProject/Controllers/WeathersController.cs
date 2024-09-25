using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project6_ApiWeatherForecastProject.Entities;

namespace Project6_ApiWeatherForecastProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeathersController : ControllerBase
    {
        WeatherContext context = new WeatherContext();

        [HttpGet]
        public IActionResult WeatherCityList()
        {
            var values = context.Cities.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateWeatherCity(City city)
        {
            context.Cities.Add(city);
            context.SaveChanges();
            return Ok("Hava durumu eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteWeatherCity(int id)
        {
            var value = context.Cities.Find(id);
            context.Cities.Remove(value);
            context.SaveChanges();
            return Ok("Silme işlemi başarıyla gerçekleştirildi");
        }

        [HttpPut]
        public IActionResult UpdateWeatherCity(City city)
        {
            var value = context.Cities.Find(city.Id);
            value.Name = city.Name;
            value.Temprature = city.Temprature;
            value.Country = city.Country;
            value.Detail = city.Detail;
            context.Cities.Update(value);
            context.SaveChanges();
            return Ok("Güncelleme işlemi başarıyla gerçekleştirildi");
        }

        [HttpGet("id")]
        public IActionResult GetByIdWeatherCityList(int id)
        {
            var values = context.Cities.Find(id);
            return Ok(values);
        }

        [HttpGet("totalCityCount")]
        public IActionResult TotalCityCount()
        {
            var values = context.Cities.Count();
            return Ok(values);
        }

        [HttpGet("maxTempratureCity")]
        public IActionResult MaxTempratureCity()
        {
            var values = context.Cities.OrderByDescending(x=>x.Temprature).Select(y => y.Name).FirstOrDefault();
            return Ok(values);
        }

        [HttpGet("minTempratureCity")]
        public IActionResult MinTempratureCity()
        {
            var values = context.Cities.OrderBy(x => x.Temprature).Select(y => y.Name).FirstOrDefault();
            return Ok(values);
        }
    }
}
