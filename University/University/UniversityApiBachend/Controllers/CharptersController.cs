using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniversityApiBachend.DataAccess;
using UniversityApiBachend.Models.DataModels;
using UniversityApiBachend.Services;

namespace UniversityApiBachend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        // services
        private readonly ICharptersService _charptersService;

        public CharptersController(UniversityDBContext context, ICharptersService charptersService)
        {
            _context = context;
            _charptersService = charptersService;
        }

        // GET: api/Charpters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charpter>>> GetCharpters()
        {
          if (_context.Charpters == null)
          {
              return NotFound();
          }
            return await _context.Charpters.ToListAsync();
        }

        // GET: api/Charpters/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Charpter>> GetCharpter(int id)
        {
          if (_context.Charpters == null)
          {
              return NotFound();
          }
            var charpter = await _context.Charpters.FindAsync(id);

            if (charpter == null)
            {
                return NotFound();
            }

            return charpter;
        }

        // GET: api/Charpters/ForSpecificCourse/5
        [HttpGet("ForSpecificCourse/{idCourse}")]
        public async Task<ActionResult<IEnumerable<Charpter>>> GetCharptertForSpecificCourse(int idCourse)
        {
            if (_charptersService == null)
            {
                return NotFound();
            }


            var charpters = _charptersService.GetCharptertForSpecificCourse(idCourse, _context);

            if (charpters == null)
            {
                return NotFound();
            }

            return charpters.ToList();
        }

        // PUT: api/Charpters/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharpter(int id, Charpter charpter)
        {
            if (id != charpter.Id)
            {
                return BadRequest();
            }

            _context.Entry(charpter).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharpterExists(id))
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

        // POST: api/Charpters
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Charpter>> PostCharpter(Charpter charpter)
        {
          if (_context.Charpters == null)
          {
              return Problem("Entity set 'UniversityDBContext.Charpters'  is null.");
          }
            _context.Charpters.Add(charpter);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCharpter", new { id = charpter.Id }, charpter);
        }

        // DELETE: api/Charpters/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharpter(int id)
        {
            if (_context.Charpters == null)
            {
                return NotFound();
            }
            var charpter = await _context.Charpters.FindAsync(id);
            if (charpter == null)
            {
                return NotFound();
            }

            _context.Charpters.Remove(charpter);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        private bool CharpterExists(int id)
        {
            return (_context.Charpters?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
