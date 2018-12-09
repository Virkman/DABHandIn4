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
    [Route("api/Fremtidige")]
    public class FremtidigeController : Controller
    {
        IUnitOfWork db = new UnitOfWork();

        // GET: api/Fremtidige
        [HttpGet]
        public async Task<IQueryable<Fremtidige>> GetFremtidige()
        {
            return await db.Fremtidige.GetAllItemsAsync();
        }

        // GET: api/Fremtidige/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFremtidige([FromRoute]int id)
        {
            var fremtidige = await db.Fremtidige.GetItemAsync(id.ToString());
            if (fremtidige != null)
            {
                return Ok(fremtidige);
            }

            return NotFound();
        }

        // POST: api/Fremtidige
        [HttpPost]
        public async Task<IActionResult> PostFremtidige([FromBody]Fremtidige newFremtidige)
        {
            await db.Fremtidige.CreateItemAsync(newFremtidige);

            return Ok(newFremtidige);

        }

        // PUT: api/Fremtidige/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Fremtidige fremtidige)
        {
            var fremtidigeToUpdate = db.Fremtidige.GetItemsAsync(p => p.id == id);
            if (fremtidigeToUpdate != null)
            {
                await db.Fremtidige.UpdateItemAsync(id.ToString(), fremtidige);
                return Ok(fremtidigeToUpdate);
            }
            return NotFound();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFremtidige(string id)
        {
            await db.Fremtidige.DeleteItemAsync(id);
            return Ok();
        }
    }
}
