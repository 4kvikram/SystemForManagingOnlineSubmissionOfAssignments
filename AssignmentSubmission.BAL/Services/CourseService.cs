using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSubmission.BAL.Services
{
    public class CourseService
    {
        private readonly ILogger<CourseService> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        public CourseService(
            ILogger<CourseService> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        public List<CourseModel> GetAllCourse()
        {
            var result = (_IMainDBUnitOfWork.CourseDetailsRepository.GetAll());
            if (result != null)
            {
                List<CourseModel> courseModels = new List<CourseModel>();
                foreach (var item in result)
                {
                    courseModels.Add(new CourseModel()
                    {
                        Id = item.CourseId,
                        Code = item.Coursecode,
                        Title = item.Title,
                        ProgramId = item.ProgramId,
                        ProgramCode = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(item.ProgramId)?.Code
                    });
                }
                return courseModels;
            }
            else
            {
                return null;
            }
        }
    }
}
