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
    public class CompetitionQuestionRepository : ICompetitionQuestionRepository
    {
        private readonly AppDbContext _context;
        public CompetitionQuestionRepository(AppDbContext context)
        {
            _context= context;
        }


        public async Task<List<CompetitionQuestion>> GetAllCompetitionQuestionByCompetitionId(int competitionId)
        {
            var result = await _context.CompetitionQuestions.Where(c => c.Deleted == false && c.CompetitionId == competitionId).OrderBy(s=>s.DisplayOrder).ToListAsync();
            return result;
        }
        public async Task<List<CompetitionQuestion>> GetAllCompetitionQuestion(int competitionId)
        {
            var result = await _context.CompetitionQuestions.Where(c => c.Deleted == false && c.CompetitionId == competitionId).Include(d=>d.CompetitionAnswers)
                .ThenInclude(f=>f.CompetitionTargets).ToListAsync();
            return result;
        }
        public async Task<CompetitionQuestion> GetAllCompetitionQuestionByQuestionId(int competitionId,int questionId)
        {
            var result = await _context.CompetitionQuestions.FirstOrDefaultAsync(c => c.Deleted == false && c.CompetitionId == competitionId && c.QuestionId == questionId);
            return result;
        }

        public async Task<CompetitionQuestion> GetAllCompetitionQuestionById(int Id)
        {
            var result = await _context.CompetitionQuestions.FirstOrDefaultAsync(c => c.Deleted == false && c.Id == Id);
            return result;
        }

        public async Task<int> GetCountCompetitionQuestionByCompetitionId(int competitionId)
        {
            var result = await _context.CompetitionQuestions.Where(c => c.Deleted == false && c.CompetitionId == competitionId).ToListAsync();
            return result.Count;
        }

        public async Task<CompetitionQuestion> AddNewCompetitionQuestion(CompetitionQuestion competitionQuestion)
        {
            var user = await _context.CompetitionQuestions.AddAsync(competitionQuestion);
            await _context.SaveChangesAsync();
            return user.Entity;
        }

        public async Task<CompetitionQuestion> UpdateCompetitionQuestion(CompetitionQuestion competitionQuestion)
        {
            var entit = _context.CompetitionQuestions.Update(competitionQuestion);
            await _context.SaveChangesAsync();
            return entit.Entity;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
