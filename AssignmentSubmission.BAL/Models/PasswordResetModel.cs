using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class PasswordResetModel
    {
        public string userId { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
