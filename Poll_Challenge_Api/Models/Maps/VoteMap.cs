using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Poll_Challenge_Api.Models.Maps
{
    public class VoteMap : IEntityTypeConfiguration<Vote>
    {
        public void Configure(EntityTypeBuilder<Vote> builder)
        {
            builder.ToTable("votes");

            builder
                .HasKey(v => v.VoteId);

            builder
                .Property(v => v.VoteId)
                .HasColumnName("vote_id")
                .IsRequired();

            builder
                .Property(v => v.OptionId)
                .HasColumnName("option_id")
                .IsRequired();

            builder
                .Property(v => v.Qty)
                .HasColumnName("qty");
        }
    }
}
