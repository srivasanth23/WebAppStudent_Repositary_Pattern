using Microsoft.EntityFrameworkCore;
using WebAppStudent_Repositary_Pattern.Data;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

namespace WebAppStudent_Repositary_Pattern.Repositories
{
    // This class implements the IStudentRepository interface
    public class StudentRepo : IStudentRepository
    {
        // Injecting the DbContext to interact with the database
        private readonly StudentDbContext _context;

        // Constructor injection (Dependency Injection)
        public StudentRepo(StudentDbContext context)
        {
            _context = context;
        }


        // -------------------------------
        // Get all students with their enrollments and courses
        // -------------------------------
        public async Task<IEnumerable<Students>> GetAllStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }


        // -------------------------------
        // Get a specific student by ID including related data
        // -------------------------------
        public async Task<Students> GetStudentByIdAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);

            if (student == null) { 
                return null;
            }

            return student;
        }


        // -------------------------------
        // Add a new student record to the database
        // -------------------------------
        public async Task AddStudentAsync(Students student)
        {
            if (student == null) 
            {
                throw new ArgumentNullException(nameof(student));
            }
            await _context.Students.AddAsync(student);
            await _context.SaveChangesAsync();
        }

        // -------------------------------------------------
        // Update an existing student
        // -------------------------------------------------
        public async Task UpdateStudentAsync(Students student)
        {
            // Attach the entity to the context if not already tracked
            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
            {
                _context.Students.Remove(student);
                await _context.SaveChangesAsync();
            }
        }

        // -------------------------------------------------
        // Check if a student exists by ID
        // -------------------------------------------------
        public async Task<bool> StudentExistsAsync(int id)
        {
            return await _context.Students.AnyAsync(s => s.Id == id);
        }
    }
}
