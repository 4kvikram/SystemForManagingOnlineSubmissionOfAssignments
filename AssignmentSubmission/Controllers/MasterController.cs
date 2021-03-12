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
        private readonly TeacherService _teacherService;
        public MasterController(
            ILogger<MasterController> logger,
            IMainDBUnitOfWork mainDBUnitOfWork,
            MasterService masterService,
            TeacherService teacherService
            ) 
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
            _masterService = masterService;
            _teacherService = teacherService;
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
                    programModel.Id = result.ProgramId;
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
                    ProgramId = programModel.Id,
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
        public async Task<IActionResult> GetAllCourses()
        {
            var courses = await _masterService.GetAllCourse();
            if (courses != null)
            {
                ResponseModel responseModel = new ResponseModel()
                {
                    data = courses,
                    Message = "",
                    Success = true
                };
                return View(responseModel);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddCourse(int Id = 0)
        {
            DropDownModel dropDown = new DropDownModel();
            var programs = await _masterService.GetAllPrograms();
            SelectList selectLists;
            if (programs != null && programs.Success && Id == 0)
            {
                selectLists = new SelectList((List<ProgramModel>)programs.data, "Id", "ProgramName");
                dropDown.DropDownData = selectLists;
            }
            if (Id != 0)
            {
                var data = _IMainDBUnitOfWork.CourseDetailsRepository.GetById(Id);
                CourseModel courseModel = new CourseModel()
                {
                    Id = data.CourseId,
                    Code = data.Coursecode,
                    ProgramId = data.ProgramId,
                    Title = data.Title
                };
                var defaultValue = ((List<ProgramModel>)programs.data).Where(x => x.Id == data.ProgramId).FirstOrDefault();
                selectLists = new SelectList((List<ProgramModel>)programs.data, "Id", "ProgramName", defaultValue);
                dropDown.DropDownData = selectLists;
                dropDown.Data = courseModel;
            }
            return View(dropDown);
        }

        [HttpPost]
        public IActionResult AddCourse(CourseModel courseModel)
        {
            if (courseModel.Id > 0)
            {
                CourseDetails course = new CourseDetails()
                {
                    CourseId = courseModel.Id,
                    ProgramId = courseModel.ProgramId,
                    Coursecode = courseModel.Code,
                    Title = courseModel.Title,
                    DateOfModify = DateTime.Now
                };
                _IMainDBUnitOfWork.CourseDetailsRepository.Update(course);
                _IMainDBUnitOfWork.Save();
            }
            else
            {

                CourseDetails course = new CourseDetails()
                {
                    ProgramId = courseModel.ProgramId,
                    Coursecode = courseModel.Code,
                    Title = courseModel.Title,
                    DateOfModify = DateTime.Now,
                    DateOfCreated = DateTime.Now,
                    Status = Status.Active
                };
                _IMainDBUnitOfWork.CourseDetailsRepository.Insert(course);
                _IMainDBUnitOfWork.Save();
            }
            return RedirectToAction("GetAllCourses");
        }

        public IActionResult EditCourse(int Id)
        {
            return RedirectToAction("AddCourse", new { Id = Id });
        }
        public IActionResult DeleteCourse(int Id)
        {
            var course = _IMainDBUnitOfWork.CourseDetailsRepository.GetById(Id);
            _IMainDBUnitOfWork.CourseDetailsRepository.Delete(course);
            _IMainDBUnitOfWork.Save();
            return RedirectToAction("GetAllCourses");
        }
        #endregion
        [HttpGet]
        public IActionResult GetAllTeacher()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTeacher(TeacherModel teacherModel)
        {
            _teacherService.AddTeacher(teacherModel);
            return View();
        }

    }
}
