using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using Core.Models;
using Core.Repositories.Competitions;
using Core.Services.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Competitions
{
    public class CompetitionService : ICompetitionService
    {
        private readonly ICompetitionRepository _competitionRepository;
        public CompetitionService(ICompetitionRepository competitionRepository)
        {
            _competitionRepository = competitionRepository;
        }


        public async Task<CompetitionData> CreateNewCompetition(NewCompetition NewCompetition)
        {
            var competition = new CompetitionData();
            var validation = ValidationInsert(NewCompetition);
            if (validation != "")
            {
                competition.Error = validation;
                return competition;
            }

            var newCompetition = new Competition
            {
                Title = NewCompetition.Title,
                StaticDuration = NewCompetition.StaticDuration,
                CreatedOnUtc = DateTime.Now.ToUniversalTime(),
                FullMark = 1,
                UserId = "f92e9660-7cad-49f3-872e-996cc0564d7c"
            };
            var competitionrep = await _competitionRepository.AddNewCompetition(newCompetition);
            competition.CompetitionId = competitionrep.Id;
            return competition;

        }
        private string ValidationInsert(NewCompetition NewCompetition)
        {
            if (String.IsNullOrEmpty(NewCompetition.Title))
            {
                return "Please insert the title of Competition";
            }
            else if(NewCompetition.StaticDuration == default(int))
            {
                return "Please insert the static duration";
            }
            else
            {
                return "";
            }
        }
    }
}
