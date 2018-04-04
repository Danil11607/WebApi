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
        //private MyDbContext db = new MyDbContext();
        private List<Note> Notes = new List<Note>
        {
            new Note(1, "First task", true),
            new Note(2, "Second task", false),
            new Note(3, "Third task", false)
        };

        //GET api/note
        public IEnumerable<Note> GetAll(int page)
        {
            return Notes;
        }

        //GET api/note/{id}
        [HttpGet("{id}", Name = "GetNote")]
        public IActionResult GetById(int id)
        {
            var item = Notes.FirstOrDefault(x => x.Id == id);
            if (item == null)
                return NotFound();

            return new ObjectResult(item);
        }

        //POST api/note
        [HttpPost]
        public IEnumerable<Note> Create([FromBody] Note note)
        {
            if (note == null)
                return null;
            Notes.Add(note);

            return Notes;
        }

        //PUT api/note/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Note note)
        {
            if (note == null || note.Id != id)
                return BadRequest();

            var temporaryNote = Notes.FirstOrDefault(x => x.Id == id);
            if (temporaryNote == null)
                return NotFound();

            Notes[id - 1] = note;

            return new ObjectResult(Notes[id - 1]);
        }

        //PATCH api/note/{id}
        [HttpPatch("{id}")]
        public IActionResult Update([FromBody] Note note, int id)
        {
            if (note == null)
                return BadRequest();

            var temporaryNote = Notes.FirstOrDefault(x => x.Id == id);
            if (temporaryNote == null)
                return NotFound();

            note.Id = temporaryNote.Id;

            Notes[id - 1] = note;

            return new ObjectResult(Notes[id - 1]);
        }

        //DELETE api/note/{id}
        [HttpDelete("{id}")]
        public IEnumerable<Note> Delete(int id)
        {
            var note = Notes.FirstOrDefault(x => x.Id == id);
            if (note == null)
                return null;

            Notes.Remove(note);

            return Notes;
        }
    }
}
