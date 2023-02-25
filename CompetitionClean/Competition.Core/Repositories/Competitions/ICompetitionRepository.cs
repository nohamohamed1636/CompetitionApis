using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories.Competitions
{
    public interface ICompetitionRepository
    {
        Task<Competition> AddNewCompetition(Competition newCompetition);
        Task<List<Competition>> GetAllCompetition();
        Task<List<Competition>> GetAllCompetitionList();
        Task<Competition> GetCompetitionById(int competitionId);
        Task SaveChangesAsync();
        Task<Competition> UpdateUser(Competition competition);
    }
}
