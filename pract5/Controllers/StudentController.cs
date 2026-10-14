using Microsoft.AspNetCore.Mvc;
using pract5.Models;

namespace pract5.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Details()
        {
            ViewBag.Title = "Student Details";
            var student = new Student
            {
                Id = 97,
                Name = "Vedhas Mayekar",
                Email = "vedhas@example.com",
                Class = "T.Y. B.Sc Computer Science"
            };
            return View(student);
        }
    }
}
