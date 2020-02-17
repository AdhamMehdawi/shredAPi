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
            builder.Property(e => e.FileContent).HasColumnName("FILE_CONTENT");
    }
    }
}
