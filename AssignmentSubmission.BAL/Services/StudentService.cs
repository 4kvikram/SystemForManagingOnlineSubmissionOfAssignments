using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Services
{
    public class StudentService
    {
        private readonly ILogger<MasterService> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        public StudentService(
              ILogger<MasterService> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }
        public void AddStudent()
        {

        }
    }
}
