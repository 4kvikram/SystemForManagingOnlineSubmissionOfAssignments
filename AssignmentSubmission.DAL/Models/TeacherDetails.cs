using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssignmentSubmission.DAL.Models
{
    public class TeacherDetails
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        //Foreign Key
        [Display(Name = "UserDetails")]
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDetails UserDetails { get; set; }
        public string StudyCenterCode { get; set; }
        public string Subjects { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
