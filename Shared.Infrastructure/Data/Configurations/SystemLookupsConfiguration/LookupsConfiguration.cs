using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities;

namespace Shared.Infrastructure.Data.Configurations.SystemLookupsConfiguration
{ 
    public class LookupsConfiguration : IEntityTypeConfiguration<Lookups>
    {
        public void Configure(EntityTypeBuilder<Lookups> entity)
        {
            entity.ToTable("LOOKUPS");
            entity.HasIndex(e => e.LookupTypeId);

            entity.Property(e => e.CreatedDate).HasColumnType("date");

            entity.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.UpdateDate).HasColumnType("date");

            entity.HasOne(d => d.LookupType)
                .WithMany(p => p.Lookups)
                .HasForeignKey(d => d.LookupTypeId);

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate).HasColumnName("CREATED_DATE");
            entity.Property(e => e.IsPrimary).HasColumnName("IS_PRIMARY");
            entity.Property(e => e.Value).HasColumnName("VALUE");
            entity.Property(e => e.LookupTypeId).HasColumnName("LOOKUP_TYPE_ID");
            entity.Property(e => e.ParentId).HasColumnName("PARENT_ID");
            entity.Property(e => e.Code).HasColumnName("CODE");
            entity.Property(e => e.Title).HasColumnName("TITLE");
              entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            entity.Property(e => e.UpdateDate).HasColumnName("UPDATE_DATE");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
        }
    }
}
