using MentorLink.Data.IRepository;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MentorLink.Data.Repositories;

public class LecturerWorkSpaceRepository(ApplicationDbContext context) : ILecturerWorkSpaceRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<LecturerWorkspace> GetLecturerWorkspaceById(int lectureId, int capstoneWorkspaceId)
    {
        return await _context.LecturerWorkspaces.FirstOrDefaultAsync(l => l.LecturerId == lectureId && l.WorkspaceId == capstoneWorkspaceId);
    }
}