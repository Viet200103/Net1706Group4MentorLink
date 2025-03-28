using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface IStudentRepository
{
    Task<Student> GetStudentByIdAsync(int studentId, int capstoneWorkspaceId);
}