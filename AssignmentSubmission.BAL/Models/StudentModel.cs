using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class StudentModel
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public int Gender { get; set; }

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int Role { get; set; } = 0;
        public int UserId { get; set; }
        public string EnrollmentNo { get; set; }
        public DateTime DOB { get; set; }
        public string StudyCenterCode { get; set; }
        public int ProgramDetailsId { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
