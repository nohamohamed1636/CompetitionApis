using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Competition> Competitions { get; set; }
        public virtual DbSet<CompetitionTarget> CompetitionTargets { get; set; }
        public virtual DbSet<CompetitionQuestion> CompetitionQuestions { get; set; }
        public virtual DbSet<CompetitionAnswer> CompetitionAnswers { get; set; }
    }
}
