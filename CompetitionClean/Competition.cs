using System;

public class Class1
{
    public int Id { get; set; }

    public int? SchoolBranchId { get; set; }

    public string Title { get; set; }

    public string UserId { get; set; }

    public DateTime? PublishDate { get; set; }

    public bool Published { get; set; } = false;

    public bool Approved { get; set; } = false;

    public ExamsTypesList Type { get; set; } = 6;

    public double? FullMark { get; set; }

    public int QuestionsCount { get; set; }

    public int? AnsweringDuration { get; set; }

    public bool publishFree { get; set; } = false;

    public bool Deleted { get; set; } = false;

    public DateTime CreatedOnUtc { get; set; }

    public int StaticDuration { get; set; }


    //public virtual ICollection<CompetitionQuestion> CompetitionQuestions { get; set; }

    //public virtual ICollection<CompetitionTarget> CompetitionTargets { get; set; }
}
