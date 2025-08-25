using WebAppStudent_Repositary_Pattern.Models;

public interface IEnrollmentRepo
{
    Task<IEnumerable<Enrollments>> GetAllEnrollments();
    Task<Enrollments> GetEnrollmentbyId(int id);
    Task AddEnrollmentsAsync(Enrollments enrollment);
    Task UpdateEnrollmentsAsync(int id, Enrollments enrollment);
    Task DeleteEnrollmentsAsync(int id);
}
