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
    public class CompetitionTargteRepository : ICompetitionTargteRepository
    {
        private readonly AppDbContext _context;

        public CompetitionTargteRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<List<CompetitionTarget>> GetCompetitionTargetByStudentIdAndCompetitionId(int competitionId,string studentId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.CompetitionId == competitionId 
                                                                  && c.StudentId == studentId && c.Solved == false).Include(c => c.Competitions).ToListAsync();
            return result;

        }

        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionId(int competitionId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.CompetitionId == competitionId).ToListAsync();
            return result;
        }

        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByStudentIdUnSolved(string studentId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.StudentId == studentId && c.Solved == false).Include(c=>c.Competitions).ToListAsync();
            return result;
        }
        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByStudentIdSolved(string studentId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.StudentId == studentId && c.Solved == true).Include(c => c.Competitions).ToListAsync();
            return result;
        }

        public async Task<CompetitionTarget> AddNewCompetitionTarget(CompetitionTarget competitionTarget)
        {
            var user = await _context.CompetitionTargets.AddAsync(competitionTarget);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<CompetitionTarget> UpdateCompetitionTarget(CompetitionTarget competitionTarget)
        {
            var entit = _context.CompetitionTargets.Update(competitionTarget);
            await _context.SaveChangesAsync();
            return entit.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdUnsolved(int competitionId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.CompetitionId == competitionId && c.Solved == false).ToListAsync();
            return result;
        }

        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdUnsolvedwithStartedDate(int competitionId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.CompetitionId == competitionId && c.Closed == false && c.StarDate != null).ToListAsync();
            return result;
        }
        public async Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdnotClosed(int competitionId)
        {
            var result = await _context.CompetitionTargets.Where(c => c.Deleted == false && c.CompetitionId == competitionId && c.Closed == false).ToListAsync();
            return result;
        }
    }
}
