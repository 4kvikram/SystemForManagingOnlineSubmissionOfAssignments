﻿using AssignmentSubmission.BAL.Models;
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
            var res = (await _IMainDBUnitOfWork.UserDetailsRepository.GetAll()).Where(x => x.Email == loginModel.Email && x.Password == loginModel.Password && x.Status == Status.Active).FirstOrDefault();
            if (res != null)
            {
                ActiveUserModel activeUserModel = new ActiveUserModel
                {
                    Email = res.Email,
                    FirstName = res.FirstName,
                    LastName = res.LastName,
                    Role = res.Role,
                    Id = res.Id,
                    Phone = res.Phone
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
                Message = $"Welcome"
            };
            return View(response);
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel registrationModel)
        {
            ResponseModel response = new ResponseModel();
            var ExistUser = (await _IMainDBUnitOfWork.UserDetailsRepository.GetAll()).Where(x => x.Email == registrationModel.Email).FirstOrDefault();
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
                }
                var studentProfile = _IMainDBUnitOfWork.StudentDetailsRepository.GetById(userData.Id);
                if (studentProfile != null)
                {
                    studentModel.Id = studentProfile.Id;
                    studentModel.ProgramDetailsId = studentProfile.ProgramDetailsId;
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
            return View();
        }
    }
}
