using AssignmentSubmission.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.DAL.Context
{
    public class AssgnmentDBContext: DbContext
    {

        public AssgnmentDBContext(
            DbContextOptions <AssgnmentDBContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> userDetails { get; set; }
        public DbSet<AssignmentDateSetting> assignmentDateSettings { get; set; }
        public DbSet<AssignmentSubmissionDetails> assignmentSubmissionDetails { get; set; }
        public DbSet<CourseDetails> courseDetails { get; set; }
        public DbSet<ProgramsDetails> ProgramsDetails { get; set; }
        public DbSet<StudentDetails> studentDetails { get; set; }
        public DbSet<TeacherDetails> teacherDetails { get; set; }
    }
}
