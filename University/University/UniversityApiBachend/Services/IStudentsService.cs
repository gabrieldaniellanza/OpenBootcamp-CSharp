using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface IStudentsService
    {

        IEnumerable<Student>? GetStudentsWhitCourses(UniversityDBContext universityDBContext);

        IEnumerable<Student>? GetStudentsWhitNoCourses(UniversityDBContext universityDBContext);

        IEnumerable<Student>? GetStudentsForSpecificCourse(int idCourse, UniversityDBContext universityDBContext);
    }
}
