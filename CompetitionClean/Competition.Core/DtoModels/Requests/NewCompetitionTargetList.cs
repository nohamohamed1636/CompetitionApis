using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class NewCompetitionTargetList
    {
        public int CompetitionId { get; set; }
        public List<StudentList> StudentLists { get; set; }

    }
}
