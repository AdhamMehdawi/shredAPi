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
            builder.HasQueryFilter(c => c.IsDeleted == false);
            builder.HasIndex(e => e.ParentId);
            builder.Property(e => e.Id).ValueGeneratedNever();
            builder.HasOne(d => d.Parent)
                .WithMany(p => p.InverseParent)
                .HasForeignKey(d => d.ParentId);

            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.Title).HasColumnName("TITLE");
            builder.Property(e => e.ParentId).HasColumnName("PARENT_ID");
            builder.Property(e => e.Editable).HasColumnName("EDITABLE");
            builder.Property(e => e.CreatedAt).HasColumnType("date");
            builder.Property(e => e.LastModifiedTime).HasColumnType("date");
            builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            builder.Property(e => e.LastModifiedTime).HasColumnName("LAST_MODIFIED_TIME");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
        }
    }
}
