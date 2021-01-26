using AssignmentSubmission.DAL.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AssignmentSubmission.DAL.Models;
namespace AssignmentSubmission.DAL.Repositories
{
    public class MainDBUnitOfWork : IMainDBUnitOfWork
    {
        private readonly AssgnmentDBContext _dbContext;
        public MainDBUnitOfWork(AssgnmentDBContext dbContext)
        {
            _dbContext = dbContext;
            AssignmentDateSettingRepository = new BaseRepository<AssignmentDateSetting>(_dbContext);
            AssignmentSubmissionDetailsRepository = new BaseRepository<AssignmentSubmissionDetails>(_dbContext);
            CourseDetailsRepository = new BaseRepository<CourseDetails>(_dbContext);
            ProgramsDetailsRepository = new BaseRepository<ProgramsDetails>(_dbContext);
            StudentDetailsRepository = new BaseRepository<StudentDetails>(_dbContext);
            TeacherDetailsRepository = new BaseRepository<TeacherDetails>(_dbContext);
            UserDetailsRepository = new BaseRepository<UserDetails>(_dbContext);
        }

        public IBaseRepository<AssignmentDateSetting> AssignmentDateSettingRepository { get; set; }
        public IBaseRepository<AssignmentSubmissionDetails> AssignmentSubmissionDetailsRepository { get; set; }
        public IBaseRepository<CourseDetails> CourseDetailsRepository { get; set; }
        public IBaseRepository<ProgramsDetails> ProgramsDetailsRepository { get; set; }
        public IBaseRepository<StudentDetails> StudentDetailsRepository { get; set; }
        public IBaseRepository<TeacherDetails> TeacherDetailsRepository { get; set; }
        public IBaseRepository<UserDetails> UserDetailsRepository { get; set; }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dbContext.Dispose();
        }

    }
}
