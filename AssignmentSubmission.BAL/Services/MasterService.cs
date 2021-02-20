using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
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

        public async Task<ResponseModel> GetAllPrograms()
        {

            var result = (await _IMainDBUnitOfWork.ProgramsDetailsRepository.GetAllAsync());
            if (result != null)
            {
                List<ProgramModel> programModels = new List<ProgramModel>();
                foreach (var item in result)
                {
                    programModels.Add(new ProgramModel()
                    {
                        Id = item.ProgramId,
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


        public async Task<List<CourseModel>> GetAllCourse()
        {

            var result = (await _IMainDBUnitOfWork.CourseDetailsRepository.GetAllAsync());
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
