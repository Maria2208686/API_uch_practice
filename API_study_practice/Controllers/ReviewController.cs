using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public ReviewController(studypracticeContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Review> reviews = Context.Reviews.ToList();
            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Review review = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (review == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(review);

        }

        [HttpPost]
        public IActionResult Add(Review review)
        {
            Context.Reviews.Add(review);
            Context.SaveChanges();
            return Ok(review);

        }

        [HttpPut]
        public IActionResult Update(Review review)
        {
            Context.Reviews.Update(review);
            Context.SaveChanges();
            return Ok(review);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Review review = Context.Reviews.Where(x => x.ReviewId == id).FirstOrDefault();
            if (review == null)
            {
                return BadRequest("Not Found");
            }
            Context.Reviews.Remove(review);
            Context.SaveChanges();
            return Ok(review);
        }
    }
}
