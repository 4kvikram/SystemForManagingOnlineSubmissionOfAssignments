using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class AssignmentStatusModel
    {
        public int AssignmentSubmissionId { get; set; }

        public int UserId { get; set; }
        public string AssignmentsCode { get; set; }

        public string CourseName { get; set; }

        public int Marks { get; set; }
        public int VivaMarks { get; set; }

        public int CheckedBy { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public string Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
