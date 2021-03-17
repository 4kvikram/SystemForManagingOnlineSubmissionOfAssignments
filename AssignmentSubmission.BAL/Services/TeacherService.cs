using AssignmentSubmission.BAL.Models;
using AssignmentSubmission.DAL.Models;
using AssignmentSubmission.DAL.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AssignmentSubmission.BAL.Services
{
    public class TeacherService
    {
        private readonly ILogger<TeacherService> _logger;
        private readonly IMainDBUnitOfWork _IMainDBUnitOfWork;
        public TeacherService(
            ILogger<TeacherService> logger,
            IMainDBUnitOfWork mainDBUnitOfWork
            )
        {
            _logger = logger;
            _IMainDBUnitOfWork = mainDBUnitOfWork;
        }

        public List<TeacherModel> GetAllTeachers()
        {
            List<TeacherModel> teachersList = new List<TeacherModel>();
            var teachers = _IMainDBUnitOfWork.TeacherDetailsRepository.GetAll();
            if (teachers != null)
            {
                foreach (var item in teachers)
                {
                    var teacherUser = _IMainDBUnitOfWork.UserDetailsRepository.GetAll().Where(x => x.UserId == item.UserId).FirstOrDefault();
                    if (teacherUser != null)
                    {
                        teachersList.Add(new TeacherModel()
                        {
                            Email = teacherUser.Email,
                            FirstName = teacherUser.FirstName,
                            LastName = teacherUser.LastName,
                            Phone = teacherUser.Phone,
                            UserId = teacherUser.UserId,
                            Gender = teacherUser.Gender,
                            Password = teacherUser.Password,
                            StudyCenterCode = item.StudyCenterCode,
                            Subjects = item.Subjects,
                            TeacherId = item.TeacherId
                        });
                    }
                }
            }
            return teachersList;
        }
        public bool AddTeacher(TeacherModel teacherModel)
        {
            if (teacherModel != null)
            {
                UserDetails user = new UserDetails()
                {
                    FirstName = teacherModel.FirstName,
                    LastName = teacherModel.LastName,
                    Email = teacherModel.Email,
                    Password = teacherModel.Password,
                    Gender = teacherModel.Gender,
                    Phone = teacherModel.Phone,
                    Role = Constants.Role.Teacher,
                    DateOfCreated = DateTime.Now,
                    DateOfModify = DateTime.Now,
                    Status = Constants.Status.Active
                };
                var res = _IMainDBUnitOfWork.UserDetailsRepository.Add(user);
                _IMainDBUnitOfWork.Save();
                var data = _IMainDBUnitOfWork.UserDetailsRepository.GetAll().OrderBy(x => x.UserId).LastOrDefault();
                if (data != null)
                {
                    TeacherDetails teacherDetails = new TeacherDetails()
                    {
                        StudyCenterCode = teacherModel.StudyCenterCode,
                        Subjects = teacherModel.Subjects,
                        UserId = data.UserId,
                        DateOfCreated = DateTime.Now,
                        DateOfModify = DateTime.Now,
                        Status = Constants.Status.Active
                    };
                    _IMainDBUnitOfWork.TeacherDetailsRepository.Add(teacherDetails);
                    _IMainDBUnitOfWork.Save();
                }
                return true;
            }
            return false;
        }

        public TeacherModel GetTeachersByUserId(int id)
        {
            var teachers = _IMainDBUnitOfWork.TeacherDetailsRepository.GetAll().Where(x => x.UserId == id).FirstOrDefault();
            if (teachers != null)
            {
                var teacherUser = _IMainDBUnitOfWork.UserDetailsRepository.GetAll().Where(x => x.UserId == teachers.UserId).FirstOrDefault();
                TeacherModel teacherModel = new TeacherModel()
                {
                    Email = teacherUser.Email,
                    FirstName = teacherUser.FirstName,
                    LastName = teacherUser.LastName,
                    Phone = teacherUser.Phone,
                    UserId = teacherUser.UserId,
                    Gender = teacherUser.Gender,
                    Password = teacherUser.Password,
                    StudyCenterCode = teachers.StudyCenterCode,
                    Subjects = teachers.Subjects,
                    TeacherId = teachers.TeacherId
                };
                return teacherModel;
            }
            return null;
        }
    }
}
