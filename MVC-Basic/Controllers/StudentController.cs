using Microsoft.AspNetCore.Mvc;
using MVC_Basic.ViewModel;

namespace MVC_Basic.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(StudentRegistrationViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Save to DB

            return View("Success", model); // stay on same page
        }

        public IActionResult Success()
        {
            return Content("Registration successful!");
        }

    }
}
