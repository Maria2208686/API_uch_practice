using API_study_practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_study_practice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenseController : ControllerBase
    {
        public studypracticeContext Context { get; }

        public ExpenseController(studypracticeContext context)
        {
            Context = context;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            List<Expense> expenses = Context.Expenses.ToList();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Expense expense = Context.Expenses.Where(x => x.ExpenseId == id).FirstOrDefault();
            if (expense == null)
            {
                return BadRequest("Not Found");
            }
            return Ok(expense);

        }

        [HttpPost]
        public IActionResult Add(Expense expense)
        {
            Context.Expenses.Add(expense);
            Context.SaveChanges();
            return Ok(expense);

        }

        [HttpPut]
        public IActionResult Update(Expense expense)
        {
            Context.Expenses.Update(expense);
            Context.SaveChanges();
            return Ok(expense);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            Expense expense = Context.Expenses.Where(x => x.ExpenseId == id).FirstOrDefault();
            if (expense == null)
            {
                return BadRequest("Not Found");
            }
            Context.Expenses.Remove(expense);
            Context.SaveChanges();
            return Ok(expense);
        }
    }
}
