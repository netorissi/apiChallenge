using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Poll_Challenge_Api.Models.Maps
{
    public class PollMap : IEntityTypeConfiguration<Poll>
    {
        public void Configure(EntityTypeBuilder<Poll> builder)
        {
            builder.ToTable("polls");

            builder
                .HasKey(p => p.PollId);

            builder
                .Property(p => p.PollId)
                .HasColumnName("poll_id")
                .IsRequired();

            builder
                .Property(p => p.PollDescription)
                .HasColumnName("poll_description")
                .IsRequired();

            builder
                .Property(p => p.Views)
                .HasColumnName("views");

            builder
                .HasMany(o => o.Options)
                .WithOne(p => p.Poll)
                .HasForeignKey(o => o.PollId)
                .IsRequired();
        }
    }
}
