using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.ProsumerInfoRestApi.Entities;
using DABHandIn4.ProsumerInfoRestApi.Presistences;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DABHandIn4.ProsumerInfoRestApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Prosumer")]
    public class ProsumerController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();

        // GET: api/Prosumer
        [HttpGet]
        public IEnumerable<Prosumer> GetAllProsumer()
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                return unitOfWork.Prosumer.GetAll();
            }
        }

        // GET: api/Prosumer/5
        [HttpGet("{id}")]
        public IActionResult GetProsumer([FromRoute]int id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var prosumer = unitOfWork.Prosumer.Get(id);
                return Ok(prosumer);
            }
        }

        // POST: api/Prosumer
        [HttpPost]
        public IActionResult PostProsumer([FromBody] Prosumer prosumer)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                unitOfWork.Prosumer.Add(prosumer);

                return CreatedAtRoute("DefaultApi", new { id = prosumer.ProsumerId }, prosumer);
            }
        }

        // PUT: api/Prosumer/5
        [HttpPut("{id}")]
        public IActionResult PutProsumer(long id, [FromBody]Prosumer prosumerToUpdate)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var prosumer = unitOfWork.Prosumer.SingleOrDefault(p => p.ProsumerId == id);
                if (prosumer != null)
                {
                    prosumer = prosumerToUpdate;
                    return Ok(prosumer);
                }

                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteProsumer([FromRoute] long id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var prosumerToDelete = unitOfWork.Prosumer.SingleOrDefault(p => p.ProsumerId == id);
                unitOfWork.Prosumer.Remove(prosumerToDelete);
                return Ok(prosumerToDelete);
            }
        }
    }
}
