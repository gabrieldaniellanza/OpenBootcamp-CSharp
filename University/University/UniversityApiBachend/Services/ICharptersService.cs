using UniversityApiBachend.DataAccess;
using UniversityApiBachend.Models.DataModels;

namespace UniversityApiBachend.Services
{
    public interface ICharptersService
    {
        IEnumerable<Charpter>? GetCharptertForSpecificCourse(Course course, UniversityDBContext context);
        IEnumerable<Charpter>? GetCharptertForSpecificCourse(int idCourse, UniversityDBContext context);
    }
}
