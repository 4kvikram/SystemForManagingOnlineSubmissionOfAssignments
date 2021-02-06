using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using AssignmentSubmission.BAL.Constants;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssignmentSubmission.BAL.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using AssignmentSubmission.Models;

namespace AssignmentSubmission.Controllers
{
    public class MasterController : Controller
    {
        private readonly ILogger<MasterController> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        private readonly MasterService _masterService;
        public MasterController(
            ILogger<MasterController> logger,
            IMainDBUnitOfWork mainDBUnitOfWork,
            MasterService masterService
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
            _masterService = masterService;
        }
        #region Manage Program
        public async Task<IActionResult> GetAllProgram()
        {
            ResponseModel courses = await _masterService.GetAllPrograms();

            return View(courses);
        }
        [HttpGet]
        public IActionResult AddProgram(int Id = 0)
        {
            ProgramModel programModel = new ProgramModel();
            if (Id != 0)
            {
                var result = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(Id);
                if (result != null)
                {

                    programModel.Id = result.Id;
                    programModel.ProgramName = result.Title;
                    programModel.ProgramCode = result.Code;

                    return View(programModel);
                }
            }
            return View(programModel);
        }
        [HttpPost]
        public IActionResult AddProgram(ProgramModel programModel)
        {
            if (programModel.Id != 0)
            {
                ProgramsDetails program = new ProgramsDetails()
                {
                    Id = programModel.Id,
                    Code = programModel.ProgramCode,
                    Title = programModel.ProgramName,
                    DateOfModify = DateTime.Now,
                };
                _IMainDBUnitOfWork.ProgramsDetailsRepository.Update(program);
                _IMainDBUnitOfWork.Save();
            }
            else
            {
                ProgramsDetails program = new ProgramsDetails()
                {
                    Code = programModel.ProgramCode,
                    Title = programModel.ProgramName,
                    DateOfModify = DateTime.Now,
                    DateOfCreated = DateTime.Now,
                    Status = Status.Active
                };
                _IMainDBUnitOfWork.ProgramsDetailsRepository.Insert(program);
                _IMainDBUnitOfWork.Save();
            }
            return RedirectToAction("GetAllProgram");
        }
        public IActionResult EditProgram(int Id)
        {
            return RedirectToAction("AddProgram", new { Id = Id });
        }
        public IActionResult DeleteProgram(int Id)
        {
            var program = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(Id);
            _IMainDBUnitOfWork.ProgramsDetailsRepository.Delete(program);
            _IMainDBUnitOfWork.Save();
            return RedirectToAction("GetAllProgram");
        }

        #endregion
        #region Manage Course
        [HttpGet]
        public IActionResult GetAllCourse()
        {
            var course = _masterService.GetAllCourse();
            if (course!=null)
            {

            }
            
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCourse(int id = 0)
        {
            DropDownModel dropDown = new DropDownModel();
            var courses = await _masterService.GetAllPrograms();
            if (courses != null && courses.Success)
            {
                SelectList selectLists = new SelectList((List<ProgramModel>)courses.data, "Id", "ProgramName");
                dropDown.DropDownData = selectLists;
            }
            return View(dropDown);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseModel courseModel)
        {
            CourseDetails course = new CourseDetails()
            {
                ProgramDetails = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(courseModel.ProgramId),
                Coursecode = courseModel.Code,
                Title = courseModel.Title,
                DateOfModify = DateTime.Now,
                DateOfCreated = DateTime.Now,
                Status = Status.Active
            };
            _IMainDBUnitOfWork.CourseDetailsRepository.Insert(course);
            _IMainDBUnitOfWork.Save();
            return View();
        }

        public IActionResult EditCourse(int Id)
        {
            return RedirectToAction("AddProgram", new { Id = Id });
        }
        public IActionResult DeleteCourse(int Id)
        {
            var program = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(Id);
            _IMainDBUnitOfWork.ProgramsDetailsRepository.Delete(program);
            _IMainDBUnitOfWork.Save();
            return RedirectToAction("GetAllProgram");
        }
        #endregion 
    }
}
