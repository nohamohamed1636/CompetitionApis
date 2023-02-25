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
    public class CompetitionAnswerRepository : ICompetitionAnswerRepository
    {
        private readonly AppDbContext _context;
        public CompetitionAnswerRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<int> CountCompetitiinAnswer(int competitionId)
        {
            var result = await _context.CompetitionAnswers.Where(c => c.CompetitionTargets.CompetitionId == competitionId && c.Deleted == false).ToListAsync();
            return result.Count;

        }
    }
}
