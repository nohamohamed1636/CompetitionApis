using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Competitions
{
    public interface ICompetitionQuestionService
    {
        Task<CompetitionData> CreateNewCompetitionQuestion(NewCompetitionQuestion newCompetitionQuestion);
        Task<QuestionData> GetQuestion(int competitionId, string studentId);
    }
}
