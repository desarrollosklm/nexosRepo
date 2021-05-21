using BLL;
using ENTITIES.DbModels;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private AuthorBLL authorBLL = new AuthorBLL();

        // GET: api/Author
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorMODEL>>> GetAuthor()
        {
            var resultProcess = await authorBLL.GetAllAsync();
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if (resultProcess.ObjectResult.Count == 0)
            {
                return NoContent();
            }

            return (List<AuthorMODEL>)resultProcess.ObjectResult;
        }

        // GET: api/Author/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorMODEL>> GetAuthor(int id)
        {
            var resultProcess = await authorBLL.GetAsync(id);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if ((AuthorMODEL)resultProcess.ObjectResult == null)
            {
                return NotFound();
            }

            return (AuthorMODEL)resultProcess.ObjectResult;
        }

        // PUT: api/Author/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorMODEL model)
        {
            if (id != model.IdAuthor)
            {
                return BadRequest();
            }

            var resultProcess = await authorBLL.UpdateAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // POST: api/Author
        [HttpPost]
        public async Task<ActionResult<Author>> PostAuthor(AuthorMODEL model)
        {
            var resultProcess = await authorBLL.InsertAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // DELETE: api/Author/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var resultProcess = await authorBLL.DeleteAsync(id);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }
        
    }
}
