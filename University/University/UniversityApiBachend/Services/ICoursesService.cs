using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICoursesService
    {
            
        IEnumerable<Course>? GetCoursesByCategory(int idCategory, UniversityDBContext universityDBContext);

        IEnumerable<Course>? GetCoursesForSpecificStudent(int idStudent, UniversityDBContext universityDBContext);

        IEnumerable<Course>? GetCoursesWithOutCharpter(UniversityDBContext universityDBContext);
    }
}
