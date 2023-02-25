using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class NewCompetitionTarget
    {
        public int CompetitionId { get; set; }
        public int? EducationClassRoomId { get; set; }
        public string StudentId { get; set; }
        public int? StudentHistoryId { get; set; }
    }
}
