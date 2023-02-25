using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Competitions
{
    public interface ICompetitiontargetService
    {
        Task<CheckAttendance> CloseCompetitionForStudent(int competitionId);
        Task<CompetitionData> CreateNewCompetitionTargetForStudent(NewCompetitionTarget NewCompetitionTarget);
        Task<CompetitionData> CreateNewCompetitionTargetForStudentList(NewCompetitionTargetList NewCompetitionTarget);
        Task<List<CompetitionStudentIndex>> GetListOfCompetitionStudentIndexUnsolved(string studentId);
        Task<StudentAttendanceList> GetStudentListForTeacher(int competitionId);
        Task<CheckAttendance> UpdateStartDate(int competitionId, string studentId);
    }
}
