using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class UpdateQuestionRequest
    {
        public int CompetitionId { get; set; }
        public int QuestionId { get; set; }
        public int AnswerDuration { get; set; }

    }
}
