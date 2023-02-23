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

        [HttpPost]
        public async Task<IActionResult> CreateNewCompetition(NewCompetition NewCompetition)
        {
            var result = await _competitionService.CreateNewCompetition(NewCompetition);
            return Ok(result);
        }

    }
}
