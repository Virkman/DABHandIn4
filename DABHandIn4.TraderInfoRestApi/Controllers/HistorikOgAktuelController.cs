using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.TraderInfoRestApi.Core;
using DABHandIn4.TraderInfoRestApi.Models;
using DABHandIn4.TraderInfoRestApi.Presistences;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DABHandIn4.TraderInfoRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/HistorikOgAktuel")]
    public class HistorikOgAktuelController : Controller
    {
        IUnitOfWork db = new UnitOfWork();

        // GET: api/HistorikOgAktuel
        [HttpGet]
        public async Task<IQueryable<HistorikOgAktuel>> GetPersons()
        {
            return await db.HistorikOgAktuel.GetAllItemsAsync();
        }

        // GET: api/HistorikOgAktuel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHistorikOgAktuel([FromRoute]int id)
        {
            var historikOgAktuel = await db.HistorikOgAktuel.GetItemAsync(id.ToString());
            if (historikOgAktuel != null)
            {
                return Ok(historikOgAktuel);
            }

            return NotFound();
        }

        // POST: api/HistorikOgAktuel
        [HttpPost]
        public async Task<IActionResult> PostHistorikOgAktuel([FromBody]HistorikOgAktuel newHistorikOgAktuel)
        {
            await db.HistorikOgAktuel.CreateItemAsync(newHistorikOgAktuel);

            return Ok(newHistorikOgAktuel);

        }

        // PUT: api/HistorikOgAktuel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]HistorikOgAktuel historikOgAktuel)
        {
            var historikOgAktuelToUpdate = db.HistorikOgAktuel.GetItemsAsync(p => p.id == id);
            if (historikOgAktuelToUpdate != null)
            {
                await db.HistorikOgAktuel.UpdateItemAsync(id.ToString(), historikOgAktuel);
                return Ok(historikOgAktuelToUpdate);
            }
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHistorikOgAktuel(string id)
        {
            await db.HistorikOgAktuel.DeleteItemAsync(id);
            return Ok();
        }
    }
}
