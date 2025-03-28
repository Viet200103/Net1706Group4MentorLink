using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using MentorLink.Business.Database;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Business.Repositories;

public class LecturerWorkSpaceRepository(MentorLinkDbContext context) : ILecturerWorkSpaceRepository
{
    private readonly MentorLinkDbContext _context = context;

    public async Task<LecturerWorkspace> GetLecturerWorkspaceById(int lectureId, int capstoneWorkspaceId)
    {
        return await _context.LecturerWorkspaces.FirstOrDefaultAsync(l => l.LecturerId == lectureId && l.WorkspaceId == capstoneWorkspaceId);
    }
}