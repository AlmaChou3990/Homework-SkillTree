using Homework_SkillTree.Models;
using Microsoft.EntityFrameworkCore;

namespace Homework_SkillTree.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<AccountingRecord> AccountingRecord { get; set; }
    }
}
