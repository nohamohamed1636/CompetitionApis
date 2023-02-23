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
    public class CompetitionAnswer
    {
        public int Id { get; set; }

        public int CompetitionTargetId { get; set; }

        public int CompetitonQuestionId { get; set; }

       
        public string Answer { get; set; }

        public bool? RightAnswer { get; set; }

        public double? Mark { get; set; }

        [DefaultValue(false)]
        public bool Corrected { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }
        public DateTime? createdDate { get; set; }

        [ForeignKey("CompetitionTargetId")]
        public virtual CompetitionTarget CompetitionTargets { get; set; }
        [ForeignKey("CompetitonQuestionId")]
        public virtual CompetitionQuestion CompetitionQuestions { get; set; }
    }
}
