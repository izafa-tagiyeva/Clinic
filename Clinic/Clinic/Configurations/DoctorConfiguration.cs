using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Clinic.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctors>
    {
        public void Configure(EntityTypeBuilder<Doctors> builder)
        {
            builder.HasOne(a => a.Department)
            .WithMany()
            .HasForeignKey(a => a.DepartmentId)
            .IsRequired();

            builder.Property(n => n.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(n=> n.Surname)
                 .IsRequired()
                .HasMaxLength(100);

            builder.Property(g => g.CoverImage)
                .IsRequired();
        }
    }
}
