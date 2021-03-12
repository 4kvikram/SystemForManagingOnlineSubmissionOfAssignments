using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace AssignmentSubmission.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ILogger<AssignmentController> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;

        public AssignmentController(
            ILogger<AssignmentController> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        [HttpGet]
        public IActionResult UploadAssignment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadAssignment(AssignmentModel assignmentModel)
        {
            string fileName = await UploadFiles(assignmentModel.Assignment1);
            if (!string.IsNullOrEmpty(fileName))
            {

            }
            return View();
        }
        public async Task<string> UploadFiles(IFormFile file)
        {
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string ext = Path.GetExtension(file.FileName);
                if (ext == ".pdf" || ext == ".PDF")
                {
                    string NamewithoutExt = new String(Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray()).Replace(" ", "-");
                    string finalName = NamewithoutExt + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assignments",
                     finalName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                    return finalName;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
        public void SaveFiles(string fileName, int courseid)
        {
            var x = HttpContext.Session.GetString("ActiveUser");
            if (x != null)
            {
                ActiveUserModel userData = new ActiveUserModel();
                userData = JsonSerializer.Deserialize<ActiveUserModel>(x);

                AssignmentSubmissionDetails assignmentSubmissionDetails = new AssignmentSubmissionDetails();
                assignmentSubmissionDetails.CourseId = courseid;
                assignmentSubmissionDetails.Path = fileName;

                _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.Insert(assignmentSubmissionDetails);
                _IMainDBUnitOfWork.Save();
            }
        }
    }
}
