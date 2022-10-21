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
    public class CoursesController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        // services
        private readonly ICoursesService _coursesService;
        private readonly ILogger<AccountsController> _logger;
        //_logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

        public CoursesController(UniversityDBContext context, ICoursesService coursesService, ILogger<AccountsController> logger)
        {
            _context = context;
            _coursesService = coursesService;
            _logger = logger;
        }

        // GET: api/Courses
        [MapToApiVersion(Version.V)]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Courses == null)
          {
              return NotFound();
          }
            return await _context.Courses.ToListAsync();
        }

        // GET: api/Courses/5
        [MapToApiVersion(Version.V)]
        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(int id)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Courses == null)
          {
              return NotFound();
          }
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
            {
                return NotFound();
            }

            return course;
        }


        // GET: api/Courses/ByCategory/5
        [MapToApiVersion(Version.V)]
        [HttpGet("ByCategory/{idCategory}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByCategory(int idCategory)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_coursesService == null)
            {
                return NotFound();
            }

            var courses = _coursesService.GetCoursesByCategory(idCategory, _context);

            if (courses == null)
            {
                return NotFound();
            }

            return courses.ToList();
        }

        // GET: api/Courses/ByCategory/5ç
        [MapToApiVersion(Version.V)]
        [HttpGet("ForSpecificStudent/{idStudent}")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesForSpecificStudent(int idStudent)
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_coursesService == null)
            {
                return NotFound();
            }

            var courses = _coursesService.GetCoursesForSpecificStudent(idStudent, _context);

            if (courses == null)
            {
                return NotFound();
            }

            return courses.ToList();
        }

        // GET: api/Students/WithOutCharpter
        [MapToApiVersion(Version.V)]
        [HttpGet("WithOutCharpter")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesWithOutCharpter()
        {
            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_coursesService == null)
            {
                return NotFound();
            }

            var courses = _coursesService.GetCoursesWithOutCharpter(_context);

            if (courses == null)
            {
                return NotFound();
            }

            return courses.ToList();
        }


        // PUT: api/Courses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [MapToApiVersion(Version.V)]
        [HttpPut("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> PutCourse(int id, Course course)
        {

            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (id != course.Id)
            {
                return BadRequest();
            }

            _context.Entry(course).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CourseExists(id))
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

        // POST: api/Courses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [MapToApiVersion(Version.V)]
        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {

            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Courses == null)
          {
              return Problem("Entity set 'UniversityDBContext.Courses'  is null.");
          }
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCourse", new { id = course.Id }, course);
        }

        // DELETE: api/Courses/5
        [MapToApiVersion(Version.V)]
        [HttpDelete("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
        public async Task<IActionResult> DeleteCourse(int id)
        {

            _logger.LogInformation($"{this.GetType().Name} - {MethodBase.GetCurrentMethod().Name} - Function Called");

            if (_context.Courses == null)
            {
                return NotFound();
            }
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CourseExists(int id)
        {
            return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
