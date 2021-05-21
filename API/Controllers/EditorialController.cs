using BLL;
using ENTITIES.DbConn;
using ENTITIES.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EditorialController : ControllerBase
    {
        private EditorialBLL editorialBLL = new EditorialBLL();

        // GET: api/Editorial
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EditorialMODEL>>> GetEditorial()
        {
            var resultProcess = await editorialBLL.GetAllAsync();
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if (resultProcess.ObjectResult.Count == 0)
            {
                return NoContent();
            }

            return (List<EditorialMODEL>)resultProcess.ObjectResult;
        }

        // GET: api/Editorial/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EditorialMODEL>> GetEditorial(int id)
        {
            var resultProcess = await editorialBLL.GetAsync(id);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if ((EditorialMODEL)resultProcess.ObjectResult == null)
            {
                return NotFound();
            }

            return (EditorialMODEL)resultProcess.ObjectResult;
        }

        // PUT: api/Editorial/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEditorial(int id, EditorialMODEL model)
        {
            if (id != model.IdEditorial)
            {
                return BadRequest();
            }

            var resultProcess = await editorialBLL.UpdateAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // POST: api/Editorial
        [HttpPost]
        public async Task<ActionResult<EditorialMODEL>> PostEditorial(EditorialMODEL model)
        {
            var resultProcess = await editorialBLL.InsertAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // DELETE: api/Editorial/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEditorial(int id)
        {
            var resultProcess = await editorialBLL.DeleteAsync(id);
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
