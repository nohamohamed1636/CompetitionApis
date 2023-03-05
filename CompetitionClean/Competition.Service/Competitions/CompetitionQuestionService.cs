using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using Core.Models;
using Core.Models.Context;
using Core.Repositories.Competitions;
using Core.Services.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Competitions
{
    public class CompetitionQuestionService : ICompetitionQuestionService
    {
        private readonly ICompetitionQuestionRepository _competitionQuestionRepository;
        private readonly ICompetitionTargteRepository _competitionTargteRepository;
        private readonly ICompetitionAnswerRepository _competitionAnswerRepository;
        public CompetitionQuestionService(ICompetitionQuestionRepository competitionQuestionRepository, ICompetitionTargteRepository competitionTargteRepository
            , ICompetitionAnswerRepository competitionAnswerRepository)
        {
            _competitionQuestionRepository = competitionQuestionRepository;
            _competitionTargteRepository = competitionTargteRepository;
            _competitionAnswerRepository = competitionAnswerRepository;
        }

        public async Task<CompetitionData> CreateNewCompetitionQuestion(NewCompetitionQuestion newCompetitionQuestion)
        {
            var competition = new CompetitionData();
            var validation = ValidationInsert(newCompetitionQuestion);
            if (validation != "")
            {
                competition.Error = validation;
                return competition;
            }

           
           
            bool isTrueFalse = false;
            bool isMultiple = false;

            int displayOrder = 1;
            var questionCompetitionData =await _competitionQuestionRepository.GetCountCompetitionQuestionByCompetitionId(newCompetitionQuestion.CompetitionId);
            displayOrder = displayOrder + questionCompetitionData;

            foreach (var item in newCompetitionQuestion.QuestionRequests)
            {
                switch (item.Type)
                {
                    case Core.Enums.QuestionsTypes.MultipleChoice:
                        isMultiple = true;
                        isTrueFalse = false;
                        break;
                    case Core.Enums.QuestionsTypes.TrueFalse:
                        isTrueFalse = true;
                        isMultiple = false;
                        break;
                    default:
                        break;
                }
                var newQuestion = new CompetitionQuestion
                {
                    CompetitionId = newCompetitionQuestion.CompetitionId,
                    QuestionId = item.QuestionId,
                    CorrectionMark = item.CorrectionMark,
                    AnswerDuration = item.AnswerDuration,
                    IsGold = item.IsGold,
                    Deleted = false,
                    MultibleChoice = isMultiple,
                    TrueFalse = isTrueFalse,
                    DisplayOrder = displayOrder
                };
                var competitionrep = await _competitionQuestionRepository.AddNewCompetitionQuestion(newQuestion);
                //competition.CompetitionId = competitionrep.Id;
            }
            return competition;


        }
        private string ValidationInsert(NewCompetitionQuestion newCompetitionQuestion)
        {
            if (newCompetitionQuestion.CompetitionId == default(int))
            {
                return "Please insert the Competition Id";
            }
            else if (newCompetitionQuestion.QuestionRequests.Count == 0)
            {
                return "Please insert at least one question";
            }
            else
            {
                return "";
            }
        }


        public async Task<QuestionData> GetQuestion(int competitionId,string studentId)
        {
            QuestionData questionData = null;
            DateTime? QuestionTime = null;
            var getquestionList = await _competitionQuestionRepository.GetAllCompetitionQuestionByCompetitionId(competitionId);
            var gettargetData = await _competitionTargteRepository.GetCompetitionTargetByStudentIdAndCompetitionId(competitionId, studentId);

            var publisDate = gettargetData.FirstOrDefault().Competitions.PublishDate.Value;

            QuestionTime = (publisDate != null) ? new DateTime(publisDate.Year, publisDate.Month, publisDate.Day, publisDate.Hour, publisDate.Minute, publisDate.Second) : DateTime.Now;

            foreach (var item in getquestionList)
            {
                QuestionTime = QuestionTime.Value.AddSeconds(item.AnswerDuration);
                if(item.DisplayOrder != 1)
                {
                    QuestionTime = QuestionTime.Value.AddSeconds(item.Competitions.StaticDuration);
                }
                TimeSpan remain = QuestionTime.Value - DateTime.Now;
                int timeRemain = Convert.ToInt32(remain.TotalSeconds);
                var isAnswer = _competitionAnswerRepository.GetCompetitionAnswer(item.Id, gettargetData.FirstOrDefault().Id);
                if(QuestionTime.Value > DateTime.Now)
                {
                    if(isAnswer == null)
                    {
                        questionData = new QuestionData
                        {
                            QuestionId = item.QuestionId,
                            CompetitionId = competitionId,
                            DisplayOrder = 1,
                            Count = getquestionList.Count,
                            QuestionTime = QuestionTime.Value,
                            RemainTime = timeRemain
                        };
                        return questionData;
                    }
                }
                else
                {
                    return questionData;
                }

            }
            return questionData;
        }
        public async Task<CompetitionData> UpdateCompetitionQuestion(int competitionId, int questionId)
        {
            CompetitionData competitionData = null;
            var getQuestion = _competitionQuestionRepository.GetAllCompetitionQuestionByQuestionId(competitionId, questionId);
            if (getQuestion == null) { competitionData = new CompetitionData {Error="there isn't ant question of this competition" }; }

        }

    }
}
