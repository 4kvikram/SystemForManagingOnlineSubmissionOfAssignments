using System;
using System.Collections.Generic;
using System.Text;

namespace AssignmentSubmission.BAL.Constants
{
    public static class Constant
    {
       public const int role  = 2;
    }
    public static class Role
    {
        public const int Admin = 1;
        public const int User = 2;
        public const int Student = 3;
        public const int Teacher = 4;
    }
    public static class Status
    {
        public const int Active = 1;
        public const int Deleted = 2;
        public const int Awaited = 3;
        public const int Advance = 4;
    }
    public enum Gender
    {
     Male,
     Female,
     Other
    }
}
