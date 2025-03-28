using MentorLink.Business.Database;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class StudentRepository(MentorLinkDbContext context) : IStudentRepository
{
    private readonly MentorLinkDbContext _context = context;
    public async Task<Student> GetStudentByIdAsync(int studentId, int capstoneWorkspaceId)
    {
        return await _context.Students.FirstOrDefaultAsync(s => s.StudentId == studentId && s.CapstoneWorkspaceId == capstoneWorkspaceId);
    }
}