using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public PhotoController(studypracticeContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Photo> photos = Context.Photos.ToList();
            return Ok(photos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Photo photo = Context.Photos.Where(x => x.PhotoId == id).FirstOrDefault();
            if (photo == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(photo);

        }

        [HttpPost]
        public IActionResult Add(Photo photo)
        {
            Context.Photos.Add(photo);
            Context.SaveChanges();
            return Ok(photo);

        }

        [HttpPut]
        public IActionResult Update(Photo photo)
        {
            Context.Photos.Update(photo);
            Context.SaveChanges();
            return Ok(photo);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Photo photo = Context.Photos.Where(x => x.PhotoId == id).FirstOrDefault();
            if (photo == null)
            {
                return BadRequest("Not Found");
            }
            Context.Photos.Remove(photo);
            Context.SaveChanges();
            return Ok(photo);
        }
    }
}
