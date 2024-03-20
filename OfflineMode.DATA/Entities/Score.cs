using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Score
    {
        public int Id { get; set; }
        public int TestId { get; set; }
        public string UserId { get; set; }
        public int ScoreValue { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public class ScoreConfig : IEntityTypeConfiguration<Score>
        {
            public void Configure(EntityTypeBuilder<Score> builder)
            {
                builder.HasKey(s => s.Id);

                builder.Property(s => s.UserId)
                       .IsRequired();

                builder.Property(s => s.ScoreValue)
                       .IsRequired();

                builder.Property(s => s.Date)
                       .IsRequired();
            }
        }
    }
}
