using Azure;
using Core.DtoModels.Requests;
using Core.Services.Competitions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Competition.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompetitionController : ControllerBase
    {
        private readonly ICompetitionService _competitionService;
        public CompetitionController(ICompetitionService competitionService)
        {
            _competitionService = competitionService;
        }

        [HttpPost("CreateNewCompetition")]
        public async Task<IActionResult> CreateNewCompetition(NewCompetition NewCompetition)
        {
            var result = await _competitionService.CreateNewCompetition(NewCompetition);
            return Ok(result);
        }

        [HttpGet("GetCompetitionList")]
        public async Task<IActionResult> GetCompetitionList()
        {
            var result = await _competitionService.GetListOfCompetition();
            return Ok(result);
        }

        [HttpGet("ManageCompetition")]
        public async Task<IActionResult> ManageCompetition()
        {
            var result = await _competitionService.ManageCompetition();
            return Ok(result);
        }

        [HttpGet("GetGradCompetition")]
        public async Task<IActionResult> GetGradCompetition()
        {
            var result = await _competitionService.ManageCompetition();
            return Ok(result);
        }

        [HttpGet("CompetitionTeacherIndex")]
        public async Task<IActionResult> CompetitionTeacherIndex(string userId)
        {
            var result = await _competitionService.GetcompetitionByUserId(userId);
            return Ok(result);
        }


    }
}
