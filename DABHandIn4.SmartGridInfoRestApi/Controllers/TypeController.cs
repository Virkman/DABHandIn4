using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DABHandIn4.SmartGridInfoRestApi;
using DABHandIn4.SmartGridInfoRestApi.Entities;
using Type = DABHandIn4.SmartGridInfoRestApi.Entities.Type;

namespace DABHandIn4.SmartGridInfoRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Type")]
    public class TypeController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();
        private ApplicationDbContext _context;

        public TypeController()
        {
            _context = fac.db;
        }

        // GET: api/Type
        [HttpGet]
        public IEnumerable<Type> GetType()
        {
            return _context.Type;
        }

        // GET: api/Type/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @type = await _context.Type.SingleOrDefaultAsync(m => m.TypeId == id);

            if (@type == null)
            {
                return NotFound();
            }

            return Ok(@type);
        }

        // PUT: api/Type/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutType([FromRoute] long id, [FromBody] Type @type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @type.TypeId)
            {
                return BadRequest();
            }

            _context.Entry(@type).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Type
        [HttpPost]
        public async Task<IActionResult> PostType([FromBody] Type @type)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Type.Add(@type);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetType", new { id = @type.TypeId }, @type);
        }

        // DELETE: api/Type/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @type = await _context.Type.SingleOrDefaultAsync(m => m.TypeId == id);
            if (@type == null)
            {
                return NotFound();
            }

            _context.Type.Remove(@type);
            await _context.SaveChangesAsync();

            return Ok(@type);
        }

        private bool TypeExists(long id)
        {
            return _context.Type.Any(e => e.TypeId == id);
        }
    }
}