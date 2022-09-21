using UniversityApiBackend.DataAccess;
using UniversityApiBackend.Models.DataModels;

namespace UniversityApiBackend.Services
{
    public interface ICharptersService
    {
        IEnumerable<Charpter>? GetCharptertForSpecificCourse(Course course, UniversityDBContext context);
        IEnumerable<Charpter>? GetCharptertForSpecificCourse(int idCourse, UniversityDBContext context);
    }
}
