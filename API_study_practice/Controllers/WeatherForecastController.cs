using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Extensions;

namespace API_study_practice.Controllers
{

    public class WeatherData
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public int Degree { get; set; }
        public string Location { get; set; }
    }

    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new()
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public static List<WeatherData> weatherDatas = new()
        {
            new WeatherData() { Id = 1, Date = "21.01.2022", Degree = 10, Location = "Murmansk" },
            new WeatherData() { Id = 23, Date = "10.08.2019", Degree = 20, Location = "Perm`" },
            new WeatherData() { Id = 24, Date = "05.11.2020", Degree = 15, Location = "Omsk" },
            new WeatherData() { Id = 25, Date = "07.02.2021", Degree = 0, Location = "Tomsk" },
            new WeatherData() { Id = 30, Date = "30.05.2022", Degree = 3, Location = "Kaliningrad" },
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<WeatherData> GetAll()
        {
            return weatherDatas;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            for (int i = 0; i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == id)
                {
                    return Ok(weatherDatas[i]);
                }
            }
            return BadRequest("Not Found");
        }

        [HttpPost]
        public IActionResult Add(WeatherData data)
        {
            for(int i = 0;i < weatherDatas.Count;i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    return BadRequest("Try another id");
                }

            }
            weatherDatas.Add(data);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(WeatherData data)
        {
            for(int i =0;i < weatherDatas.Count; i++)
            {
                if (weatherDatas[i].Id == data.Id)
                {
                    weatherDatas[i] = data;
                    return Ok();
                }
            }
            return BadRequest("Not Found");
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            for (int i = 0;i<weatherDatas.Count; ++i)
            {
                if (weatherDatas[i].Id == id)
                {
                    weatherDatas.RemoveAt(i);
                    return Ok();
                }
            }
            return BadRequest("Not Found");
        }

        [HttpGet]
        public List<string> Get()
        { 
            return Summaries;
        }

        [HttpPost]
        public IActionResult Add(string name)
        {
            Summaries.Add(name);
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int index, string name)
        {
            if (index < 0 || index >= Summaries.Count)
            {
                return BadRequest("Wrong index");
            }
            
            Summaries[index] = name;
            return Ok();
        }

       

        
    }
}
