using WebAppStudent_Repositary_Pattern.Models;

namespace WebAppStudent_Repositary_Pattern.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<IEnumerable<Courses>> GetAll();
        Task<Courses> GetById(int id);
        Task AddCourseAsync(Courses courses);
        Task UpdateCourseAsync(Courses courses);
        Task DeleteCourseAsync(int id);
    }
}
