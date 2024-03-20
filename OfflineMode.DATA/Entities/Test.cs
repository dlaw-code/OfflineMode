using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Test
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public int MaxScore { get; set; }

        public class TestConfig : IEntityTypeConfiguration<Test>
        {
            public void Configure(EntityTypeBuilder<Test> builder)
            {
                builder.HasKey(t => t.Id);

                builder.Property(t => t.Title)
                       .HasMaxLength(255) // Adjust the maximum length based on your requirements
                       .IsRequired();

                builder.Property(t => t.Description)
                       .IsRequired();

                builder.Property(t => t.Date)
                       .IsRequired();

                builder.Property(t => t.MaxScore)
                       .IsRequired();
            }
        }

    }
}
