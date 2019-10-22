using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogNames.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DogNames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DogNamesController : ControllerBase
    {
        private readonly DogNamesContext _context;

        public DogNamesController(DogNamesContext context)
        {
            _context = context;
        }

        // GET: api/<controller>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Name>>> GetDogNames()
        {
            return await _context.DogNames.ToListAsync();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Name>> GetDogName(string id)
        {
            var dogName = await _context.DogNames.FindAsync(id);

            if (dogName == null)
            {
                return NotFound();
            }

            return dogName;
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<ActionResult<Name>> PostDogName(Name name)
        {
            _context.DogNames.Add(name);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDogName), new { id = name.Id }, name);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDogName(string id, Name name)
        {
            if (id != name.Id)
            {
                return BadRequest();
            }

            _context.Entry(name).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!NameExists(id))
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

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Name>> DeleteName(string id)    
        {
            var name = await _context.DogNames.FindAsync(id);
            if(name == null)
            {
                return NotFound();
            }

            _context.DogNames.Remove(name);
            await _context.SaveChangesAsync();

            return name;
        }

        private bool NameExists(string id)
        {
            return _context.DogNames.Any(e => e.Id == id);
        }
    }
}