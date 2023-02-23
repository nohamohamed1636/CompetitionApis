using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class CompetitionQuestion
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        public int QuestionId { get; set; }

        [DefaultValue(false)]
        public bool MultibleChoice { get; set; }

        [DefaultValue(false)]
        public bool TrueFalse { get; set; }
        public int? DisplayOrder { get; set; }
        public double? CorrectionMark { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public int AnswerDuration { get; set; }

        [ForeignKey("CompetitionId")]
        public virtual Competition Competitions { get; set; }

       public virtual ICollection<CompetitionAnswer> CompetitionAnswers { get; set; }
    }
}
