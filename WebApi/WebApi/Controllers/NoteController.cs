﻿using System;
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

        //POST api/note
        [HttpPost]
        public IActionResult Create([FromBody] Note note)
        {
            if (note == null)
            {
                return BadRequest();
            }
            db.Notes.Add(note);
            db.SaveChanges();
            return CreatedAtRoute("GetTodo", new { id = note.Id }, note);
        }

        //PUT api/note/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note note)
        {
            if (note == null || note.Id != id)
                return BadRequest();            

            var temporaryNote = db.Notes.Find(id);
            if (temporaryNote == null)            
                return NotFound();            

            db.Notes.Update(note);
            db.SaveChanges();
            return new NoContentResult();
        }

        //PATCH api/note/{id}
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Note note, int id)
        {
            if (note == null)            
                return BadRequest();

            var temporaryNote = db.Notes.Find(id);
            if (temporaryNote == null)            
                return NotFound();            

            note.Id = temporaryNote.Id;

            db.Notes.Update(note);
            db.SaveChanges();
            return new NoContentResult();
        }

        //DELETE api/note/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var note = db.Notes.Find(id);
            if (note == null)
                return NotFound();

            db.Notes.Remove(note);
            db.SaveChanges();
            return new NoContentResult();
        }
    }
}
