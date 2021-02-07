﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssignmentSubmission.DAL.Models
{
    public class StudentDetails
    {
        [Column("Id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Display(Name = "UserDetails")]
        public virtual int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserDetails UserDetails { get; set; }
        public string EnrollmentNo { get; set; }
        public DateTime DOB { get; set; }
        public string StudyCenterCode { get; set; }

        //Foreign Key
        [Display(Name = "ProgramsDetails")]
        public virtual int ProgramDetailsId { get; set; }

        [ForeignKey("ProgramDetailsId")]
        public virtual ProgramsDetails ProgramDetails { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
