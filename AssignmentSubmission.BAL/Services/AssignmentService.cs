using AssignmentSubmission.BAL.Constants;
using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentSubmission.BAL.Services
{
    public class AssignmentService
    {
        private readonly ILogger<AssignmentService> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        public AssignmentService(
            ILogger<AssignmentService> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        public List<AssignmentStatusModel> GetAssignmentByUserId(int id)
        {
            List<AssignmentStatusModel> assignmentdetails = new List<AssignmentStatusModel>();
            var data = _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.GetAll().Where(x => x.UserId == id).ToList();
            foreach (var item in data)
            {
                assignmentdetails.Add(new AssignmentStatusModel()
                {
                    UserId = item.UserId,
                    AssignmentsCode = item.AssignmentsCode,
                    AssignmentSubmissionId = item.AssignmentSubmissionId,
                    CheckedBy = item.CheckedBy,
                    CourseID = item.CourseId,
                    CourseName = _IMainDBUnitOfWork.CourseDetailsRepository.GetById(item.CourseId)?.Title,
                    DateOfCreated = item.DateOfCreated,
                    DateOfModify = item.DateOfModify,
                    Link = item.Link,
                    Marks = item.Marks,
                    Path = item.Path,
                    Status = getStatus(item.Status),
                    VivaMarks = item.VivaMarks,

                });
            }
            return assignmentdetails;
        }
        public string getStatus(int status)
        {
            if (status == Status.Active)
            {
                return "Active";
            }
            else if (status == Status.Pending)
            {
                return "Pending";
            }
            else if (status == Status.Checked)
            {
                return "Checked";
            }
            return string.Empty;
        }
        public List<AssignmentStatusModel> GetAssignmentByCode(int courseCode,int status)
        {
            List<AssignmentStatusModel> assignmentdetails = new List<AssignmentStatusModel>();
            var data = _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.GetAll().Where(x => x.CourseId == courseCode && x.Status== status).ToList();

            foreach (var item in data)
            {
                assignmentdetails.Add(new AssignmentStatusModel()
                {
                    UserId = item.UserId,
                    AssignmentsCode = item.AssignmentsCode,
                    AssignmentSubmissionId = item.AssignmentSubmissionId,
                    CheckedBy = item.CheckedBy,
                    CourseID = item.CourseId,
                    CourseName = _IMainDBUnitOfWork.CourseDetailsRepository.GetById(item.CourseId).Title,
                    DateOfCreated = item.DateOfCreated,
                    DateOfModify = item.DateOfModify,
                    Link = $"../Assignments/{item.Path}",
                    Marks = item.Marks,
                    Path = item.Path,
                    Status = getStatus(item.Status),
                    VivaMarks = item.VivaMarks,
                    Enroll = _IMainDBUnitOfWork.StudentDetailsRepository.GetAll().
                    Where(x => x.UserId == item.UserId)?.FirstOrDefault()?.EnrollmentNo,
                    StudentName = $"{_IMainDBUnitOfWork.UserDetailsRepository.GetById(item.UserId)?.FirstName} {_IMainDBUnitOfWork.UserDetailsRepository.GetById(item.UserId)?.LastName}"
                });
            }
            return assignmentdetails;
        }
        public AssignmentStatusModel GetAssignmentByUserAndCourseID(int userID, int courseid)
        {
            AssignmentStatusModel assignmentdetails=new AssignmentStatusModel();
            var item = _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.GetAll().Where(x => x.UserId == userID && x.CourseId == courseid).FirstOrDefault();

            if (item != null)
            {
                assignmentdetails = new AssignmentStatusModel()
                {
                    UserId = item.UserId,
                    AssignmentsCode = item.AssignmentsCode,
                    AssignmentSubmissionId = item.AssignmentSubmissionId,
                    CheckedBy = item.CheckedBy,
                    CourseID = item.CourseId,
                    CourseName = _IMainDBUnitOfWork.CourseDetailsRepository.GetById(item.CourseId).Title,
                    DateOfCreated = item.DateOfCreated,
                    DateOfModify = item.DateOfModify,
                    Link = $"../Assignments/{item.Path}",
                    Marks = item.Marks,
                    Path = item.Path,
                    Status = getStatus(item.Status),
                    VivaMarks = item.VivaMarks,
                    Enroll = _IMainDBUnitOfWork.StudentDetailsRepository.GetAll().
                    Where(x => x.UserId == item.UserId)?.FirstOrDefault()?.EnrollmentNo,
                    StudentName = $"{_IMainDBUnitOfWork.UserDetailsRepository.GetById(item.UserId)?.FirstName} {_IMainDBUnitOfWork.UserDetailsRepository.GetById(item.UserId)?.LastName}"
                };
            }

            return assignmentdetails;
        }

        public bool saveMarks(AssignmentStatusModel model,int checkedby)
        {
            if (model!=null)
            {
                var assignmentData=_IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.GetById(model.AssignmentSubmissionId);
                assignmentData.Marks = model.Marks;
                assignmentData.VivaMarks = model.VivaMarks;
                assignmentData.Status = Status.Checked;
                assignmentData.CheckedBy = checkedby;
                _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.Update(assignmentData);
                _IMainDBUnitOfWork.Save();
                return true;
            }
            return false;
        }
    }
}
