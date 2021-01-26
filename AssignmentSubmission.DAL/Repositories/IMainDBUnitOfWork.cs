using AssignmentSubmission.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSubmission.DAL.Repositories
{
    public interface IMainDBUnitOfWork : IDisposable
    {
        IBaseRepository<AssignmentDateSetting> AssignmentDateSettingRepository { get; set; }
        IBaseRepository<AssignmentSubmissionDetails> AssignmentSubmissionDetailsRepository { get; set; }
        IBaseRepository<CourseDetails> CourseDetailsRepository { get; set; }
        IBaseRepository<ProgramsDetails> ProgramsDetailsRepository { get; set; }
        IBaseRepository<StudentDetails> StudentDetailsRepository { get; set; }
        IBaseRepository<TeacherDetails> TeacherDetailsRepository { get; set; }
        IBaseRepository<UserDetails> UserDetailsRepository { get; set; }
        void Save();
        Task<int> SaveAsync();
    }
}
