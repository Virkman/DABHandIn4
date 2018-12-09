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
    [Route("api/Adresse")]
    public class AdresseController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();
        private ApplicationDbContext _context;

        public AdresseController()
        {
            _context = fac.db;
        }

        // GET: api/Adresse
        [HttpGet]
        public IEnumerable<Adresse> GetAdresse()
        {
            return _context.Adresse;
        }

        // GET: api/Adresse/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdresse([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adresse = await _context.Adresse.SingleOrDefaultAsync(m => m.AdresseId == id);

            if (adresse == null)
            {
                return NotFound();
            }

            return Ok(adresse);
        }

        // PUT: api/Adresse/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdresse([FromRoute] long id, [FromBody] Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adresse.AdresseId)
            {
                return BadRequest();
            }

            _context.Entry(adresse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdresseExists(id))
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

        // POST: api/Adresse
        [HttpPost]
        public async Task<IActionResult> PostAdresse([FromBody] Adresse adresse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Adresse.Add(adresse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdresse", new { id = adresse.AdresseId }, adresse);
        }

        // DELETE: api/Adresse/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdresse([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var adresse = await _context.Adresse.SingleOrDefaultAsync(m => m.AdresseId == id);
            if (adresse == null)
            {
                return NotFound();
            }

            _context.Adresse.Remove(adresse);
            await _context.SaveChangesAsync();

            return Ok(adresse);
        }

        private bool AdresseExists(long id)
        {
            return _context.Adresse.Any(e => e.AdresseId == id);
        }
    }
}