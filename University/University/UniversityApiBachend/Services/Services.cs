using System.Security.Policy;
using UniversityApiBachend.DataAccess;
using UniversityApiBachend.Models.DataModels;

namespace UniversityApiBachend.Services
{
    public class Services
    {

        public User? FindUserByEmail(string email, UniversityDBContext context)
        {
            if (context.Users == null) return null;

            return context.Users.FirstOrDefault(u => u.Email.Equals(email));
        }

        public List<Student>? OlderStudents(UniversityDBContext context)
        {
            if (context.Students == null) return null;

            return (List<Student>?)context.Students.
                Select(s => s).
                Where(s => DateTime.Today.AddTicks(-s.Dob.Ticks).Year - 1 < 21);
        }

        public List<Student>? StudentsWhoHaveAtLeastOneCourse(UniversityDBContext context)
        {
            if (context.Students == null) return null;

            return (List<Student>?)context.Students.
                Select(s => s).
                Where(s => s.Courses.Any());
        }

        public List<Course>? CoursesOfACertainLevelThatHaveAtLeastOneStudentEnrolled(Level level ,UniversityDBContext context)
        {
            if (context.Courses == null) return null;

            return (List<Course>?)context.Courses.
                Select(c => c).
                Where(c => c.Level == level && c.Students.Any());
        }


        public List<Course>? CoursesOfACertainLevelThatAreOfACertainCategory(Level level, Category category, UniversityDBContext context)
        {
            if (context.Courses == null) return null;

            return (List<Course>?)context.Courses.
                Select(c => c).
                Where(c => c.Level == level && c.Categories.Any(c => c.Id == category.Id));
        }


        public List<Course>? CoursesWithoutStudents(UniversityDBContext context)
        {
            if (context.Courses == null) return null;

            return (List<Course>?)context.Courses.
                Select(c => c).
                Where(c => !c.Students.Any());
        }

    }
}
