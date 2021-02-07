using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class CourseModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Code { get; set; }
        public int ProgramId { get; set; }
        public String ProgramCode { get; set; }
    }
}
