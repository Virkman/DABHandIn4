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
    [Route("api/Forbrug")]
    public class ForbrugController : Controller
    {
        private ApplicationContextDbFactory fac = new ApplicationContextDbFactory();

        // GET: api/Forbrug
        [HttpGet]
        public IEnumerable<Forbrug> GetAllForbrug()
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                return unitOfWork.Forbrug.GetAll();
            }
        }

        // GET: api/Forbrug/5
        [HttpGet("{id}")]
        public IActionResult GetForbrug([FromRoute]int id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var forbrug = unitOfWork.Forbrug.Get(id);
                return Ok(forbrug);
            }
        }

        // POST: api/Forbrug
        [HttpPost]
        public IActionResult PostForbrug([FromBody] Forbrug forbrug)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                unitOfWork.Forbrug.Add(forbrug);

                return CreatedAtRoute("DefaultApi", new { id = forbrug.ForbrugId }, forbrug);
            }
        }

        // PUT: api/Forbrug/5
        [HttpPut("{id}")]
        public IActionResult PutForbrug(long id, [FromBody]Forbrug forbrugToUpdate)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var forbrug = unitOfWork.Forbrug.SingleOrDefault(f => f.ForbrugId == id);
                if (forbrug != null)
                {
                    forbrug = forbrugToUpdate;
                    return Ok(forbrug);
                }

                return NotFound();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult DeleteForbrug([FromRoute] long id)
        {
            using (var unitOfWork = new UnitOfWork(fac.db))
            {
                var forbrugToDelete = unitOfWork.Forbrug.SingleOrDefault(f => f.ForbrugId == id);
                unitOfWork.Forbrug.Remove(forbrugToDelete);
                return Ok(forbrugToDelete);
            }
        }
    }
}
