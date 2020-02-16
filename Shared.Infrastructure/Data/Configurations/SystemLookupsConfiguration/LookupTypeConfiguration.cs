using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities;

namespace Shared.Infrastructure.Data.Configurations.SystemLookupsConfiguration
{
    public class LookupTypeConfiguration : IEntityTypeConfiguration<LookupTypes>
    {
        public void Configure(EntityTypeBuilder<LookupTypes> builder)
        {
            builder.ToTable("LOOKUP_TYPES");
            builder.HasIndex(e => e.ParentId);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Title).HasColumnName("TITLE");
            builder.Property(e => e.ParentId).HasColumnName("PARENT_ID");
            builder.Property(e => e.Editable).HasColumnName("EDITABLE");
        }
    }
}
