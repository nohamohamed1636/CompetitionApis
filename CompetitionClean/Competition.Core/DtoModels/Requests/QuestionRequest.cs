using Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class QuestionRequest
    {
        public int QuestionId { get; set; }
        public QuestionsTypes Type { get; set; }
        public int CorrectionMark { get; set; }
        public int AnswerDuration { get; set; }
        public bool IsGold { get; set; }
    }
}
