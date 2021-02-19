using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AssignmentSubmission.DAL.Models
{
    public class UserDetails
    {
        [Column("UserId")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        [Column("FirstName")]
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Column("LastName")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Column("Email")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        [Column("Phone")]
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int OTP { get; set; }
        public int Status { get; set; }
        public DateTime DateOfCreated { get; set; }
        public DateTime DateOfModify { get; set; }
    }
}
