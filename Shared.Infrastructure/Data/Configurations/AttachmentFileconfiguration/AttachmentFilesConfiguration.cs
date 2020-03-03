using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities;

namespace Shared.Infrastructure.Data.Configurations.AttachmentFileconfiguration
{
    public class AttachmentFilesConfiguration : IEntityTypeConfiguration<AttachmentFiles>
    {
        public void Configure(EntityTypeBuilder<AttachmentFiles> builder)
        {
            builder.ToTable("ATTACHMENT_FILE");
            builder.HasKey(key => key.Id);
            builder.Property(p => p.FileName)
                .IsRequired();
            builder.Property(p => p.FileExtension)
                .IsRequired();
            builder.Property(e => e.Id).HasColumnName("ID");
            builder.Property(e => e.FileName).HasColumnName("FILE_NAME");
            builder.Property(e => e.FileExtension).HasColumnName("FILE_EXTENSION");
            builder.Property(e => e.FileSize).HasColumnName("FILE_SIZE");
            builder.Property(e => e.FileContentData).HasColumnName("FILE_CONTENT_DATA");
            builder.Property(e => e.FileContentData).HasColumnType("CLOB");
            builder.Property(e => e.CreatedAt).HasColumnName("CREATED_AT");
            builder.Property(e => e.LastModifiedTime).HasColumnName("LAST_MODIFIED_TIME");
            builder.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            builder.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
            builder.Property(e => e.LastModifiedBy).HasColumnName("LAST_MODIFIED_BY");
        }
    }
}
