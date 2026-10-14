using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pract4_97.Database;
using pract4_97.Database.Entities;
namespace pract4_97.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DatabaseContext db;
        public UserController(DatabaseContext context) { db = context; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Get() => await db.Users.ToListAsync();

        [HttpGet("{id:int}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = $"User with ID {id} was not found." });
            return Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Post([FromBody] User model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            db.Users.Add(model);
            await db.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = model.UserId }, model);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put(int id, [FromBody] User model)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = $"User with ID {id} was not found." });
            user.UserName = model.UserName;
            user.Address = model.Address;
            user.Contact = model.Contact;
            await db.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await db.Users.FindAsync(id);
            if (user == null) return NotFound(new { message = $"User with ID {id} was not found." });
            db.Users.Remove(user);
            await db.SaveChangesAsync();
            return NoContent();
        }
    }
}
