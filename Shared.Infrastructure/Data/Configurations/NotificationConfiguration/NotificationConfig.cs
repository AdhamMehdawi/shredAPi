using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities;

namespace Shared.Infrastructure.Data.Configurations.NotificationConfiguration
{
    public class NotificationConfig : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> entity)
        {
            entity.ToTable("NOTIFICATION");
            entity.HasKey(e => e.Id); 
            entity.Property(e => e.Title)
                .IsRequired();  
            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Title).HasColumnName("TITLE");
            entity.Property(e => e.Body).HasColumnName("BODY");
            entity.Property(e => e.FromUser).HasColumnName("FROM_USER");
            entity.Property(e => e.RedirectUrl).HasColumnName("REDIRECT_URL");
            entity.Property(e => e.ToUser).HasColumnName("TO_USER"); 
            entity.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            entity.Property(e => e.LastModifiedTime).HasColumnName("LAST_MODIFIED_TIME");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            entity.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
        }
    }
}
