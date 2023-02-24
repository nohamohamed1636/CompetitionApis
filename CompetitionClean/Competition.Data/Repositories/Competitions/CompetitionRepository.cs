using Core.Models;
using Core.Models.Context;
using Core.Repositories.Competitions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Competitions
{
    public class CompetitionRepository : ICompetitionRepository
    {
        private readonly AppDbContext _context;
        public CompetitionRepository(AppDbContext context)
        {
            _context = context;
        }



        public async Task<List<Competition>> GetAllCompetition()
        {
            var result = await _context.Competitions.Where(c=>c.Deleted == false).ToListAsync();
            return result;

        }
        public async Task<List<Competition>> GetAllCompetitionList()
        {
            var result = await _context.Competitions.Where(c => c.Deleted == false).Include(f => f.CompetitionTargets).Include(f => f.CompetitionQuestions).ToListAsync();
            return result;

        }
        public async Task<Competition> GetCompetitionById(int competitionId)
        {
            var result = await _context.Competitions.Include(f => f.CompetitionTargets).Include(f=>f.CompetitionQuestions).FirstOrDefaultAsync(c => c.Deleted == false && c.Id == competitionId);
            return result;

        }
        public async Task<Competition> AddNewCompetition(Competition newCompetition)
        {
            var user = await _context.Competitions.AddAsync(newCompetition);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<Competition> UpdateUser(Competition competition)
        {
            var entit = _context.Competitions.Update(competition);
            await _context.SaveChangesAsync();
            return entit.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }



    }
}
