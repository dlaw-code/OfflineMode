using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string UserId { get; set; }



        public ApplicationUser User { get; set; }

        public class StudentConfig : IEntityTypeConfiguration<Student>
        {
            public void Configure(EntityTypeBuilder<Student> builder)
            {
                builder.HasKey(s => s.Id);

                builder.Property(s => s.UserId)
                       .IsRequired();

                builder.HasOne(s => s.User)
                       .WithOne()
                       .HasForeignKey<Student>(s => s.UserId)
                       .OnDelete(DeleteBehavior.Cascade);
            }
        }
    }
}
