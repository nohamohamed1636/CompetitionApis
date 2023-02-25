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
        Task<CheckAttendance> CheckCompetitionForAttendance(int competitionId);
        Task<CheckAttendance> CheckCompetitionForStart(int competitionId);
        Task<CompetitionData> CreateNewCompetition(NewCompetition NewCompetition);
        Task<string> DeleteCompetition(int competitionId);
        Task<List<GradeCompetitionList>> GetcompetitionByUserId(string userId);
        Task<List<GradeCompetitionList>> GetGradCompetition();
        Task<List<CompetitionList>> GetListOfCompetition();
        Task<List<ManageCompetitionList>> ManageCompetition();
        Task<string> UpdateCompetitionIsPublished(int competitionId);
        Task<string> UpdateCompetitionPublishedDate(int competitionId);
        Task<string> UpdateCompetitionStaticDuration(int competitionId, int staticDuration);
    }
}
