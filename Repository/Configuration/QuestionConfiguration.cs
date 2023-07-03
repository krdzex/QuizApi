using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration;
public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        builder.HasKey(q => q.Id);
        builder.Property(q => q.Text).IsRequired().HasMaxLength(1000);
        builder.Property(q => q.Answer).IsRequired().HasMaxLength(1000);
    }
}