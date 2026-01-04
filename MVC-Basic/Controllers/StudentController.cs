using Microsoft.AspNetCore.Mvc;
using MVC_Basic.Models;
using MVC_Basic.ViewModel;

namespace MVC_Basic.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();

        public ActionResult Index()
        {
            return View(students);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            students.Add(new Student
            {
                Id = students.Count + 1,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Gender = model.Gender,
                Email = model.Email,
                Phone = model.Phone,
                Address = model.Address,
                Course = model.Course
            });

            return RedirectToAction("Index");
        }
    }
}
