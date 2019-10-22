using Microsoft.EntityFrameworkCore;
using Poll_Challenge_Api.Models.Maps;

namespace Poll_Challenge_Api.Models
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
        }

        public DbSet<Poll> Polls { get; set; }

        public DbSet<Option> Options { get; set; }

        public DbSet<Vote> Votes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PollMap());
            modelBuilder.ApplyConfiguration(new OptionMap());
            modelBuilder.ApplyConfiguration(new VoteMap());
        }
    }

}
