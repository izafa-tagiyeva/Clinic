using Clinic.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.Hosting;

namespace Clinic.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasMany<Doctors>()
           .WithOne(e => e.Department)
           .HasForeignKey(e => e.DepartmentId)
           .IsRequired();


            builder.Property(n => n.DepartmentName)
                .IsRequired()
                .HasMaxLength(100);


        }
    }
}
