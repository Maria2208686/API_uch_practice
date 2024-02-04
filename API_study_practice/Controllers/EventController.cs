using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public EventController(studypracticeContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Event> ivents = Context.Events.ToList();
            return Ok(ivents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Event ivent = Context.Events.Where(x => x.EventId == id).FirstOrDefault();
            if (ivent == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(ivent);

        }

        [HttpPost]
        public IActionResult Add(Event ivent)
        {
            Context.Events.Add(ivent);
            Context.SaveChanges();
            return Ok(ivent);

        }

        [HttpPut]
        public IActionResult Update(Event ivent)
        {
            Context.Events.Update(ivent);
            Context.SaveChanges();
            return Ok(ivent);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Event ivent = Context.Events.Where(x => x.EventId == id).FirstOrDefault();
            if (ivent == null)
            {
                return BadRequest("Not Found");
            }
            Context.Events.Remove(ivent);
            Context.SaveChanges();
            return Ok(ivent);
        }
    }
}
