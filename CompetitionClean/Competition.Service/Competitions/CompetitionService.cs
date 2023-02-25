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
        private readonly ICompetitionAnswerRepository _competitionAnswerRepository;
        public CompetitionService(ICompetitionRepository competitionRepository, ICompetitionAnswerRepository competitionAnswerRepository)
        {
            _competitionRepository = competitionRepository;
            _competitionAnswerRepository = competitionAnswerRepository;
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


        public async Task<List<CompetitionList>> GetListOfCompetition()
        {
            
            var competitionrep = await _competitionRepository.GetAllCompetition();
            var res = competitionrep.OrderBy(d => d.Id).Select(j=> new CompetitionList { CompetitionId = j.Id,CompetitionName = j.Title});
            return res.ToList();
        }

        public async Task<List<ManageCompetitionList>> ManageCompetition()
        {

            var competitionrep = await _competitionRepository.GetAllCompetitionList();
            var res = competitionrep.OrderBy(d => d.Id)
                .Select(j => new ManageCompetitionList 
                { 
                    Id = j.Id,
                    Title = j.Title,
                    Approved = j.Approved,
                     Published = j.Published,
                     AnsweringDuration = j.AnsweringDuration,
                     CreatedOnUtc = j.CreatedOnUtc,
                     Deleted = j.Deleted,
                     FullMark = j.CompetitionQuestions.Where(e => e.Deleted == false && e.CompetitionId == j.Id).Sum(h=>h.CorrectionMark),
                     //MultipleChoice = j.CompetitionQuestions.Where(e=>e.Deleted == false)
                    //TrueFalse = 
                    PublishDate = j.PublishDate ,
                    publishFree = j.publishFree,
                    StaticDuration = j.StaticDuration,
                    UserId = j.UserId,
                    QuestionsCount = j.QuestionsCount
                });
            return res.ToList();
        }

        public async Task<List<GradeCompetitionList>> GetGradCompetition()
        {

            var competitionrep = await _competitionRepository.GetAllCompetitionList();
            var res = competitionrep.OrderBy(d => d.Id)
                .Select(j => new GradeCompetitionList
                {
                    Id = j.Id,
                    Competition = j.Title,
                    PublishDate = (j.PublishDate != null) ? (DateTime)j.PublishDate : null,
                    CreatedOnUtc = j.CreatedOnUtc
                });
            return res.ToList();
        }
        public async Task<List<GradeCompetitionList>> GetcompetitionByUserId(string userId)
        {

            var competitionrep = await _competitionRepository.GetAllCompetitionList();
            var res = competitionrep.Where(s=>s.UserId == userId).OrderBy(d => d.Id)
                .Select(j => new GradeCompetitionList
                {
                    Id = j.Id,
                    Competition = j.Title,
                    PublishDate = (j.PublishDate != null) ? (DateTime)j.PublishDate : null,
                    CreatedOnUtc = j.CreatedOnUtc
                });
            return res.ToList();
        }

        public async Task<string> UpdateCompetitionIsPublished(int competitionId)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if(competitionrep == null)
                {
                    return "this competition not found";
                }
                competitionrep.Published = true;
                await _competitionRepository.SaveChangesAsync();
                return "Published successfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public async Task<string> UpdateCompetitionPublishedDate(int competitionId)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if (competitionrep == null)
                {
                    return "this competition not found";
                }
                competitionrep.PublishDate = DateTime.Now.ToUniversalTime();
                await _competitionRepository.SaveChangesAsync();
                return "update publish date successfully";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> DeleteCompetition(int competitionId)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if (competitionrep == null)
                {
                    return "this competition not found";
                }
                bool competitionAnswers = await _competitionAnswerRepository.CountCompetitiinAnswer(competitionId) > 0;
                if(!competitionAnswers)
                {
                    foreach (var item in competitionrep.CompetitionQuestions)
                    {
                        item.Deleted = true;
                    }

                    foreach (var item in competitionrep.CompetitionTargets)
                    {
                        item.Deleted = true;
                    }
                    competitionrep.Deleted = true;
                    await _competitionRepository.SaveChangesAsync();
                    return "competition deleted successfully";
                }
                else
                {
                    return "you can't delete this competition this there answer for it";
                }
                
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }

        public async Task<string> UpdateCompetitionStaticDuration(int competitionId, int staticDuration)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if (competitionrep == null)
                {
                    return "this competition not found";
                }
                competitionrep.StaticDuration = staticDuration;
                await _competitionRepository.SaveChangesAsync();
                return "update static duration successfully";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<CheckAttendance> CheckCompetitionForAttendance(int competitionId)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if (competitionrep == null)
                {

                    return new CheckAttendance { Checked = false,  Errors= "this competition not found" };
                }
                if(competitionrep.Published == false)
                {
                    return new CheckAttendance { Checked = false, Errors = "" };
                }
                else
                {
                    return new CheckAttendance { Checked = true, Errors = "" };
                }
               
            }
            catch (Exception ex)
            {
                return new CheckAttendance { Checked = false, Errors = ex.Message };
            }
        }

        public async Task<CheckAttendance> CheckCompetitionForStart(int competitionId)
        {
            try
            {
                var competitionrep = await _competitionRepository.GetCompetitionById(competitionId);
                if (competitionrep == null)
                {

                    return new CheckAttendance { Checked = false, Errors = "this competition not found" };
                }
                if(competitionrep.PublishDate == null)
                {
                    return new CheckAttendance { Checked = false, Errors = "" };
                }
                else
                {
                    if (competitionrep.PublishDate > DateTime.Now.ToUniversalTime() || competitionrep.PublishDate.Value.AddHours(1) != DateTime.Now.ToUniversalTime())
                    {
                        return new CheckAttendance { Checked = false, Errors = "" };
                    }
                    else
                    {
                        return new CheckAttendance { Checked = true, Errors = "" };
                    }
                }
                

            }
            catch (Exception ex)
            {
                return new CheckAttendance { Checked = false, Errors = ex.Message };
            }
        }
    }
}
