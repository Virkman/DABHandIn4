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
    [Route("api/SmartEnhed")]
    public class SmartEnhedController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();
        private ApplicationDbContext _context;

        public SmartEnhedController()
        {
            _context = fac.db;
        }

        // GET: api/SmartEnhed
        [HttpGet]
        public IEnumerable<SmartEnhed> GetSmartEnhed()
        {
            return _context.SmartEnhed;
        }

        // GET: api/SmartEnhed/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmartEnhed([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartEnhed = await _context.SmartEnhed.SingleOrDefaultAsync(m => m.SmartEnhedId == id);

            if (smartEnhed == null)
            {
                return NotFound();
            }

            return Ok(smartEnhed);
        }

        // PUT: api/SmartEnhed/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartEnhed([FromRoute] long id, [FromBody] SmartEnhed smartEnhed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartEnhed.SmartEnhedId)
            {
                return BadRequest();
            }

            _context.Entry(smartEnhed).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartEnhedExists(id))
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

        // POST: api/SmartEnhed
        [HttpPost]
        public async Task<IActionResult> PostSmartEnhed([FromBody] SmartEnhed smartEnhed)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmartEnhed.Add(smartEnhed);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartEnhed", new { id = smartEnhed.SmartEnhedId }, smartEnhed);
        }

        // DELETE: api/SmartEnhed/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartEnhed([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartEnhed = await _context.SmartEnhed.SingleOrDefaultAsync(m => m.SmartEnhedId == id);
            if (smartEnhed == null)
            {
                return NotFound();
            }

            _context.SmartEnhed.Remove(smartEnhed);
            await _context.SaveChangesAsync();

            return Ok(smartEnhed);
        }

        private bool SmartEnhedExists(long id)
        {
            return _context.SmartEnhed.Any(e => e.SmartEnhedId == id);
        }
    }
}