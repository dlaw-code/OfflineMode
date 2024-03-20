using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public class TeacherConfig : IEntityTypeConfiguration<Teacher>
        {
            public void Configure(EntityTypeBuilder<Teacher> builder)
            {
                builder.HasKey(t => t.Id);

                builder.Property(t => t.UserId)
                       .IsRequired();
            }
        }

    }
}
