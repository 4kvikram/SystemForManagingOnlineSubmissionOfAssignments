using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using AssignmentSubmission.BAL.Constants;

namespace AssignmentSubmission.Controllers
{
    public class AuthController : Controller
    {
        private readonly ILogger<AuthController> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;

        public AuthController(
            ILogger<AuthController> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        [HttpGet]
        public IActionResult Login()
        {
            HttpContext.Session.SetString("User", "The Doctor");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            var res = (await _IMainDBUnitOfWork.UserDetailsRepository.GetAllAsync()).Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password && x.Status == Status.Active).FirstOrDefault();
            if (res != null)
            {
                ActiveUserModel activeUserModel = new ActiveUserModel
                {
                    Email = res.Email,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Role = res.Role,
                    Id = res.UserId,
                    Phone = res.Phone,
                    Gender = res.Gender
                };
                string userdata = JsonSerializer.Serialize(activeUserModel);
                HttpContext.Session.SetString("ActiveUser", userdata);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Registration()
        {
            var data = HttpContext.Session.GetString("User");
            ResponseModel response = new ResponseModel
            {
                Success = true,
                Message = $"Registre Here.."
            };
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel registrationModel)
        {
            ResponseModel response = new ResponseModel();
            var ExistUser = (await _IMainDBUnitOfWork.UserDetailsRepository.GetAllAsync()).Where(x => x.Email == registrationModel.Email).FirstOrDefault();
            if (ExistUser == null)
            {
                UserDetails user = new UserDetails
                {
                    DateOfCreated = DateTime.Now,
                    DateOfModify = DateTime.Now,
                    Email = registrationModel.Email,
                    FirstName = registrationModel.FirstName,
                    LastName = registrationModel.LastName,
                    Gender = registrationModel.Gender,
                    Password = registrationModel.Password,
                    Phone = registrationModel.Phone,
                    Role = Role.User,
                    Status = Status.Active
                };
                _IMainDBUnitOfWork.UserDetailsRepository.Insert(user);
                var res = await _IMainDBUnitOfWork.SaveAsync();
                if (res > 0)
                {
                    response = new ResponseModel
                    {
                        Success = true,
                        Message = $"User saved successfully"
                    };
                    return View(response);
                }
                else
                {
                    response = new ResponseModel
                    {
                        Success = false,
                        Message = $"Failed to create user"
                    };
                    return View(response);
                }
            }
            else
            {
                response = new ResponseModel
                {
                    Success = false,
                    Message = $"User with email : {registrationModel.Email} allready exist"
                };
            }
            return View(response);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult UserProfile()
        {
            StudentModel studentModel = new StudentModel();
            var x = HttpContext.Session.GetString("ActiveUser");
            if (x != null)
            {
                ActiveUserModel userData = new ActiveUserModel();
                userData = JsonSerializer.Deserialize<ActiveUserModel>(x);
                if (!string.IsNullOrEmpty(userData.Email))
                {
                    studentModel.Email = userData.Email;
                    studentModel.FirstName = userData.FirstName;
                    studentModel.LastName = userData.LastName;
                    studentModel.Phone = userData.Phone;
                    studentModel.Role = userData.Role;
                    studentModel.Gender = userData.Gender;
                    studentModel.UserId = userData.Id;

                }
                var studentProfile = _IMainDBUnitOfWork.StudentDetailsRepository.GetAll().
                    Where(x => x.UserId == userData.Id).FirstOrDefault();
                if (studentProfile != null)
                {
                    studentModel.Id = studentProfile.StudentId;
                    studentModel.ProgramDetailsId = studentProfile.StudentProgramId;
                    studentModel.Status = studentProfile.Status;
                    studentModel.UserId = studentProfile.UserId;
                    studentModel.DOB = studentProfile.DOB;
                    studentModel.StudyCenterCode = studentProfile.StudyCenterCode;
                    studentModel.EnrollmentNo = studentProfile.EnrollmentNo;
                }
            }
            return View(studentModel);
        }
        [HttpPost]
        public IActionResult UserProfile(StudentModel studentModel)
        {
            if (studentModel.UserId != 0 && !string.IsNullOrEmpty(studentModel.Email))
            {
                var result = _IMainDBUnitOfWork.StudentDetailsRepository.GetAll().Where(x => x.UserId == studentModel.UserId).FirstOrDefault();
                StudentDetails studentDetails = new StudentDetails();
                // studentDetails.ProgramDetails = _IMainDBUnitOfWork.ProgramsDetailsRepository.GetById(studentModel.ProgramDetailsId);
                studentDetails.Status = Status.Active;
                studentDetails.StudyCenterCode = studentModel.StudyCenterCode;
                studentDetails.EnrollmentNo = studentModel.EnrollmentNo;
                studentDetails.StudentProgramId = 2;
                studentDetails.DOB = studentModel.DOB;
                studentDetails.DateOfCreated = DateTime.Now;
                studentDetails.DateOfModify = DateTime.Now;
                if (result != null)
                {

                    studentDetails.StudentId = result.StudentId;
                    _IMainDBUnitOfWork.StudentDetailsRepository.Update(studentDetails);
                    _IMainDBUnitOfWork.Save();
                }
                else
                {
                    studentDetails.UserId = studentModel.UserId;
                    _IMainDBUnitOfWork.StudentDetailsRepository.Insert(studentDetails);
                    _IMainDBUnitOfWork.Save();
                }
            }
            return RedirectToAction("UserProfile");
        }
        [HttpGet]
        public IActionResult ResetPassword()
        {
            ResponseModel responseModel = new ResponseModel
            {
                data = null,
                Message = ""
            };
            return View(responseModel);
        }
        [HttpPost]
        public IActionResult ResetPassword(PasswordResetModel passwordResetModel)
        {
            ResponseModel responseModel = new ResponseModel();
            var x = HttpContext.Session.GetString("ActiveUser");
            if (x != null)
            {
                ActiveUserModel userData = new ActiveUserModel();
                userData = JsonSerializer.Deserialize<ActiveUserModel>(x);
                UserDetails user = _IMainDBUnitOfWork.UserDetailsRepository.GetAll().Where
                    (x => x.Email == userData.Email && x.Password == passwordResetModel.OldPassword).FirstOrDefault();
                if (user != null)
                {
                    user.Password = passwordResetModel.NewPassword;
                    _IMainDBUnitOfWork.UserDetailsRepository.Update(user);
                    _IMainDBUnitOfWork.Save();
                    responseModel.data = null;
                    responseModel.Message = "Password Changed";
                }
            }
            return View(responseModel);
        }

        [HttpGet]
        public IActionResult ForgetPassword()
        {
            ResponseModel responseModel = new ResponseModel();
            return View(responseModel);
        }
        [HttpPost]
        public IActionResult ForgetPassword(PasswordResetModel PRM)
        {
            ResponseModel responseModel = new ResponseModel();
            var user=_IMainDBUnitOfWork.UserDetailsRepository.GetAll().Where(x => 
            x.Email == PRM.Email && x.Phone == PRM.Phone).FirstOrDefault();
            if (user!=null)
            {
                user.Password = PRM.NewPassword;
                _IMainDBUnitOfWork.UserDetailsRepository.Update(user);
                _IMainDBUnitOfWork.Save();

                responseModel.Message = "Password Reset Sussfully..";
            }
            else
            {
                responseModel.Message = "Please Enter Valid Email and Phone";
            }
            return View(responseModel);
        }
    }
}
