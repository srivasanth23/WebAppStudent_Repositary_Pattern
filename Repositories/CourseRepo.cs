using Microsoft.EntityFrameworkCore;
using WebAppStudent_Repositary_Pattern.Data;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

namespace WebAppStudent_Repositary_Pattern.Repositories
{
    public class CourseRepo : ICourseRepository
    {
        private readonly StudentDbContext _context;

        public CourseRepo(StudentDbContext context)
        {
            _context = context;
        }

        // Get all courses
        public async Task<IEnumerable<Courses>> GetAll()
        {
            return await _context.Courses.ToListAsync();
        }

        // Get course by ID
        public async Task<Courses> GetById(int id)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == id);
            return course!;
        }

        // Add new course
        public async Task AddCourseAsync(Courses courses)
        {
            if (courses == null)
                throw new ArgumentNullException(nameof(courses));

            await _context.Courses.AddAsync(courses);
            await _context.SaveChangesAsync();
        }

        // Update existing course
        public async Task UpdateCourseAsync(Courses courses)
        {
            if (courses == null)
                throw new ArgumentNullException(nameof(courses));

            _context.Courses.Update(courses);
            await _context.SaveChangesAsync();
        }

        // Delete course by ID
        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course != null)
            {
                _context.Courses.Remove(course);
                await _context.SaveChangesAsync();
            }
        }

    }
}
