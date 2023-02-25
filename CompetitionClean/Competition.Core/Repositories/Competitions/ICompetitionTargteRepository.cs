using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Competitions
{
    public interface ICompetitionTargteRepository
    {
        Task<CompetitionTarget> AddNewCompetitionTarget(CompetitionTarget competitionTarget);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionId(int competitionId);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdnotClosed(int competitionId);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdUnsolved(int competitionId);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByCompetitionIdUnsolvedwithStartedDate(int competitionId);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByStudentIdSolved(string studentId);
        Task<List<CompetitionTarget>> GetAllCompetitionTargetByStudentIdUnSolved(string studentId);
        Task<List<CompetitionTarget>> GetCompetitionTargetByStudentIdAndCompetitionId(int competitionId, string studentId);
        Task SaveChangesAsync();
        Task<CompetitionTarget> UpdateCompetitionTarget(CompetitionTarget competitionTarget);
    }
}
