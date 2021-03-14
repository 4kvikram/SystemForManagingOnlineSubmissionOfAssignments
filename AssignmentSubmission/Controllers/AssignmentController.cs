using AssignmentSubmission.BAL.Constants;
using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.BAL.Services;
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
        private readonly AssignmentService _assignmentService;

        public AssignmentController(
            ILogger<AssignmentController> logger,
            IMainDBUnitOfWork mainDBUnitOfWork,
            AssignmentService assignmentService
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
            _assignmentService = assignmentService;
        }

        [HttpGet]
        public IActionResult UploadAssignment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadAssignment(AssignmentModel assignmentModel)
        {
            string fileName1 = await UploadFiles(assignmentModel.Assignment1);
            if (!string.IsNullOrEmpty(fileName1) && assignmentModel.Course1 != 0)
            {
                SaveFiles(fileName1, assignmentModel.Course1);
            }

            //string fileName2 = await UploadFiles(assignmentModel.Assignment2);
            //if (!string.IsNullOrEmpty(fileName2) && assignmentModel.Course2 != 0)
            //{
            //    SaveFiles(fileName2, assignmentModel.Course2);
            //}

            //string fileName3 = await UploadFiles(assignmentModel.Assignment3);
            //if (!string.IsNullOrEmpty(fileName3) && assignmentModel.Course3 != 0)
            //{
            //    SaveFiles(fileName3, assignmentModel.Course3);
            //}

            //string fileName4 = await UploadFiles(assignmentModel.Assignment4);
            //if (!string.IsNullOrEmpty(fileName4) && assignmentModel.Course4 != 0)
            //{
            //    SaveFiles(fileName4, assignmentModel.Course4);
            //}

            //string fileName5 = await UploadFiles(assignmentModel.Assignment5);
            //if (!string.IsNullOrEmpty(fileName5) && assignmentModel.Course5 != 0)
            //{
            //    SaveFiles(fileName5, assignmentModel.Course5);
            //}

            //string fileName6 = await UploadFiles(assignmentModel.Assignment6);
            //if (!string.IsNullOrEmpty(fileName6) && assignmentModel.Course6 != 0)
            //{
            //    SaveFiles(fileName6, assignmentModel.Course6);
            //}

            //string fileName7 = await UploadFiles(assignmentModel.Assignment7);
            //if (!string.IsNullOrEmpty(fileName7) && assignmentModel.Course7 != 0)
            //{
            //    SaveFiles(fileName7, assignmentModel.Course7);
            //}

            //string fileName8 = await UploadFiles(assignmentModel.Assignment8);
            //if (!string.IsNullOrEmpty(fileName8) && assignmentModel.Course8 != 0)
            //{
            //    SaveFiles(fileName8, assignmentModel.Course8);
            //}

            //string fileName9 = await UploadFiles(assignmentModel.Assignment9);
            //if (!string.IsNullOrEmpty(fileName9) && assignmentModel.Course9 != 0)
            //{
            //    SaveFiles(fileName9, assignmentModel.Course9);
            //}
            return RedirectToAction("AssignmentStatus");
        }
        public IActionResult AssignmentStatus()
        {
            ResponseModel model = new ResponseModel();

            var x = HttpContext.Session.GetString("ActiveUser");
            if (x != null)
            {
                ActiveUserModel userData = new ActiveUserModel();
                userData = JsonSerializer.Deserialize<ActiveUserModel>(x);
                model.data = _assignmentService.GetAssignmentByUserId(userData.Id);
            }
            return View(model);
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

                AssignmentSubmissionDetails assignmentSubmissionDetails = new AssignmentSubmissionDetails()
                {
                    DateOfCreated = DateTime.Now,
                    DateOfModify = DateTime.Now,
                    Status = Status.Pending,
                    Path = fileName,
                    CourseId = courseid,
                    UserId = userData.Id,
                };

                _IMainDBUnitOfWork.AssignmentSubmissionDetailsRepository.Insert(assignmentSubmissionDetails);
                _IMainDBUnitOfWork.Save();
            }
        }

        public IActionResult CheckAssignment()
        {
            return View();
        }
    }
}
