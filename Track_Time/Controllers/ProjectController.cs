using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Track_Time.EF;
using Track_Time.Models;

namespace Track_Time.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        ContextData db = new ContextData();
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjects()
        {
            return await db.Projects.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectById(int id)
        {
            Project project = await db.Projects.FirstOrDefaultAsync(x => x.Id == id);
            if (project == null)
                return NotFound();
            return new ObjectResult(project);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Project>> DeleteProjectById(int id)
        {
            Project project = db.Projects.FirstOrDefault(x => x.Id == id);
            if (project == null)
            {
                return NotFound();
            }
            db.Projects.Remove(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
        [HttpPut]
        public async Task<ActionResult<Project>> UpdateProject(int id, [FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }
            if (!db.Projects.Any(x => x.Id == project.Id))
            {
                return NotFound();
            }

            db.Update(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
        [HttpPost]
        public async Task<ActionResult<Project>> CreateProject([FromBody] Project project)
        {
            if (project == null)
            {
                return BadRequest();
            }

            db.Projects.Add(project);
            await db.SaveChangesAsync();
            return Ok(project);
        }
    }
}
