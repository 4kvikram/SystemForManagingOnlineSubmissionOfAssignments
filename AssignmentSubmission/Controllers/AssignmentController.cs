using AssignmentSubmission.BAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AssignmentSubmission.Controllers
{
    public class AssignmentController : Controller
    {
        [HttpGet]
        public IActionResult UploadAssignment()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UploadAssignment(AssignmentModel assignmentModel)
        {
            await UploadFiles(assignmentModel.Assignment1);
            return View();
        }
        public async Task<bool> UploadFiles(IFormFile file)
        {
            if (file != null)
            {
                string fileName = Path.GetFileName(file.FileName);
                string NamewithoutExt = new String(Path.GetFileNameWithoutExtension(fileName).Take(10).ToArray()).Replace(" ", "-");
                string finalName = NamewithoutExt + DateTime.Now.ToString("yymmssfff") + Path.GetExtension(fileName);
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assignments",
                 finalName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                return true;
            }
            return false;
        }
    }
}
