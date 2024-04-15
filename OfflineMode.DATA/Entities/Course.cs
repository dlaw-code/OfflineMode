using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace OfflineMode.DATA.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        
       
        public ApplicationUser User { get; set; }

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

                //Define foreign key relationship
                builder.HasOne(c => c.User)
                       .WithMany()
                       .HasForeignKey(c => c.UserId)
                       .IsRequired()
                       .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.Cascade depending on your requirement
            }
        }

    }
}
