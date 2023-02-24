using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Competitions
{
    public interface ICompetitionService
    {
        Task<CompetitionData> CreateNewCompetition(NewCompetition NewCompetition);
        Task<List<GradeCompetitionList>> GetcompetitionByUserId(string userId);
        Task<List<GradeCompetitionList>> GetGradCompetition();
        Task<List<CompetitionList>> GetListOfCompetition();
        Task<List<ManageCompetitionList>> ManageCompetition();
    }
}
