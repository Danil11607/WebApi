using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Data;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private MyDbContext db = new MyDbContext();

        //GET api/note
        public IEnumerable<Note> GetAll()
        {
            return db.Notes;
        }

        //GET api/note/{id}
        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetById(int id)
        {
            var item = db.Notes.Find(id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
