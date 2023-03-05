using Core.DtoModels.Requests;
using Core.Services.Competitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Competitions;

namespace Competition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionQuestionController : ControllerBase
    {
        private readonly ICompetitionQuestionService _competitionQuestionService;
        public CompetitionQuestionController(ICompetitionQuestionService competitionQuestionService)
        {
            _competitionQuestionService = competitionQuestionService;
        }

        [HttpPost("CreateNewCompetitionQuestion")]
        public async Task<IActionResult> CreateNewCompetition(NewCompetitionQuestion newCompetitionQuestion)
        {
            var result = await _competitionQuestionService.CreateNewCompetitionQuestion(newCompetitionQuestion);
            return Ok(result);
        }

        [HttpGet("GetQuestion")]
        public async Task<IActionResult> GetQuestion(int competitionId, string studentId)
        {
            var result = await _competitionQuestionService.GetQuestion(competitionId, studentId);
            return Ok(result);
        }
    }
}
