using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Competitions
{
    public interface ICompetitionQuestionRepository
    {
        Task<CompetitionQuestion> AddNewCompetitionQuestion(CompetitionQuestion competitionQuestion);
        Task<List<CompetitionQuestion>> GetAllCompetitionQuestion(int competitionId);
        Task<List<CompetitionQuestion>> GetAllCompetitionQuestionByCompetitionId(int competitionId);
        Task<CompetitionQuestion> GetAllCompetitionQuestionById(int Id);
        Task<CompetitionQuestion> GetAllCompetitionQuestionByQuestionId(int competitionId, int questionId);
        Task<int> GetCountCompetitionQuestionByCompetitionId(int competitionId);
        Task<CompetitionQuestion> UpdateCompetitionQuestion(CompetitionQuestion competitionQuestion);
    }
}
