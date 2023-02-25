using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Dtos
{
    public class CompetitionStudentIndex
    {
        public int CompetitionId { get; set; }
        public string Title { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? DelivaryDate { get; set; }
        public int HomeWorkId { get; set; }
        public DateTime? StartDate { get; set; }

    }
}
