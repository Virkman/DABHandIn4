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
    [Route("api/SmartMeter")]
    public class SmartMeterController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();
        private ApplicationDbContext _context;

        public SmartMeterController()
        {
            _context = fac.db;
        }

        // GET: api/SmartMeter
        [HttpGet]
        public IEnumerable<SmartMeter> GetSmartMeter()
        {
            return _context.SmartMeter;
        }

        // GET: api/SmartMeter/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSmartMeter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartMeter = await _context.SmartMeter.SingleOrDefaultAsync(m => m.SmartMeterId == id);

            if (smartMeter == null)
            {
                return NotFound();
            }

            return Ok(smartMeter);
        }

        // PUT: api/SmartMeter/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSmartMeter([FromRoute] long id, [FromBody] SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != smartMeter.SmartMeterId)
            {
                return BadRequest();
            }

            _context.Entry(smartMeter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SmartMeterExists(id))
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

        // POST: api/SmartMeter
        [HttpPost]
        public async Task<IActionResult> PostSmartMeter([FromBody] SmartMeter smartMeter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.SmartMeter.Add(smartMeter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSmartMeter", new { id = smartMeter.SmartMeterId }, smartMeter);
        }

        // DELETE: api/SmartMeter/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSmartMeter([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var smartMeter = await _context.SmartMeter.SingleOrDefaultAsync(m => m.SmartMeterId == id);
            if (smartMeter == null)
            {
                return NotFound();
            }

            _context.SmartMeter.Remove(smartMeter);
            await _context.SaveChangesAsync();

            return Ok(smartMeter);
        }

        private bool SmartMeterExists(long id)
        {
            return _context.SmartMeter.Any(e => e.SmartMeterId == id);
        }
    }
}