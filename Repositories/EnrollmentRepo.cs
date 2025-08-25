using Microsoft.EntityFrameworkCore;
using System;
using WebAppStudent_Repositary_Pattern.Data;
using WebAppStudent_Repositary_Pattern.Models;
using WebAppStudent_Repositary_Pattern.Repositories.Interfaces;

public class EnrollmentRepo : IEnrollmentRepo
{
    private readonly StudentDbContext _context;

    public EnrollmentRepo(StudentDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Enrollments>> GetAllEnrollments()
    {
        return await _context.Enrollments
            .Include(e => e.Students)
            .Include(e => e.Courses)
            .ToListAsync();
    }

    public async Task<Enrollments> GetEnrollmentbyId(int id)
    {
        return await _context.Enrollments
            .Include(e => e.Students)
            .Include(e => e.Courses)
            .FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task AddEnrollmentsAsync(Enrollments enrollment)
    {
        _context.Enrollments.Add(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEnrollmentsAsync(int id, Enrollments enrollment)
    {
        _context.Enrollments.Update(enrollment);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEnrollmentsAsync(int id)
    {
        var enrollment = await _context.Enrollments.FindAsync(id);
        if (enrollment != null)
        {
            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
        }
    }
}
