using Core.DtoModels.Requests;
using Core.Services.Competitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Competitions;

namespace Competition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionTargetController : ControllerBase
    {
        private readonly ICompetitiontargetService _competitiontargetService;

        public CompetitionTargetController(ICompetitiontargetService competitiontargetService)
        {
            _competitiontargetService = competitiontargetService;
        }

        [HttpPost("CreateNewCompetitionTargetForStudent")]
        public async Task<IActionResult> CreateNewCompetitionTargetForStudent(NewCompetitionTarget NewCompetitionTarget)
        {
            var result = await _competitiontargetService.CreateNewCompetitionTargetForStudent(NewCompetitionTarget);
            return Ok(result);
        }

        [HttpPost("CreateNewCompetitionTargetForStudentList")]
        public async Task<IActionResult> CreateNewCompetitionTargetForStudentList(NewCompetitionTargetList NewCompetitionTarget)
        {
            var result = await _competitiontargetService.CreateNewCompetitionTargetForStudentList(NewCompetitionTarget);
            return Ok(result);
        }

        [HttpGet("GetListOfCompetitionStudentIndexUnsolved")]
        public async Task<IActionResult> GetListOfCompetitionStudentIndexUnsolved(string studentID)
        {
            var result = await _competitiontargetService.GetListOfCompetitionStudentIndexUnsolved(studentID);
            return Ok(result);
        }

        [HttpPost("UpdateStartDate")]
        public async Task<IActionResult> UpdateStartDate(int competitionId, string studentId)
        {
            var result = await _competitiontargetService.UpdateStartDate(competitionId,studentId);
            return Ok(result);
        }

        [HttpGet("GetStudentListForTeacher")]
        public async Task<IActionResult> GetStudentListForTeacher(int competitionId)
        {
            var result = await _competitiontargetService.GetStudentListForTeacher(competitionId);
            return Ok(result);
        }

        [HttpGet("CloseCompetitionForStudent")]
        public async Task<IActionResult> CloseCompetitionForStudent(int competitionId)
        {
            var result = await _competitiontargetService.CloseCompetitionForStudent(competitionId);
            return Ok(result);
        }

    }
}
