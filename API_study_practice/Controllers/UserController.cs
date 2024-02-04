using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    


    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public UserController(studypracticeContext context)
        {
            Context = context;
        }

        

        [HttpGet]
        public IActionResult GetAll()
        {
            List<User> users = Context.Users.ToList();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id) 
        {
            User user = Context.Users.Where(x => x.UserId == id).FirstOrDefault(); 
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(user);

        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            Context.Users.Add(user); 
            Context.SaveChanges();
            return Ok(user);

        }

        [HttpPut]
        public IActionResult Update(User user) 
        {
           Context.Users.Update(user);
            Context.SaveChanges();
            return Ok(user);
        }

        [HttpDelete]
        public IActionResult Delete(int id) 
        {
            User user = Context.Users.Where(x =>x.UserId == id).FirstOrDefault();
            if (user == null)
            {
                return BadRequest("Not Found");
            }
            Context.Users.Remove(user);
            Context.SaveChanges();
            return Ok(user);
        }
    }
}
