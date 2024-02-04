using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public ToDoListController(studypracticeContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<ToDoList> toDoLists = Context.ToDoLists.ToList();
            return Ok(toDoLists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            ToDoList toDoList = Context.ToDoLists.Where(x => x.ToDoId == id).FirstOrDefault();
            if (toDoList == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(toDoList);

        }

        [HttpPost]
        public IActionResult Add(ToDoList toDoList)
        {
            Context.ToDoLists.Add(toDoList);
            Context.SaveChanges();
            return Ok(toDoList);

        }

        [HttpPut]
        public IActionResult Update(ToDoList toDoList)
        {
            Context.ToDoLists.Update(toDoList);
            Context.SaveChanges();
            return Ok(toDoList);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            ToDoList toDoList = Context.ToDoLists.Where(x => x.ToDoId == id).FirstOrDefault();
            if (toDoList == null)
            {
                return BadRequest("Not Found");
            }
            Context.ToDoLists.Remove(toDoList);
            Context.SaveChanges();
            return Ok(toDoList);
        }
    }
}
