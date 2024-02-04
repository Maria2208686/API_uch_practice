using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public TripController(studypracticeContext context)
        {
            Context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Trip> trips = Context.Trips.ToList();
            return Ok(trips);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Trip trip = Context.Trips.Where(x => x.TripId == id).FirstOrDefault(); 
            if (trip == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(trip);

        }

        [HttpPost]
        public IActionResult Add(Trip trip)
        {
            Context.Trips.Add(trip);
            Context.SaveChanges();
            return Ok(trip);

        }

        [HttpPut]
        public IActionResult Update(Trip trip)
        {
            Context.Trips.Update(trip);
            Context.SaveChanges();
            return Ok(trip);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Trip trip = Context.Trips.Where(x => x.TripId == id).FirstOrDefault();
            if (trip == null)
            {
                return BadRequest("Not Found");
            }
            Context.Trips.Remove(trip);
            Context.SaveChanges();
            return Ok(trip);
        }
    }
}
