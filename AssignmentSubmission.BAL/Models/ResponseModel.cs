using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class ResponseModel
    {
        public string Message { get; set; } = string.Empty;
        public Boolean Success { get; set; } = false;
        public object data { get; set; }
    }
}
