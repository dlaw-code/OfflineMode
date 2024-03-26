using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OfflineMode.DATA.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public string UserId { get; set; }

        public class CourseConfig : IEntityTypeConfiguration<Course>
        {
            public void Configure(EntityTypeBuilder<Course> builder)
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Title)
                       .HasMaxLength(255)
                       .IsRequired();

                builder.Property(c => c.Description)
                       .IsRequired();
            }
        }

    }
}
