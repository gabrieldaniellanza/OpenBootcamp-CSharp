using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class CharptersService : ICharptersService
    {
        // Capitulos de un curso
        public IEnumerable<Charpter>? GetCharptertForSpecificCourse(Course course, UniversityDBContext context)
        {

            if (context.Charpters == null) return null;

            return GetCharptertForSpecificCourse(course.Id, context);

        }

        // Capitulos de un curso
        public IEnumerable<Charpter>? GetCharptertForSpecificCourse(int course, UniversityDBContext context)
        {

            if (context.Charpters == null) return null;

            return context.Charpters.Where(c => c.Course.Id == course);

        }
    }
}
