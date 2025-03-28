using MentorLink.Data.Models;

namespace MentorLink.Data.IRepositories;

public interface ILecturerWorkSpaceRepository
{
    Task<LecturerWorkspace> GetLecturerWorkspaceById(int lectureId, int capstoneWorkspaceId);
}