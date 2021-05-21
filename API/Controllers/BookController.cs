using BLL;
using ENTITIES.DbConn;
using ENTITIES.DbModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private BookBLL bookBLL = new BookBLL();

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookMODEL>>> GetBook()
        {
            var resultProcess = await bookBLL.GetAllAsync();
            if(!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if (resultProcess.ObjectResult.Count == 0)
            {
                return NoContent();
            }

            return (List<BookMODEL>)resultProcess.ObjectResult;
        }

        // GET: api/Book/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookMODEL>> GetBook(int id)
        {
            var resultProcess = await bookBLL.GetAsync(id);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            if ((BookMODEL)resultProcess.ObjectResult == null)
            {
                return NotFound();
            }

            return (BookMODEL)resultProcess.ObjectResult;
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook(int id, BookMODEL model)
        {
            if (id != model.IdBook)
            {
                return BadRequest();
            }

            var resultProcess = await bookBLL.UpdateAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // POST: api/Book
        [HttpPost]
        public async Task<IActionResult> PostBook(BookMODEL model)
        {
            var resultProcess = await bookBLL.InsertAsync(model);
            if (!resultProcess.IsApproved)
            {
                return BadRequest(resultProcess.ShortMessage);
            }
            else
            {
                return Ok(resultProcess.ObjectResult);
            }
        }

        // DELETE: api/Book/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {

            var resultProcess = await bookBLL.DeleteAsync(id);
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
