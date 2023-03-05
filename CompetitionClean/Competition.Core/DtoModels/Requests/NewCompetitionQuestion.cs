using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class NewCompetitionQuestion
    {
        public int CompetitionId { get; set; }
        public List<QuestionRequest> QuestionRequests { get; set; }
    }
}
