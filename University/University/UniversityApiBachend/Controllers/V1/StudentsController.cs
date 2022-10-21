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
    public class StudentsController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        // services
        private readonly IStudentsService _studentsService;

        private readonly ILogger<AccountsController> _logger;
        //_logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

        public StudentsController(UniversityDBContext context, IStudentsService studentsService, ILogger<AccountsController> logger)
        {
            _context = context;
            _studentsService = studentsService;
            _logger = logger;
        }

        // GET: api/Students
        [ApiVersion(Version.V)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Students == null)
          {
              return NotFound();
          }
            return await _context.Students.ToListAsync();
        }

        // GET: api/Students/5
        [ApiVersion(Version.V)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Students == null)
          {
              return NotFound();
          }
            var student = await _context.Students.FindAsync(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        // GET: api/Students/WhitNoCourses
        [ApiVersion(Version.V)]
        [HttpGet("WhitNoCourses")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsWhitNoCourses()
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_studentsService == null)
            {
                return NotFound();
            }

            var students = _studentsService.GetStudentsWhitNoCourses(_context);

            if (students == null)
            {
                return NotFound();
            }

            return students.ToList();
        }

        // GET: api/Students/ForSpecificCourse/5
        [ApiVersion(Version.V)]
        [HttpGet("ForSpecificCourse/{idCourse}")]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudentsForSpecificCourse(int idCourse)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_studentsService == null)
            {
                return NotFound();
            }

            var students = _studentsService.GetStudentsForSpecificCourse(idCourse, _context);

            if (students == null)
            {
                return NotFound();
            }

            return students.ToList();
        }

        // PUT: api/Students/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ApiVersion(Version.V)]
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutStudent(int id, Student student)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (id != student.Id)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
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

        // POST: api/Students
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [ApiVersion(Version.V)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Students == null)
          {
              return Problem("Entity set 'UniversityDBContext.Students'  is null.");
          }
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudent", new { id = student.Id }, student);
        }

        // DELETE: api/Students/5
        [ApiVersion(Version.V)]
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Students == null)
            {
                return NotFound();
            }
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentExists(int id)
        {
            return (_context.Students?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
