using MentorLink.Data.Models;

namespace MentorLink.Data.IRepository;

public interface IStudentRepository
{
    Task<Student> GetStudentByIdAsync(int studentId, int capstoneWorkspaceId);
}