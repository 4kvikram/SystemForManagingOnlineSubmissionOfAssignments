using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class ResponseModel
    {
        public string Message { get; set; }
        public Boolean Success { get; set; } = false;
        public object data { get; set; }
    }
}
