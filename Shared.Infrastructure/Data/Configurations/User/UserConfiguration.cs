using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Shared.Infrastructure.Data.Configurations.User
{
    public class UserConfiguration : IEntityTypeConfiguration<Core.Entities.User>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.User> entity)
        {

            entity.ToTable("USERS_TBL");

            entity.HasIndex(e => e.EmployeeId);
            entity.Property(e => e.EmployeeId).HasColumnName("EMPLOYEE_ID");
            entity.Property(e => e.CreateDate).HasColumnName("CREATE_DATE");
            entity.Property(e => e.UpdateDate).HasColumnName("UPDATE_DATE");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            entity.Property(e => e.NeedResetPassword).HasColumnName("NEED_RESET_PASSWORD");
            entity.Property(e => e.ResetTokenExDate).HasColumnName("RESET_TOKEN_EX_DATE");
            entity.Property(e => e.IsSuperAdmin).HasColumnName("IS_SUPER_ADMIN");
            entity.Property(e => e.ResetToken).HasColumnName("RESET_TOKEN");
            entity.Property(e => e.FullName).HasColumnName("FULL_NAME");
            entity.Property(e => e.PassExpireDate).HasColumnName("PASS_EXPIRE_DATE");
            entity.Property(e => e.Email).HasColumnName("EMAIL");
            entity.Property(e => e.Password).HasColumnName("PASSWORD");
            entity.Property(e => e.Username).HasColumnName("USER_NAME");
            entity.Property(e => e.Id).HasColumnName("ID");
           
            entity.HasOne(d => d.Employee)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.EmployeeId);
        }
    }
}
