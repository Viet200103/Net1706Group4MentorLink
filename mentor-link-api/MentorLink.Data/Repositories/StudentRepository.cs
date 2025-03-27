using MentorLink.Data.IRepository;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Data.Repositories;

public class StudentRepository(ApplicationDbContext context) : IStudentRepository
{
    private readonly ApplicationDbContext _context = context;
    public async Task<Student> GetStudentByIdAsync(int studentId, int capstoneWorkspaceId)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId && s.CapstoneWorkspaceId == capstoneWorkspaceId);
    }
}