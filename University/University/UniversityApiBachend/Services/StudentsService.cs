

using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public class StudentsService : IStudentsService
    {

        // Estudiantes por curso
        public IEnumerable<Student>? GetStudentsForSpecificCourse(int idCourse, UniversityDBContext universityDBContext)
        {
            if(universityDBContext.Students == null) return null;

            return (IEnumerable<Student>?) universityDBContext.Students.
                Select(studient => studient).
                Where(studient => studient.Courses.Any(course => course.Id == idCourse));

        }

        public IEnumerable<Student>? GetStudentsWhitCourses(UniversityDBContext universityDBContext)
        {
            if (universityDBContext.Students == null) return null;

            return (IEnumerable<Student>?)universityDBContext.Students.
                Select(studient => studient).
                Where(studient => studient.Courses.Any());
        }

        public IEnumerable<Student>? GetStudentsWhitNoCourses(UniversityDBContext universityDBContext)
        {
            if (universityDBContext.Students == null) return null;

            return (IEnumerable<Student>?)universityDBContext.Students.
                Select(studient => studient).
                Where(studient => !studient.Courses.Any());
        }
    }
}
