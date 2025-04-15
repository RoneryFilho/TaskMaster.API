using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskMaster.API.Data;
using TaskMaster.API.Models;

namespace TaskMaster.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly TaskContext _context;

        public TasksController(TaskContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItem>>> GetTasks(string? priority = null, DateTime? date = null)
        {
            var query = _context.Tasks.AsQueryable();

            if (!string.IsNullOrEmpty(priority))
                query = query.Where(t => t.Priority == priority);

            if (date.HasValue)
                query = query.Where(t => t.DateTime.Date == date.Value.Date);

            return await query.OrderBy(t => t.DateTime).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();
            return task;
        }

        [HttpPost]
        public async Task<ActionResult<TaskItem>> CreateTask(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest();

            _context.Entry(task).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return NotFound();

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
