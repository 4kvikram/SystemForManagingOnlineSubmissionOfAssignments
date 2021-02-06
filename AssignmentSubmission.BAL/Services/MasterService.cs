using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentSubmission.BAL.Services
{
    public class MasterService
    {
        private readonly ILogger<MasterService> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        public MasterService(
            ILogger<MasterService> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        public async Task<List<CourseModel>> GetAllCourse()
        {

            var result = (await _IMainDBUnitOfWork.CourseDetailsRepository.GetAll());
            if (result != null)
            {
                List<CourseModel> courseModel = new List<CourseModel>();
                foreach (var item in result)
                {
                    courseModel.Add(new CourseModel()
                    {
                        Id = item.Id,
                        Code = item.Coursecode,
                        ProgramId = item.ProgramDetails.Id,
                        ProgramName = item.ProgramDetails.Title,
                        Title = item.Title
                    });
                }
                return courseModel;
            }
            else
            {
                return null;
            }


        }
        public async Task<ResponseModel> GetAllPrograms()
        {

            var result = (await _IMainDBUnitOfWork.ProgramsDetailsRepository.GetAll());
            if (result != null)
            {
                List<ProgramModel> programModels = new List<ProgramModel>();
                foreach (var item in result)
                {
                    programModels.Add(new ProgramModel()
                    {
                        Id = item.Id,
                        ProgramCode = item.Code,
                        ProgramName = $"{item.Title} ({item.Code})"
                    });
                }
                return new ResponseModel()
                {
                    data = programModels,
                    Message = "Data found",
                    Success = true
                };
            }
            else
            {
                return new ResponseModel()
                {
                    data = null,
                    Message = "Data not found",
                    Success = false
                };
            }
        }
    }
}
