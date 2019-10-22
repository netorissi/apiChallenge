using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Poll_Challenge_Api.Models.Maps
{
    public class OptionMap : IEntityTypeConfiguration<Option>
    {
        public void Configure(EntityTypeBuilder<Option> builder)
        {
            builder.ToTable("options");

            builder
                .HasKey(o => o.OptionId);

            builder
                .Property(o => o.OptionId)
                .HasColumnName("option_id")
                .IsRequired();

            builder
                .Property(o => o.PollId)
                .HasColumnName("poll_id")
                .IsRequired();

            builder
                .Property(o => o.Description)
                .HasColumnName("option_description")
                .IsRequired();

        }
    }
}
