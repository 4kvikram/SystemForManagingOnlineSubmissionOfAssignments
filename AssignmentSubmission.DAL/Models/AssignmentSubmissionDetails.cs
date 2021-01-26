using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssignmentSubmission.DAL.Models
{
    public class AssignmentSubmissionDetails
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDetails UserDetails { get; set; }
        public string AssignmentsCode { get; set; }
        [ForeignKey("CourseId")]
        public virtual CourseDetails CourseDetails { get; set; }
        public int Marks { get; set; }
        public int VivaMarks { get; set; }

        public int CheckedBy { get; set; }
        public string Path { get; set; }
        public string Link { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
