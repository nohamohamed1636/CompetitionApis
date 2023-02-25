using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Dtos
{
    public class GradeCompetitionList
    {
        public int Id { get; set; }
        public string Competition { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime CreatedOnUtc { get; set; }
    }
}
