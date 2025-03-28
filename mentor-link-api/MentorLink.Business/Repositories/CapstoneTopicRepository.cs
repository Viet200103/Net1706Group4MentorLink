using MentorLink.Data;
using MentorLink.Data.IRepositories;
using MentorLink.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MentorLink.Business.Repositories
{
    public class CapstoneTopicRepository : ICapstoneTopicRepository
    {
        private MentorLinkDbContext _db;
        public CapstoneTopicRepository(MentorLinkDbContext db)
        {
            _db = db;
        }

        public async Task<CapstoneTopic> ApproveTopic(CapstoneTopic capstoneTopic)
        {
           _db.Update(capstoneTopic);
            await _db.SaveChangesAsync();
            return capstoneTopic;
        }

        public async Task<CapstoneTopic> CreateCapstoneTopicAsync(CapstoneTopic capstoneTopic)
        {
            _db.CapstoneTopics.Add(capstoneTopic);
            await _db.SaveChangesAsync();
            return capstoneTopic;
        }

        public async Task<bool> DeleteCapstoneTopic(int id)
        {
            _db.CapstoneTopics.Remove(_db.CapstoneTopics.FirstOrDefault(n => n.CapstoneTopicId == id) ?? throw new InvalidOperationException());
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<CapstoneTopic>> GetAllCapstoneTopicAsync()
        {
            return await _db.CapstoneTopics.Include(c => c.CapstoneWorkspace).ToListAsync();
        }

        public async Task<CapstoneTopic> GetCapstoneTopicById(int id)
        {
            return await _db.CapstoneTopics.Include(c => c.CapstoneWorkspaceId).FirstOrDefaultAsync(t => t.CapstoneTopicId == id);
        }
    }
}
