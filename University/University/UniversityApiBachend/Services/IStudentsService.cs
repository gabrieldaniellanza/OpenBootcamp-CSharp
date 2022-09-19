using UniversityApiBachend.DataAccess;
using UniversityApiBachend.Models.DataModels;

namespace UniversityApiBachend.Services
{
    public interface IStudentsService
    {

        IEnumerable<Student>? GetStudentsWhitCourses(UniversityDBContext universityDBContext);

        IEnumerable<Student>? GetStudentsWhitNoCourses(UniversityDBContext universityDBContext);

        IEnumerable<Student>? GetStudentsForSpecificCourse(int idCourse, UniversityDBContext universityDBContext);
    }
}
