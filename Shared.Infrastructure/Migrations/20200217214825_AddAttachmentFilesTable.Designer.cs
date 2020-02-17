﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using Shared.Infrastructure.Data;

namespace Shared.Infrastructure.Migrations
{
    [DbContext(typeof(SharedContext))]
    [Migration("20200217214825_AddAttachmentFilesTable")]
    partial class AddAttachmentFilesTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Oracle:ValueGenerationStrategy", OracleValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            modelBuilder.Entity("Shared.Core.Entities.AttachmentFiles", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<byte[]>("FileContent")
                        .HasColumnName("FILE_CONTENT");

                    b.Property<string>("FileExtension")
                        .IsRequired()
                        .HasColumnName("FILE_EXTENSION");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnName("FILE_NAME");

                    b.Property<long>("FileSize")
                        .HasColumnName("FILE_SIZE");

                    b.HasKey("Id");

                    b.ToTable("AttachmentFiles");
                });

            modelBuilder.Entity("Shared.Core.Entities.EmpMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime?>("Birthdate")
                        .HasColumnName("BIRTHDATE");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CREATE_DATE");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("CREATED_BY");

                    b.Property<int?>("DepId")
                        .HasColumnName("DEP_ID");

                    b.Property<int>("EmpNo")
                        .HasColumnName("EMP_NO");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("FIRST_NAME")
                        .HasMaxLength(150);

                    b.Property<int>("GenderId")
                        .HasColumnName("GENDER_ID");

                    b.Property<string>("IdNo")
                        .IsRequired()
                        .HasColumnName("ID_NO")
                        .HasMaxLength(15);

                    b.Property<int>("IdTypeId")
                        .HasColumnName("ID_TYPEID");

                    b.Property<bool>("IsDeleted")
                        .HasColumnName("IS_DELETED");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("LAST_NAME")
                        .HasMaxLength(150);

                    b.Property<int?>("LookupsId");

                    b.Property<int?>("LookupsId1");

                    b.Property<int?>("LookupsId2");

                    b.Property<int?>("LookupsId3");

                    b.Property<int?>("LookupsId4");

                    b.Property<int?>("LookupsId5");

                    b.Property<int>("MartialStatusId")
                        .HasColumnName("MARTIAL_STATUS_ID");

                    b.Property<string>("MotherName")
                        .HasColumnName("MOTHER_NAME");

                    b.Property<string>("SecondName")
                        .IsRequired()
                        .HasColumnName("SECOND_NAME")
                        .HasMaxLength(150);

                    b.Property<bool>("ShowInReports")
                        .HasColumnName("SHOW_IN_REPORTS");

                    b.Property<string>("ThirdName")
                        .IsRequired()
                        .HasColumnName("THIRD_NAME")
                        .HasMaxLength(150);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("UPDATED_BY");

                    b.HasKey("Id");

                    b.HasIndex("DepId");

                    b.HasIndex("EmpNo")
                        .IsUnique();

                    b.HasIndex("GenderId");

                    b.HasIndex("IdNo")
                        .IsUnique();

                    b.HasIndex("IdTypeId");

                    b.HasIndex("LookupsId");

                    b.HasIndex("LookupsId1");

                    b.HasIndex("LookupsId2");

                    b.HasIndex("LookupsId3");

                    b.HasIndex("LookupsId4");

                    b.HasIndex("LookupsId5");

                    b.HasIndex("MartialStatusId");

                    b.ToTable("EMP_MASTER");
                });

            modelBuilder.Entity("Shared.Core.Entities.LookupTypes", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnName("ID");

                    b.Property<bool>("Editable")
                        .HasColumnName("EDITABLE");

                    b.Property<int?>("ParentId")
                        .HasColumnName("PARENT_ID");

                    b.Property<string>("Title")
                        .HasColumnName("TITLE");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("LOOKUP_TYPES");
                });

            modelBuilder.Entity("Shared.Core.Entities.Lookups", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<string>("Code")
                        .HasColumnName("CODE");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("CREATED_BY");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnName("CREATED_DATE")
                        .HasColumnType("date");

                    b.Property<int?>("IsPrimary")
                        .HasColumnName("IS_PRIMARY");

                    b.Property<int?>("LookupTypeId")
                        .HasColumnName("LOOKUP_TYPE_ID");

                    b.Property<int?>("ParentId")
                        .HasColumnName("PARENT_ID");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnName("TITLE")
                        .HasMaxLength(150);

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("UPDATE_DATE")
                        .HasColumnType("date");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("UPDATED_BY");

                    b.Property<string>("Value")
                        .HasColumnName("VALUE");

                    b.HasKey("Id");

                    b.HasIndex("LookupTypeId");

                    b.ToTable("LOOKUPS");
                });

            modelBuilder.Entity("Shared.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnName("CREATE_DATE");

                    b.Property<int>("CreatedBy")
                        .HasColumnName("CREATED_BY");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL");

                    b.Property<int?>("EmployeeId")
                        .HasColumnName("EMPLOYEE_ID");

                    b.Property<string>("FullName")
                        .HasColumnName("FULL_NAME");

                    b.Property<bool>("IsSuperAdmin")
                        .HasColumnName("IS_SUPER_ADMIN");

                    b.Property<bool>("NeedResetPassword")
                        .HasColumnName("NEED_RESET_PASSWORD");

                    b.Property<DateTime?>("PassExpireDate")
                        .HasColumnName("PASS_EXPIRE_DATE");

                    b.Property<string>("Password")
                        .HasColumnName("PASSWORD");

                    b.Property<string>("ResetToken")
                        .HasColumnName("RESET_TOKEN");

                    b.Property<DateTime>("ResetTokenExDate")
                        .HasColumnName("RESET_TOKEN_EX_DATE");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnName("UPDATE_DATE");

                    b.Property<int>("UpdatedBy")
                        .HasColumnName("UPDATED_BY");

                    b.Property<string>("Username")
                        .HasColumnName("USER_NAME");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("USERS_TBL");
                });

            modelBuilder.Entity("Shared.Core.Entities.EmpMaster", b =>
                {
                    b.HasOne("Shared.Core.Entities.Lookups", "Gender")
                        .WithMany("HrmEmpMasterGender")
                        .HasForeignKey("GenderId");

                    b.HasOne("Shared.Core.Entities.Lookups", "IdType")
                        .WithMany("HrmEmpMasterIdType")
                        .HasForeignKey("IdTypeId");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterBirthCity")
                        .HasForeignKey("LookupsId");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterBirthCountry")
                        .HasForeignKey("LookupsId1");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterBloodType")
                        .HasForeignKey("LookupsId2");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterHealthStatus")
                        .HasForeignKey("LookupsId3");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterNickname")
                        .HasForeignKey("LookupsId4");

                    b.HasOne("Shared.Core.Entities.Lookups")
                        .WithMany("HrmEmpMasterReligion")
                        .HasForeignKey("LookupsId5");

                    b.HasOne("Shared.Core.Entities.Lookups", "MartialStatus")
                        .WithMany("HrmEmpMasterMartialStatus")
                        .HasForeignKey("MartialStatusId");
                });

            modelBuilder.Entity("Shared.Core.Entities.LookupTypes", b =>
                {
                    b.HasOne("Shared.Core.Entities.LookupTypes", "Parent")
                        .WithMany("InverseParent")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Shared.Core.Entities.Lookups", b =>
                {
                    b.HasOne("Shared.Core.Entities.LookupTypes", "LookupType")
                        .WithMany("Lookups")
                        .HasForeignKey("LookupTypeId");
                });

            modelBuilder.Entity("Shared.Core.Entities.User", b =>
                {
                    b.HasOne("Shared.Core.Entities.EmpMaster", "Employee")
                        .WithMany("Users")
                        .HasForeignKey("EmployeeId");
                });
#pragma warning restore 612, 618
        }
    }
}
