using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Competitions
{
    public interface ICompetitionAnswerRepository
    {
        Task<int> CountCompetitiinAnswer(int competitionId);
        Task<CompetitionAnswer> GetCompetitionAnswer(int competitionQuestionId, int competitiontargetId);
    }
}
