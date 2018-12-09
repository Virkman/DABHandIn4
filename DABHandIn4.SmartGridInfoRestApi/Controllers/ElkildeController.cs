using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DABHandIn4.SmartGridInfoRestApi;
using DABHandIn4.SmartGridInfoRestApi.Entities;

namespace DABHandIn4.SmartGridInfoRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Elkilde")]
    public class ElkildeController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();
        private ApplicationDbContext _context;

        public ElkildeController()
        {
            _context = fac.db;
        }

        // GET: api/Elkilde
        [HttpGet]
        public IEnumerable<Elkilde> GetElkilde()
        {
            return _context.Elkilde;
        }

        // GET: api/Elkilde/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElkilde([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elkilde = await _context.Elkilde.SingleOrDefaultAsync(m => m.ElkildeId == id);

            if (elkilde == null)
            {
                return NotFound();
            }

            return Ok(elkilde);
        }

        // PUT: api/Elkilde/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElkilde([FromRoute] long id, [FromBody] Elkilde elkilde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elkilde.ElkildeId)
            {
                return BadRequest();
            }

            _context.Entry(elkilde).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElkildeExists(id))
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

        // POST: api/Elkilde
        [HttpPost]
        public async Task<IActionResult> PostElkilde([FromBody] Elkilde elkilde)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Elkilde.Add(elkilde);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElkilde", new { id = elkilde.ElkildeId }, elkilde);
        }

        // DELETE: api/Elkilde/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElkilde([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elkilde = await _context.Elkilde.SingleOrDefaultAsync(m => m.ElkildeId == id);
            if (elkilde == null)
            {
                return NotFound();
            }

            _context.Elkilde.Remove(elkilde);
            await _context.SaveChangesAsync();

            return Ok(elkilde);
        }

        private bool ElkildeExists(long id)
        {
            return _context.Elkilde.Any(e => e.ElkildeId == id);
        }
    }
}