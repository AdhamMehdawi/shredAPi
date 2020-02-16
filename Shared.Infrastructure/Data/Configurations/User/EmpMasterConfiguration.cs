using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shared.Core.Entities;

namespace Shared.Infrastructure.Data.Configurations.User
{
    public class EmpMasterConfiguration : IEntityTypeConfiguration<EmpMaster>
    {
        public void Configure(EntityTypeBuilder<EmpMaster> entity)
        {
            entity.ToTable("EMP_MASTER");

            entity.HasIndex(e => e.EmpNo)
                .IsUnique();

            entity.HasIndex(e => e.GenderId);

            entity.HasIndex(e => e.IdNo)
                .IsUnique();

            entity.HasIndex(e => e.IdTypeId);

            entity.HasIndex(e => e.MartialStatusId);


            entity.HasIndex(e => e.DepId);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.IdNo)
                .IsRequired()
                .HasMaxLength(15);

            entity.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(150);


            entity.Property(e => e.SecondName)
                .IsRequired()
                .HasMaxLength(150);

            entity.Property(e => e.ThirdName)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasOne(d => d.Gender)
                .WithMany(p => p.HrmEmpMasterGender)
                .HasForeignKey(d => d.GenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.IdType)
                .WithMany(p => p.HrmEmpMasterIdType)
                .HasForeignKey(d => d.IdTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.MartialStatus)
                .WithMany(p => p.HrmEmpMasterMartialStatus)
                .HasForeignKey(d => d.MartialStatusId)
                .OnDelete(DeleteBehavior.ClientSetNull);


            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmpNo).HasColumnName("EMP_NO");
            entity.Property(e => e.IdNo).HasColumnName("ID_NO");
            entity.Property(e => e.FirstName).HasColumnName("FIRST_NAME");
            entity.Property(e => e.SecondName).HasColumnName("SECOND_NAME");
            entity.Property(e => e.ThirdName).HasColumnName("THIRD_NAME");
            entity.Property(e => e.LastName).HasColumnName("LAST_NAME");
            entity.Property(e => e.DepId).HasColumnName("DEP_ID");
            entity.Property(e => e.IdTypeId).HasColumnName("ID_TYPEID");
            entity.Property(e => e.MotherName).HasColumnName("MOTHER_NAME");
            entity.Property(e => e.GenderId).HasColumnName("GENDER_ID");
            entity.Property(e => e.MartialStatusId).HasColumnName("MARTIAL_STATUS_ID");
            entity.Property(e => e.Birthdate).HasColumnName("BIRTHDATE");
            entity.Property(e => e.ShowInReports).HasColumnName("SHOW_IN_REPORTS");
            entity.Property(e => e.CreateDate).HasColumnName("CREATE_DATE");
            entity.Property(e => e.CreatedBy).HasColumnName("CREATED_BY");
            entity.Property(e => e.UpdateDate).HasColumnName("UPDATE_DATE");
            entity.Property(e => e.UpdatedBy).HasColumnName("UPDATED_BY");
            entity.Property(e => e.IsDeleted).HasColumnName("IS_DELETED");
        }
    }
}
