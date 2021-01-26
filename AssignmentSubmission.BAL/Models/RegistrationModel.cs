using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Models
{
    public class RegistrationModel
    {
       
        public int Id { get; set; }
   
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
   
        public string Email { get; set; }
     
        public string Phone { get; set; }
        public string Password { get; set; }
        public int Gender { get; set; }
    
    }
}
