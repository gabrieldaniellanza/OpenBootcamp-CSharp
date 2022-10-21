using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;
using UniversityApiBackend.Services;

namespace UniversityApiBackend.Controllers.V1
{
    [ApiVersion(Version.V)]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CharptersController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        // services
        private readonly ICharptersService _charptersService;


        private readonly ILogger<AccountsController> _logger;


        public CharptersController(UniversityDBContext context, ICharptersService charptersService, ILogger<AccountsController> logger)
        {
            _context = context;
            _charptersService = charptersService;
            _logger = logger;
        }

        // GET: api/Charpters
        [MapToApiVersion(Version.V)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Charpter>>> GetCharpters()
        {
            
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Charpters == null)
          {
              return NotFound();
          }
            return await _context.Charpters.ToListAsync();
        }

        // GET: api/Charpters/5
        [MapToApiVersion(Version.V)]
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
        [MapToApiVersion(Version.V)]
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
        [MapToApiVersion(Version.V)]
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
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
        [MapToApiVersion(Version.V)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
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
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
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
