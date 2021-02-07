using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentSubmission.Models
{
    public class DropDownModel
    {
        public SelectList DropDownData { get; set; }
        public Object Data { get; set; }
    }
}
