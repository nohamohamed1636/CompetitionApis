using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Dtos
{
    public class QuestionData
    {
        public int CompetitionId { get; set; }
        public int QuestionId { get; set; }
        public int DisplayOrder { get; set; }
        public int Count { get; set; }
        public int RemainTime { get; set; }
        public DateTime QuestionTime { get; set; }

        public string Message { get; set; }
    }
}
