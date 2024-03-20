using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OfflineMode.DATA.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineMode.DATA.Entities
{
    public class Attendance
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string UserId { get; set; }
        public AttendanceStatus AttendanceStatus { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;

        public Class Class { get; set; }

        public class AttendanceConfig : IEntityTypeConfiguration<Attendance>
        {
            public void Configure(EntityTypeBuilder<Attendance> builder)
            {
                builder.HasKey(a => a.Id);

                builder.Property(a => a.UserId)
                       .IsRequired();

                builder.Property(a => a.Date)
                       .IsRequired();

                builder.HasOne(a => a.Class)
                       .WithMany()
                       .HasForeignKey(a => a.ClassId)
                       .OnDelete(DeleteBehavior.Cascade);

                
            }
        }
    }
}
