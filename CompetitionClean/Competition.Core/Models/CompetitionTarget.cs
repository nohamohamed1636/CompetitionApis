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
    public class CompetitionTarget
    {
        public int Id { get; set; }
        public int CompetitionId { get; set; }
        //public int? EducationYearClassroomId { get; set; }
        public string StudentId { get; set; }
        //public string TeacherId { get; set; }

        public int? StudentHistoryId { get; set; }

        [DefaultValue(false)]
        public bool Solved { get; set; }

        public DateTime? StarDate { get; set; }

        public string IpAddress { get; set; }

        public DateTime? DeliveryDate { get; set; }

        [DefaultValue(0.0)]
        public double Degree { get; set; }

        public double? PercentScore { get; set; }

        public string ResultGrade { get; set; }

        [DefaultValue(false)]
        public bool Deleted { get; set; }

        [DefaultValue(true)]
        public bool Absent { get; set; }

        [DefaultValue(false)]
        public bool Opened { get; set; }

        [DefaultValue(false)]
        public bool Closed { get; set; }

        public int Started { get; set; } = 0;

        [ForeignKey("CompetitionId")]
        public virtual Competition Competitions { get; set; }

       public virtual ICollection<CompetitionAnswer> CompetitionAnswers { get; set; }
    }
}
