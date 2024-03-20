using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Enrollment
    {
        public int Id { get; set; }
        public string UserId { get; set; }

        public class EnrollmentConfig : IEntityTypeConfiguration<Enrollment>
        {
            public void Configure(EntityTypeBuilder<Enrollment> builder)
            {
                builder.HasKey(e => e.Id);

                builder.Property(e => e.UserId)
                       .IsRequired();
            }
        }

    }
}
