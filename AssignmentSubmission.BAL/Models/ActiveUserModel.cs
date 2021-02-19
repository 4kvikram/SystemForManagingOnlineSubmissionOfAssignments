using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class ActiveUserModel
    {
        public int Id { get; set; } = 0;
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Phone { get; set; } = string.Empty;
        public int Gender { get; set; } = 0;
        public int Role { get; set; } = 0;
    }
}
