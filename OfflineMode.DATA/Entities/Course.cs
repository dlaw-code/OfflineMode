using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public class CourseConfig : IEntityTypeConfiguration<Course>
        {
            public void Configure(EntityTypeBuilder<Course> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Title)
                       .HasMaxLength(255) // Adjust the maximum length based on your requirements
                       .IsRequired();

                builder.Property(c => c.Description)
                       .IsRequired();
            }
        }

    }
}
