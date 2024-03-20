using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OfflineMode.DATA.Entities.Enums;

namespace OfflineMode.DATA.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set;}

        public AssignmentStatusEntity AssignmentStatus { get; set; }

        public Course Course { get; set; }


        public class AssignmentConfig : IEntityTypeConfiguration<Assignment>
        {
            public void Configure(EntityTypeBuilder<Assignment> builder)
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.Title)
                       .IsRequired()
                       .HasMaxLength(100); // Adjust the maximum length based on your requirements

                builder.Property(a => a.Description)
                       .IsRequired();

                builder.Property(a => a.DueDate)
                       .IsRequired();

                builder.HasOne(a => a.Course)
                       .WithMany()
                       .HasForeignKey(a => a.CourseId)
                       .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
