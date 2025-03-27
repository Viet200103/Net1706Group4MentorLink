using MentorLink.Data.Models;

namespace MentorLink.Data.IRepository;

public interface ILecturerWorkSpaceRepository
{
    Task<LecturerWorkspace> GetLecturerWorkspaceById(int lectureId, int capstoneWorkspaceId);
}