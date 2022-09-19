using UniversityApiBachend.DataAccess;
using UniversityApiBachend.Models.DataModels;

namespace UniversityApiBachend.Services
{
    public class CoursesService : ICoursesService
    {
        // Cursos por categoria
        public IEnumerable<Course>? GetCoursesByCategory(int idCategoria, UniversityDBContext context)
        {
            if (context.Courses == null || context.Categories == null) return null;

            //return (IEnumerable<Course>?) 
            //    (from categories in context.Categories
            //    where categories.Id == idCategoria
            //    select categories.Courses);

            return (IEnumerable<Course>?) context.Courses.
                Select( course => course).
                Where(course => course.Categories.Any( category => category.Id == idCategoria));
        }

        // Cursos de un estudiante
        public IEnumerable<Course>? GetCoursesForSpecificStudent(int idStudent, UniversityDBContext context)
        {
            if (context.Courses == null || context.Students == null) return null;

            //return (IEnumerable<Course>?)
            //    (from Student in context.Students
            //     where Student.Id == idStudent
            //     select Student.Courses);

            return (IEnumerable<Course>?)context.Courses.
                Select(course => course).
                Where(course => course.Students.Any(student => student.Id == idStudent));
        }

        // Cursos sin capitulos
        public IEnumerable<Course>? GetCoursesWithOutCharpter(UniversityDBContext context)
        {
            if (context.Courses == null) return null;

            return (IEnumerable<Course>?) context.Courses.
                Select(c => c).
                Where(c => !c.Charpters.Any());
        }
    }
}
