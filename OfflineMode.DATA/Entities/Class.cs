using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Class
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeaxcherId { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public DateTime DateTime {  get; set; } = DateTime.UtcNow;
        public string Location { get; set; }

        public Course Course { get; set; }

        public class ClassConfig : IEntityTypeConfiguration<Class>
        {
            public void Configure(EntityTypeBuilder<Class> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.StartDate)
                       .IsRequired();

                builder.Property(c => c.DateTime)
                       .IsRequired();

                builder.Property(c => c.Location)
                       .HasMaxLength(255) // Adjust the maximum length based on your requirements
                       .IsRequired();

                builder.HasOne(c => c.Course)
                       .WithMany()
                       .HasForeignKey(c => c.CourseId)
                       .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
