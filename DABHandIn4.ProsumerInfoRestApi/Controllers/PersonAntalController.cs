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
    [Route("api/PersonAntal")]
    public class PersonAntalController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();

        // GET: api/PersonAntal
        [HttpGet]
        public IEnumerable<PersonAntal> GetAllPersonAntal()
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                return unitOfWork.PersonAntal.GetAll();
            }
        }

        // GET: api/PersonAntal/5
        [HttpGet("{id}")]
        public IActionResult GetPersonAntal([FromRoute]int id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var personAntal = unitOfWork.PersonAntal.Get(id);
                return Ok(personAntal);
            }
        }

        // POST: api/PersonAntal
        [HttpPost]
        public IActionResult PostPersonAntal([FromBody] PersonAntal personAntal)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                unitOfWork.PersonAntal.Add(personAntal);

                return CreatedAtRoute("DefaultApi", new { id = personAntal.PersonAntalId }, personAntal);
            }
        }

        // PUT: api/PersonAntal/5
        [HttpPut("{id}")]
        public IActionResult PutPersonAntal(long id, [FromBody]PersonAntal personAntalToUpdate)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var personAntal = unitOfWork.PersonAntal.SingleOrDefault(p => p.PersonAntalId == id);
                if (personAntal != null)
                {
                    personAntal = personAntalToUpdate;
                    return Ok(personAntal);
                }

                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeletePersonAntal([FromRoute] long id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var personAntalToDelete = unitOfWork.PersonAntal.SingleOrDefault(p => p.PersonAntalId == id);
                unitOfWork.PersonAntal.Remove(personAntalToDelete);
                return Ok(personAntalToDelete);
            }
        }
    }
}
