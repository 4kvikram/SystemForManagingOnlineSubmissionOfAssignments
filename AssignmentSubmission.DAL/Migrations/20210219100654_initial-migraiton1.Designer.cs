﻿// <auto-generated />
using System;
using AssignmentSubmission.DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AssignmentSubmission.DAL.Migrations
{
    [DbContext(typeof(AssgnmentDBContext))]
    [Migration("20210219100654_initial-migraiton1")]
    partial class initialmigraiton1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.AssignmentDateSetting", b =>
                {
                    b.Property<int>("AssignmentDateSettingId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AssignmentDateSettingId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("AssignmentDateSettingId");

                    b.ToTable("assignmentDateSettings");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.AssignmentSubmissionDetails", b =>
                {
                    b.Property<int>("AssignmentSubmissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AssignmentSubmissionId")
                        .UseIdentityColumn();

                    b.Property<string>("AssignmentsCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CheckedBy")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("VivaMarks")
                        .HasColumnType("int");

                    b.HasKey("AssignmentSubmissionId");

                    b.HasIndex("CourseId");

                    b.ToTable("assignmentSubmissionDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.CourseDetails", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CourseId")
                        .UseIdentityColumn();

                    b.Property<string>("Coursecode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProgramId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("courseDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.ProgramsDetails", b =>
                {
                    b.Property<int>("ProgramId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ProgramId")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProgramId");

                    b.ToTable("ProgramsDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.StudentDetails", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("StudentId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("EnrollmentNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("StudentProgramId")
                        .HasColumnType("int");

                    b.Property<string>("StudyCenterCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("StudentId");

                    b.HasIndex("StudentProgramId");

                    b.ToTable("studentDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.TeacherDetails", b =>
                {
                    b.Property<int>("TeacherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("TeacherId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("StudyCenterCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subjects")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("TeacherId");

                    b.ToTable("teacherDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.UserDetails", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateOfCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfModify")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Email");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("LastName");

                    b.Property<int>("OTP")
                        .HasColumnType("int");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("Phone");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("userDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.AssignmentSubmissionDetails", b =>
                {
                    b.HasOne("AssignmentSubmission.DAL.Models.CourseDetails", "CourseDetails")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseDetails");
                });

            modelBuilder.Entity("AssignmentSubmission.DAL.Models.StudentDetails", b =>
                {
                    b.HasOne("AssignmentSubmission.DAL.Models.ProgramsDetails", "ProgramDetails")
                        .WithMany()
                        .HasForeignKey("StudentProgramId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProgramDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
