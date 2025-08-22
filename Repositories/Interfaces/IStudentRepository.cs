using WebAppStudent_Repositary_Pattern.Models;

namespace WebAppStudent_Repositary_Pattern.Repositories.Interfaces
{
    // Interface defines what methods any Student Repository should implement
    public interface IStudentRepository
    {
        // Gets all students
        Task<IEnumerable<Students>> GetAllStudentsAsync();
        Task<Students> GetStudentByIdAsync(int id);
        Task AddStudentAsync(Students student);
        Task UpdateStudentAsync(Students student);
        Task DeleteStudentAsync(int id);
        Task<bool> StudentExistsAsync(int id);
    }
}
